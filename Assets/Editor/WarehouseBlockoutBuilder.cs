using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

/// <summary>Phase 1 warehouse layout builder. Regeneration replaces only WAREHOUSE_ROOT.</summary>
public static class WarehouseBlockoutBuilder
{
    const string ScenePath = "Assets/Scenes/Warehouse_Blockout.unity";
    const string MatPath = "Assets/Materials/Blockout_";
    static Transform root, architecture, zones, storage, logistics, exterior, cameras;
    static Material concrete, wall, rack, office, receiving, sorting, packing, dispatch, route, dock, truck;

    [MenuItem("Warehouse/Phase 1/Regenerate Blockout")]
    public static void Regenerate()
    {
        if (SceneManager.GetActiveScene().path != ScenePath)
        {
            if (File.Exists(ScenePath)) EditorSceneManager.OpenScene(ScenePath, OpenSceneMode.Single);
            else { EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single); }
        }
        BuildInActiveScene();
        EditorSceneManager.SaveScene(SceneManager.GetActiveScene(), ScenePath);
        AssetDatabase.SaveAssets();
        Debug.Log("Warehouse Phase 1 blockout regenerated and saved: " + ScenePath);
    }

    static void BuildInActiveScene()
    {
        var old = GameObject.Find("WAREHOUSE_ROOT");
        if (old) Object.DestroyImmediate(old);
        concrete = Mat("Concrete", new Color(.38f,.42f,.43f)); wall = Mat("Wall", new Color(.68f,.70f,.68f));
        rack = Mat("Rack", new Color(.95f,.48f,.12f)); office = Mat("Office", new Color(.28f,.54f,.83f));
        receiving = Mat("Receiving", new Color(.24f,.68f,.62f)); sorting = Mat("Sorting", new Color(.84f,.68f,.22f));
        packing = Mat("Packing", new Color(.65f,.47f,.78f)); dispatch = Mat("Dispatch", new Color(.24f,.72f,.39f));
        route = Mat("Routes", new Color(.93f,.86f,.35f)); dock = Mat("Dock", new Color(.34f,.39f,.46f)); truck = Mat("Truck", new Color(.19f,.37f,.67f));
        root = Group("WAREHOUSE_ROOT", null);
        architecture = Group("ARCHITECTURE_BLOCKOUT", root); zones = Group("ZONE_MARKERS", root);
        storage = Group("STORAGE_BLOCKOUT", root); logistics = Group("LOGISTICS_BLOCKOUT", root);
        exterior = Group("EXTERIOR_BLOCKOUT", root); cameras = Group("CAMERA_MARKERS", root);

        Box("Warehouse Floor 60x40m", architecture, new Vector3(30,-.15f,20), new Vector3(60,.3f,40), concrete);
        // 9 m clear internal height; south facade split around the three 4 m dock openings.
        Box("North Wall", architecture,new Vector3(30,4.5f,40),new Vector3(60,9,.5f),wall);
        Box("West Wall", architecture,new Vector3(0,4.5f,20),new Vector3(.5f,9,40),wall);
        Box("East Wall", architecture,new Vector3(60,4.5f,20),new Vector3(.5f,9,40),wall);
        Box("South Wall West",architecture,new Vector3(19,4.5f,0),new Vector3(38,9,.5f),wall);
        Box("South Wall East",architecture,new Vector3(58,4.5f,0),new Vector3(4,9,.5f),wall);
        Box("South Wall Dock Pier 1",architecture,new Vector3(43.5f,4.5f,0),new Vector3(3,9,.5f),wall);
        Box("South Wall Dock Pier 2",architecture,new Vector3(50.5f,4.5f,0),new Vector3(3,9,.5f),wall);
        // restrained beam markers retain the full roof height without hiding the plan
        for(int x=5;x<60;x+=10) Box("Roof Beam X"+x,architecture,new Vector3(x,8.65f,20),new Vector3(.22f,.25f,39),dock);

        Zone("Zone_Storage", "STORAGE | X 3-31, Z 7-30", 17,18.5f,28,23, rack);
        Zone("Zone_Office", "OFFICE | X 2-13, Z 31-38",7.5f,34.5f,11,7,office);
        Zone("Zone_Receiving", "RECEIVING | X 14-30, Z 31-38",22,34.5f,16,7,receiving);
        Zone("Zone_Forklift_Spine", "CLEAR FORKLIFT SPINE | X 32-36",34,20,4,34,route);
        Zone("Zone_Sorting", "SORTING | X 38-56, Z 19-29",47,24,18,10,sorting);
        Zone("Zone_Packing", "PACKING | X 38-56, Z 12-18",47,15,18,6,packing);
        Zone("Zone_Dispatch", "DISPATCH | X 37-58, Z 3-11",47.5f,7,21,8,dispatch);
        Zone("Zone_Truck_Apron", "TRUCK APRON | Z -15 TO 0",47,-7.5f,26,15,dock);

        // Office enclosure within planning bounds; front and side partitions leave a clear entry.
        Box("Office West Partition",architecture,new Vector3(2,1.5f,34.5f),new Vector3(.15f,3,7),office);
        Box("Office North Partition",architecture,new Vector3(7.5f,1.5f,38),new Vector3(11,3,.15f),office);
        Box("Office East Partition",architecture,new Vector3(13,1.5f,34.5f),new Vector3(.15f,3,7),office);
        Box("Office Glass/Low South Partition",architecture,new Vector3(7.5f,1.1f,31),new Vector3(11,2.2f,.15f),office);
        Box("Receiving Rear Partition",architecture,new Vector3(22,1.1f,38),new Vector3(16,.2f,.15f),receiving);
        // Five longitudinal rack footprint placeholders, 2.3 m wide and 20 m long.
        float[] rackX={4.5f,10f,15.5f,21f,26.5f};
        for(int i=0;i<rackX.Length;i++)
        {
            var row=Group("Rack_Row_"+(i+1),storage);
            Box("Rack footprint 2.3x20m",row,new Vector3(rackX[i],.08f,18),new Vector3(2.3f,.16f,20),rack);
            for(int z=9;z<=27;z+=3) Box("Bay marker Z"+z,row,new Vector3(rackX[i],.22f,z),new Vector3(2.3f,.12f,.12f),dock);
        }
        // Receiving pallets, sorting/conveyor strip, packing benches and dispatch staging pads.
        for(int x=16;x<=28;x+=4) Box("Receiving pallet pad X"+x,logistics,new Vector3(x,.08f,34),new Vector3(2.2f,.16f,2),receiving);
        Box("Conveyor footprint",logistics,new Vector3(47,.22f,24),new Vector3(14,.35f,1.5f),sorting);
        for(int x=41;x<=53;x+=4) Box("Sorting work cell X"+x,logistics,new Vector3(x,.12f,21),new Vector3(2.4f,.24f,2),sorting);
        for(int x=41;x<=53;x+=4) Box("Packing table X"+x,logistics,new Vector3(x,.55f,15),new Vector3(2.5f,1.1f,1.2f),packing);
        for(int x=40;x<=56;x+=4) Box("Dispatch pallet lane X"+x,logistics,new Vector3(x,.08f,6),new Vector3(2.5f,.16f,2.5f),dispatch);
        // Dock frames and simple aligned trailer placeholders; aprons remain open for reversing.
        float[] docks={40,47,54};
        for(int i=0;i<3;i++)
        {
            float x=docks[i];
            Box("Dock_"+(i+1)+" platform",logistics,new Vector3(x,.35f,.5f),new Vector3(4,.7f,1.5f),dock);
            Box("Dock_"+(i+1)+" left jamb",logistics,new Vector3(x-2,2.1f,.1f),new Vector3(.2f,3.5f,.25f),dock);
            Box("Dock_"+(i+1)+" right jamb",logistics,new Vector3(x+2,2.1f,.1f),new Vector3(.2f,3.5f,.25f),dock);
            Box("Truck_"+(i+1)+" trailer placeholder",exterior,new Vector3(x,.9f,-8),new Vector3(3.4f,3.2f,12),truck);
            Box("Truck_"+(i+1)+" cab placeholder",exterior,new Vector3(x,.8f,-1.5f),new Vector3(3.2f,2.5f,2.5f),dock);
        }
        // Painted lane guides across the main spine and clear perimeter circulation.
        Box("Spine route west edge",zones,new Vector3(31.1f,.03f,20),new Vector3(.12f,.05f,32),route);
        Box("Spine route east edge",zones,new Vector3(36.9f,.03f,20),new Vector3(.12f,.05f,32),route);
        var cam= new GameObject("Warehouse Overview Camera"); cam.transform.SetParent(cameras,false);
        cam.transform.position=new Vector3(78,66,-70); cam.transform.LookAt(new Vector3(30,0,16));
        var camera=cam.AddComponent<Camera>(); camera.name="Warehouse Overview Camera"; camera.fieldOfView=27; camera.nearClipPlane=.3f; camera.farClipPlane=250;
        camera.clearFlags=CameraClearFlags.SolidColor; camera.backgroundColor=new Color(.16f,.19f,.23f);
        cam.AddComponent<AudioListener>();
        var light=new GameObject("Blockout Directional Light"); light.transform.SetParent(cameras,false);
        light.transform.rotation=Quaternion.Euler(48,-32,0); var l=light.AddComponent<Light>(); l.type=LightType.Directional; l.intensity=1.15f;
        Selection.activeGameObject=root.gameObject;
    }
    static Material Mat(string name,Color color)
    {
        string path=MatPath+name+".mat"; var m=AssetDatabase.LoadAssetAtPath<Material>(path);
        if(!m){ var shader=Shader.Find("Universal Render Pipeline/Lit"); if(!shader) shader=Shader.Find("Standard"); m=new Material(shader); AssetDatabase.CreateAsset(m,path); }
        m.color=color; EditorUtility.SetDirty(m); return m;
    }
    static Transform Group(string name,Transform parent){var g=new GameObject(name); if(parent)g.transform.SetParent(parent,false); return g.transform;}
    static GameObject Box(string name,Transform parent,Vector3 pos,Vector3 size,Material mat)
    {
        var g=GameObject.CreatePrimitive(PrimitiveType.Cube); g.name=name; g.transform.SetParent(parent,false); g.transform.position=pos; g.transform.localScale=size;
        var r=g.GetComponent<Renderer>(); r.sharedMaterial=mat; return g;
    }
    static void Zone(string name,string label,float x,float z,float sx,float sz,Material m)
    {
        var g=Box(name+" | "+label,zones,new Vector3(x,.018f,z),new Vector3(sx,.035f,sz),m);
        var renderer=g.GetComponent<Renderer>(); renderer.shadowCastingMode=UnityEngine.Rendering.ShadowCastingMode.Off;
    }
}
