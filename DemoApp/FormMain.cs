﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            ITileServer[] tileServers = new ITileServer[]
            {               
                new OpenStreetMapTileServer(),
                new StamenTerrainTileServer(),
                new OpenTopoMapServer(),
                new OfflineTileServer(),
            };

            cmbTileServers.Items.AddRange(tileServers);
            cmbTileServers.SelectedIndex = 0;
            
            mapControl.ZoomLevel = 5;
            mapControl.CenterLon = 44.0;
            mapControl.CenterLat = 56.3333333;

            mapControl.Points.Add(new PointF(44.0f, 56.33333f));

            string trackPoints =
                            @"
41.016416,-65.351067
43.199197,-57.340782
44.219062,-53.346624
44.941861,-50.368631
45.518714,-47.879982
46.003496,-45.694137
46.422917,-43.719184
46.792549,-41.901906
47.122431,-40.208186
47.419498,-38.614685
47.688769,-37.104555
47.934033,-35.665225
48.158231,-34.287002
48.363700,-32.962236
48.552339,-31.684768
48.725713,-30.449566
48.885137,-29.252420
49.031728,-28.089844
49.166437,-26.958818
49.290093,-25.856801
49.403421,-24.781568
49.507057,-23.731188
49.601566,-22.703964
49.687450,-21.698409
49.765160,-20.713175
49.835110,-19.747101
49.897662,-18.799104
49.953157,-17.868241
50.001902,-16.953644
50.044180,-16.054527
50.080251,-15.170179
50.110352,-14.299937
50.134713,-13.443219
50.153534,-12.599458
50.167015,-11.768159
50.175328,-10.948844
50.178649,-10.141076
50.177134,-9.344456
50.170933,-8.558605
50.160187,-7.783165
50.145024,-7.017811
50.125578,-6.262230
50.101960,-5.516129
50.074292,-4.779237
50.042671,-4.051289
50.007205,-3.332041
49.967990,-2.621262
49.925120,-1.918725
49.878682,-1.224221
49.828758,-0.537547
49.775436,0.141485
49.718786,0.813065
49.658891,1.477368
49.595812,2.134564
49.529624,2.784818
49.460390,3.428284
49.388176,4.065118
49.313040,4.695463
49.235042,5.319465
49.154234,5.937261
49.070678,6.548984
48.984417,7.154765
48.895511,7.754728
48.803999,8.349000
48.709933,8.937699
48.613356,9.520944
48.514314,10.098848
48.412846,10.671526
48.308995,11.239086
48.202798,11.801635
48.094289,12.359282
47.983514,12.912129
47.870497,13.460280
47.755282,14.003834
47.637893,14.542891
47.518364,15.077550
47.396727,15.607906
47.273010,16.134055
47.147242,16.656091
47.019449,17.174108
46.889658,17.688198
46.757892,18.198452
46.624173,18.704960
46.488531,19.207814
46.350981,19.707101
46.211551,20.202911
46.070254,20.695330
45.927112,21.184448
45.782146,21.670350
45.635371,22.153124
45.486806,22.632855
45.336467,23.109630
45.184364,23.583536
45.030518,24.054657
44.874937,24.523078
44.717639,24.988887
44.558631,25.452166
44.397927,25.913004
44.235536,26.371487
44.071468,26.827698
43.905730,27.281724
43.738333,27.733653
43.569281,28.183571
43.398584,28.631565
43.226244,29.077724
43.052267,29.522133
42.876656,29.964884
42.699414,30.406064
42.520546,30.845766
42.340051,31.284081
42.157929,31.721099
41.974181,32.156915
41.788807,32.591621
41.601801,33.025315
41.413164,33.458090
41.222889,33.890049
41.030972,34.321287
40.837409,34.751908
40.642190,35.182011
40.445311,35.611707
40.246760,36.041097
40.046529,36.470294
39.844604,36.899406
39.640974,37.328547
39.435626,37.757832
39.228546,38.187384
39.019714,38.617322
38.809117,39.047773
38.596735,39.478863
38.382545,39.910728
38.166528,40.343503
37.948658,40.777325
37.728911,41.212345
37.507261,41.648710
37.283676,42.086575
37.058125,42.526105
36.830577,42.967462
36.600995,43.410822
36.369339,43.856366
36.135573,44.304281
35.899651,44.754768
35.661524,45.208027
35.421148,45.664281
35.178466,46.123749
34.933422,46.586668
34.685956,47.053293
34.436004,47.523889
34.183495,47.998722
33.928356,48.478097
33.670505,48.962327
33.409858,49.451736
33.146323,49.946679
32.879798,50.447537
32.610179,50.954706
32.337348,51.468619
32.061179,51.989744
31.781535,52.518582
31.498271,53.055661
31.211221,53.601576
30.920212,54.156961
30.625048,54.722514
30.325516,55.298989
30.021383,55.887228
29.712390,56.488140
29.398246,57.102761
29.078628,57.732225
28.753178,58.377805
28.421486,59.040930
28.083094,59.723230
27.737468,60.426561
27.384007,61.153048
27.022008,61.905162
26.650646,62.685796
26.268953,63.498362
25.875765,64.346951
25.469674,65.236543
25.048939,66.173261
24.611376,67.164831
24.154173,68.221215
23.673603,69.355644
23.164546,70.586307
22.619626,71.939503
22.027510,73.455714
21.369054,75.203536
20.606712,77.317840
19.642072,80.153293
17.549304,87.059551
";

            var track = new List<PointF>();
            var stringPoints = trackPoints.Split('\n').Where(p => !string.IsNullOrWhiteSpace(p)).Select(p => p.Split(','));

            foreach (var sp in stringPoints)
            {
                float lon = float.Parse(sp[1], CultureInfo.InvariantCulture);
                float lat = float.Parse(sp[0], CultureInfo.InvariantCulture);

                track.Add(new PointF(lon, lat));
            }

            mapControl.Tracks.Add(track);
        }

        private void mapControl_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = $"Longitude = {mapControl.MouseLon} / Latitude = {mapControl.MouseLat} / Zoom = {mapControl.ZoomLevel}";
        }

        private void mapControl_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void btnClearCache_Click(object sender, EventArgs e)
        {
            mapControl.ClearCache(true);
            ActiveControl = mapControl;
        }

        private void cmbTileServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            mapControl.TileServer = cmbTileServers.SelectedItem as ITileServer;
            ActiveControl = mapControl;
        }

        private void mapControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mapControl1_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
