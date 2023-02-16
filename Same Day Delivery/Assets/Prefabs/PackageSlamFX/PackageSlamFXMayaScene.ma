//Maya ASCII 2023 scene
//Name: PackageSlamFXMayaScene.ma
//Last modified: Thu, Feb 16, 2023 03:28:20 PM
//Codeset: 1252
requires maya "2023";
currentUnit -l meter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2023";
fileInfo "version" "2023";
fileInfo "cutIdentifier" "202211021031-847a9f9623";
fileInfo "osv" "Windows 10 Home v2009 (Build: 19045)";
fileInfo "UUID" "0059E4F0-4CA9-425B-AB59-CA843434FB00";
createNode transform -s -n "persp";
	rename -uid "ED86E618-4746-34A2-B01D-8BADB6E02B6F";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 1.9479117248953586 0.78241996276452142 0.11402876504986093 ;
	setAttr ".r" -type "double3" -18.938352729620433 443.39999999993773 1.3836060263348186e-14 ;
createNode camera -s -n "perspShape" -p "persp";
	rename -uid "CC8B2B2E-4183-643C-89F1-3988FB6D3FE3";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999993;
	setAttr ".ncp" 0.001;
	setAttr ".fcp" 100;
	setAttr ".fd" 0.05;
	setAttr ".coi" 1.9508711085218284;
	setAttr ".ow" 0.1;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".tp" -type "double3" -1.7881393432617188e-07 40.450860559940338 -2.384185791015625e-07 ;
	setAttr ".hc" -type "string" "viewSet -p %camera";
createNode transform -s -n "top";
	rename -uid "4B24FFFA-482E-83F3-90DE-9C957624190D";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 10.001000000000001 0 ;
	setAttr ".r" -type "double3" -90 0 0 ;
createNode camera -s -n "topShape" -p "top";
	rename -uid "94500C11-454E-F5B1-858C-7FB2BFADD2E9";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".ncp" 0.001;
	setAttr ".fcp" 100;
	setAttr ".fd" 0.05;
	setAttr ".coi" 10.001000000000001;
	setAttr ".ow" 0.3;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
createNode transform -s -n "front";
	rename -uid "C8D07B30-49D7-ED04-DB1A-78919CC42BD0";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 0 0 10.001000000000001 ;
createNode camera -s -n "frontShape" -p "front";
	rename -uid "D7ADDB22-441B-5811-1942-888EF1F3453D";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".ncp" 0.001;
	setAttr ".fcp" 100;
	setAttr ".fd" 0.05;
	setAttr ".coi" 10.001000000000001;
	setAttr ".ow" 0.3;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
createNode transform -s -n "side";
	rename -uid "C940CB6F-46B8-AC0A-9294-EE8BF2C43E27";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 10.001000000000001 0 0 ;
	setAttr ".r" -type "double3" 0 90 0 ;
createNode camera -s -n "sideShape" -p "side";
	rename -uid "2332193D-47F8-BB3D-87F7-0FB3D68868F8";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".ncp" 0.001;
	setAttr ".fcp" 100;
	setAttr ".fd" 0.05;
	setAttr ".coi" 10.001000000000001;
	setAttr ".ow" 0.3;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
createNode transform -n "pTorus1";
	rename -uid "F5466BEA-4D78-5CC5-9CC6-D196873F3713";
	setAttr ".rp" -type "double3" -1.7881393432617187e-09 0 -2.384185791015625e-09 ;
	setAttr ".sp" -type "double3" -1.7881393432617187e-09 0 -2.384185791015625e-09 ;
createNode mesh -n "pTorusShape1" -p "pTorus1";
	rename -uid "1616553F-466C-54D1-8328-C497A069E948";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.49940746906213462 0.063467137515544891 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
createNode mesh -n "polySurfaceShape1" -p "pTorus1";
	rename -uid "0A64302C-4420-9323-8A66-079ACD639D3E";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.49940746906213462 0.063467137515544891 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 147 ".uvst[0].uvsp[0:146]" -type "float2" 0.010887979 0.12007209
		 0.057641085 0.11821993 0.10631793 0.118135 0.15543658 0.11800139 0.20463011 0.11771642
		 0.25382757 0.11735579 0.30302083 0.11696618 0.35221133 0.11656656 0.40140063 0.11616375
		 0.45058945 0.11575978 0.49977806 0.11535548 0.54896653 0.11495101 0.59815478 0.11454626
		 0.64734221 0.11414083 0.69652718 0.11373346 0.74570459 0.11332043 0.79485899 0.11289176
		 0.84394234 0.11242776 0.89280379 0.11192768 0.94096535 0.1116943 0.98689467 0.11411946
		 0.0076576448 0.10250293 0.056819644 0.10096499 0.10607346 0.10094055 0.15532422 0.1007944
		 0.20454699 0.10049733 0.25375053 0.10013124 0.30294493 0.099739514 0.35213557 0.099339209
		 0.40132487 0.098936163 0.45051369 0.098532163 0.49970224 0.098127834 0.54889077 0.097723387
		 0.59807903 0.097318672 0.64726681 0.09691342 0.69645303 0.096506678 0.74563473 0.096095555
		 0.79480439 0.095672689 0.8439433 0.095224999 0.89300877 0.094763003 0.94190735 0.094583414
		 0.99033052 0.096878462 0.0055073774 0.084429853 0.056157585 0.083778374 0.10583412
		 0.083745919 0.15517727 0.083539508 0.20441547 0.083210729 0.25362012 0.082832061
		 0.30281386 0.082435988 0.35200408 0.082034223 0.40119317 0.081630699 0.4503819 0.08122661
		 0.49957046 0.080822252 0.54875892 0.080417834 0.59794736 0.080013178 0.64713556 0.079608403
		 0.69632334 0.079202913 0.74551016 0.078795843 0.79469633 0.078385197 0.84388965 0.077971123
		 0.89313596 0.077583991 0.94262528 0.077462338 0.99285275 0.079029344 0.004904089
		 0.066127501 0.055919793 0.066615961 0.10568785 0.066546254 0.15503374 0.066251926
		 0.2042627 0.065880887 0.25346151 0.065486334 0.3026526 0.065084837 0.35184178 0.064681374
		 0.40103048 0.064277284 0.45021901 0.063873045 0.49940762 0.063468687 0.54859608 0.06306424
		 0.59778458 0.062659822 0.64697331 0.062255524 0.69616246 0.061851732 0.74535358 0.061449878
		 0.79455239 0.061054908 0.84378123 0.060683511 0.89312714 0.060388796 0.94289523 0.060318612
		 0.99391085 0.060806714 0.0059624887 0.047904871 0.056189921 0.049472295 0.10567927
		 0.049351029 0.15492555 0.048964314 0.20411888 0.048550628 0.25330511 0.04814034 0.3024919
		 0.047733627 0.35167959 0.047328465 0.40086785 0.046923868 0.45005623 0.046519481
		 0.49924472 0.046115093 0.54843318 0.045710705 0.59762192 0.045306437 0.64681089 0.044902645
		 0.69600105 0.044500582 0.74519485 0.044104151 0.79439944 0.043725096 0.84363765 0.043395869
		 0.89298075 0.043189071 0.94265729 0.043156229 0.99330741 0.042504333 0.0084847789
		 0.030055724 0.056907859 0.032351159 0.10580655 0.032171957 0.15487209 0.031710409
		 0.20401096 0.031263106 0.25318065 0.030840598 0.30236235 0.030429862 0.35154852 0.030023418
		 0.40073624 0.029618464 0.44992444 0.029213928 0.49911287 0.02880948 0.5483014 0.028405122
		 0.59749013 0.028001003 0.64667934 0.027597658 0.69586998 0.027197026 0.74506432 0.026805006
		 0.79426783 0.026438467 0.84349048 0.02614098 0.89274126 0.025994442 0.94199508 0.025969617
		 0.99115711 0.024431311 0.011920689 0.012814783 0.05784997 0.015240274 0.10601162
		 0.015007339 0.1548731 0.014507614 0.20395648 0.014044039 0.25311092 0.013615809 0.30228832
		 0.013203077 0.35147324 0.012796037 0.4006606 0.012390874 0.44984874 0.011986278 0.49903712
		 0.011581801 0.54822564 0.011177473 0.59741431 0.010773443 0.64660352 0.010370336
		 0.69579393 0.0099704191 0.74498719 0.0095804259 0.79418451 0.0092194006 0.84337801
		 0.0089340135 0.89249665 0.0088000223 0.94117349 0.0087146983 0.98792654 0.0068621859;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 140 ".pt[0:139]" -type "float3"  0.35686412 0.23866007 -0.11595209 
		0.30356675 0.23866007 -0.22055405 0.22055416 0.23866007 -0.30356663 0.11595221 0.23866007 
		-0.35686398 5.1856041e-08 0.23866007 -0.37522897 -0.1159521 0.23866007 -0.35686395 
		-0.22055402 0.23866007 -0.30356658 -0.30356655 0.23866007 -0.22055399 -0.35686389 
		0.23866007 -0.11595205 -0.37522891 0.23866007 6.9141386e-08 -0.35686389 0.23866007 
		0.11595219 -0.30356655 0.23866007 0.2205541 -0.22055396 0.23866007 0.30356663 -0.11595207 
		0.23866007 0.35686398 4.0673349e-08 0.23866007 0.37522897 0.11595214 0.23866007 0.35686395 
		0.22055405 0.23866007 0.3035666 0.30356658 0.23866007 0.22055408 0.35686395 0.23866007 
		0.11595216 0.37522891 0.23866007 6.9141386e-08 0.38737273 0.20658147 -0.12586494 
		0.32951897 0.20658147 -0.2394094 0.23940952 0.20658147 -0.32951882 0.12586504 0.20658147 
		-0.38737258 5.1856041e-08 0.20658147 -0.40730762 -0.12586494 0.20658147 -0.38737255 
		-0.23940939 0.20658147 -0.32951874 -0.32951874 0.20658147 -0.23940933 -0.38737246 
		0.20658147 -0.12586489 -0.40730754 0.20658147 6.9141386e-08 -0.38737246 0.20658147 
		0.12586503 -0.32951871 0.20658147 0.23940945 -0.23940933 0.20658147 0.32951882 -0.12586492 
		0.20658147 0.38737258 3.9717335e-08 0.20658147 0.4073076 0.12586498 0.20658147 0.38737255 
		0.23940939 0.20658147 0.32951877 0.32951874 0.20658147 0.23940943 0.38737246 0.20658147 
		0.12586501 0.40730754 0.20658147 6.9141386e-08 0.40696046 0.16616006 -0.13222937 
		0.34618127 0.16616006 -0.25151527 0.25151542 0.16616006 -0.34618109 0.13222949 0.16616006 
		-0.40696031 5.1856041e-08 0.16616006 -0.42790335 -0.13222939 0.16616006 -0.40696025 
		-0.25151527 0.16616006 -0.34618104 -0.34618104 0.16616006 -0.25151521 -0.40696022 
		0.16616006 -0.13222933 -0.42790329 0.16616006 6.9141386e-08 -0.40696022 0.16616006 
		0.13222946 -0.34618104 0.16616006 0.2515153 -0.25151521 0.16616006 0.34618109 -0.13222934 
		0.16616006 0.40696025 3.9103529e-08 0.16616006 0.42790332 0.13222942 0.16616006 0.40696025 
		0.25151527 0.16616006 0.34618106 0.34618104 0.16616006 0.2515153 0.40696022 0.16616006 
		0.13222945 0.42790329 0.16616006 6.9141386e-08 0.41370994 0.1213526 -0.13442242 0.35192269 
		0.1213526 -0.25568667 0.25568679 0.1213526 -0.35192257 0.13442253 0.1213526 -0.41370979 
		5.1856041e-08 0.1213526 -0.43500018 -0.13442242 0.1213526 -0.41370976 -0.25568664 
		0.1213526 -0.35192245 -0.35192248 0.1213526 -0.25568661 -0.41370967 0.1213526 -0.13442236 
		-0.43500006 0.1213526 6.9141386e-08 -0.41370967 0.1213526 0.1344225 -0.35192245 0.1213526 
		0.25568673 -0.25568661 0.1213526 0.35192254 -0.13442238 0.1213526 0.41370976 3.8892029e-08 
		0.1213526 0.43500018 0.13442245 0.1213526 0.41370973 0.25568664 0.1213526 0.35192248 
		0.35192248 0.1213526 0.2556867 0.41370967 0.1213526 0.13442248 0.43500006 0.1213526 
		6.9141386e-08 0.40696046 0.076545119 -0.13222937 0.34618127 0.076545119 -0.25151527 
		0.25151542 0.076545119 -0.34618109 0.13222949 0.076545119 -0.40696031 5.1856041e-08 
		0.076545119 -0.42790335 -0.13222939 0.076545119 -0.40696025 -0.25151527 0.076545119 
		-0.34618104 -0.34618104 0.076545119 -0.25151521 -0.40696022 0.076545119 -0.13222933 
		-0.42790329 0.076545119 6.9141386e-08 -0.40696022 0.076545119 0.13222946 -0.34618104 
		0.076545119 0.2515153 -0.25151521 0.076545119 0.34618109 -0.13222934 0.076545119 
		0.40696025 3.9103529e-08 0.076545119 0.42790332 0.13222942 0.076545119 0.40696025 
		0.25151527 0.076545119 0.34618106 0.34618104 0.076545119 0.2515153 0.40696022 0.076545119 
		0.13222945 0.42790329 0.076545119 6.9141386e-08 0.38737273 0.036123708 -0.12586494 
		0.32951897 0.036123708 -0.2394094 0.23940952 0.036123708 -0.32951882 0.12586504 0.036123708 
		-0.38737258 5.1856041e-08 0.036123708 -0.40730762 -0.12586494 0.036123708 -0.38737255 
		-0.23940939 0.036123708 -0.32951874 -0.32951874 0.036123708 -0.23940933 -0.38737246 
		0.036123708 -0.12586489 -0.40730754 0.036123708 6.9141386e-08 -0.38737246 0.036123708 
		0.12586503 -0.32951871 0.036123708 0.23940945 -0.23940933 0.036123708 0.32951882 
		-0.12586492 0.036123708 0.38737258 3.9717335e-08 0.036123708 0.4073076 0.12586498 
		0.036123708 0.38737255 0.23940939 0.036123708 0.32951877 0.32951874 0.036123708 0.23940943 
		0.38737246 0.036123708 0.12586501 0.40730754 0.036123708 6.9141386e-08 0.35686415 
		0.0040450864 -0.1159521 0.30356681 0.0040450864 -0.22055408 0.2205542 0.0040450864 
		-0.30356669 0.11595222 0.0040450864 -0.35686401 5.1856041e-08 0.0040450864 -0.375229 
		-0.11595211 0.0040450864 -0.35686398 -0.22055405 0.0040450864 -0.3035666 -0.30356658 
		0.0040450864 -0.22055401 -0.35686395 0.0040450864 -0.11595206 -0.37522897 0.0040450864 
		6.9141386e-08 -0.35686395 0.0040450864 0.11595219 -0.30356655 0.0040450864 0.22055413 
		-0.22055399 0.0040450864 0.30356669 -0.11595208 0.0040450864 0.35686401 4.0673349e-08 
		0.0040450864 0.375229 0.11595215 0.0040450864 0.35686398 0.22055407 0.0040450864 
		0.30356663 0.30356658 0.0040450864 0.2205541 0.35686398 0.0040450864 0.11595219 0.37522897 
		0.0040450864 6.9141386e-08;
	setAttr -s 140 ".vt[0:139]"  0.012305658 0.0040450855 -0.0039983504 0.010467818 0.0040450855 -0.0076053143
		 0.0076053143 0.0040450855 -0.010467818 0.0039983504 0.0040450855 -0.012305656 0 0.0040450855 -0.012938933
		 -0.0039983504 0.0040450855 -0.012305656 -0.0076053129 0.0040450855 -0.010467815 -0.010467814 0.0040450855 -0.0076053124
		 -0.012305653 0.0040450855 -0.003998349 -0.01293893 0.0040450855 0 -0.012305653 0.0040450855 0.003998349
		 -0.010467814 0.0040450855 0.0076053115 -0.0076053115 0.0040450855 0.010467813 -0.003998349 0.0040450855 0.012305652
		 -3.8561004e-10 0.0040450855 0.012938928 0.003998348 0.0040450855 0.012305651 0.0076053101 0.0040450855 0.010467811
		 0.010467811 0.0040450855 0.0076053105 0.012305651 0.0040450855 0.003998348 0.012938926 0.0040450855 0
		 0.013357678 0.0029389269 -0.0043401732 0.01136272 0.0029389269 -0.0082554994 0.0082554994 0.0029389269 -0.011362719
		 0.0043401723 0.0029389269 -0.013357677 0 0.0029389269 -0.014045093 -0.0043401723 0.0029389269 -0.013357677
		 -0.0082554976 0.0029389269 -0.011362717 -0.011362717 0.0029389269 -0.0082554966 -0.013357674 0.0029389269 -0.0043401713
		 -0.014045089 0.0029389269 0 -0.013357674 0.0029389269 0.0043401713 -0.011362716 0.0029389269 0.0082554957
		 -0.0082554957 0.0029389269 0.011362715 -0.0043401713 0.0029389269 0.013357673 -4.1857617e-10 0.0029389269 0.014045087
		 0.00434017 0.0029389269 0.013357672 0.0082554938 0.0029389269 0.011362714 0.011362714 0.0029389269 0.0082554948
		 0.01335767 0.0029389269 0.0043401704 0.014045086 0.0029389269 0 0.014033117 0.0015450853 -0.0045596361
		 0.011937283 0.0015450853 -0.0086729433 0.0086729433 0.0015450853 -0.011937282 0.0045596357 0.0015450853 -0.014033116
		 0 0.0015450853 -0.014755291 -0.0045596357 0.0015450853 -0.014033115 -0.0086729415 0.0015450853 -0.011937279
		 -0.011937278 0.0015450853 -0.0086729405 -0.014033113 0.0015450853 -0.0045596343 -0.014755287 0.0015450853 0
		 -0.014033113 0.0015450853 0.0045596343 -0.011937278 0.0015450853 0.0086729396 -0.0086729396 0.0015450853 0.011937277
		 -0.0045596343 0.0015450853 0.01403311 -4.3974172e-10 0.0015450853 0.014755284 0.0045596333 0.0015450853 0.01403311
		 0.0086729378 0.0015450853 0.011937276 0.011937275 0.0015450853 0.0086729387 0.014033109 0.0015450853 0.0045596333
		 0.014755283 0.0015450853 0 0.014265858 0 -0.0046352581 0.012135264 0 -0.0088167842
		 0.0088167842 0 -0.012135264 0.0046352576 0 -0.014265857 0 0 -0.015000008 -0.0046352576 0 -0.014265856
		 -0.0088167824 0 -0.01213526 -0.01213526 0 -0.0088167824 -0.014265853 0 -0.0046352562
		 -0.015000004 0 0 -0.014265853 0 0.0046352562 -0.012135259 0 0.0088167815 -0.0088167815 0 0.012135258
		 -0.0046352562 0 0.014265851 -4.4703488e-10 0 0.015000003 0.0046352549 0 0.014265849
		 0.0088167796 0 0.012135256 0.012135256 0 0.0088167805 0.014265849 0 0.0046352553
		 0.015000002 0 0 0.014033117 -0.0015450853 -0.0045596361 0.011937283 -0.0015450853 -0.0086729433
		 0.0086729433 -0.0015450853 -0.011937282 0.0045596357 -0.0015450853 -0.014033116 0 -0.0015450853 -0.014755291
		 -0.0045596357 -0.0015450853 -0.014033115 -0.0086729415 -0.0015450853 -0.011937279
		 -0.011937278 -0.0015450853 -0.0086729405 -0.014033113 -0.0015450853 -0.0045596343
		 -0.014755287 -0.0015450853 0 -0.014033113 -0.0015450853 0.0045596343 -0.011937278 -0.0015450853 0.0086729396
		 -0.0086729396 -0.0015450853 0.011937277 -0.0045596343 -0.0015450853 0.01403311 -4.3974172e-10 -0.0015450853 0.014755284
		 0.0045596333 -0.0015450853 0.01403311 0.0086729378 -0.0015450853 0.011937276 0.011937275 -0.0015450853 0.0086729387
		 0.014033109 -0.0015450853 0.0045596333 0.014755283 -0.0015450853 0 0.013357678 -0.0029389272 -0.0043401732
		 0.01136272 -0.0029389272 -0.0082554994 0.0082554994 -0.0029389272 -0.011362719 0.0043401723 -0.0029389272 -0.013357677
		 0 -0.0029389272 -0.014045093 -0.0043401723 -0.0029389272 -0.013357677 -0.0082554976 -0.0029389272 -0.011362717
		 -0.011362717 -0.0029389272 -0.0082554966 -0.013357674 -0.0029389272 -0.0043401713
		 -0.014045089 -0.0029389272 0 -0.013357674 -0.0029389272 0.0043401713 -0.011362716 -0.0029389272 0.0082554957
		 -0.0082554957 -0.0029389272 0.011362715 -0.0043401713 -0.0029389272 0.013357673 -4.1857617e-10 -0.0029389272 0.014045087
		 0.00434017 -0.0029389272 0.013357672 0.0082554938 -0.0029389272 0.011362714 0.011362714 -0.0029389272 0.0082554948
		 0.01335767 -0.0029389272 0.0043401704 0.014045086 -0.0029389272 0 0.012305659 -0.0040450864 -0.0039983508
		 0.010467819 -0.0040450864 -0.0076053157 0.0076053157 -0.0040450864 -0.010467819 0.0039983504 -0.0040450864 -0.012305658
		 0 -0.0040450864 -0.012938933 -0.0039983504 -0.0040450864 -0.012305656 -0.0076053138 -0.0040450864 -0.010467816
		 -0.010467815 -0.0040450864 -0.0076053129 -0.012305655 -0.0040450864 -0.0039983494
		 -0.012938931 -0.0040450864 0 -0.012305655 -0.0040450864 0.0039983494 -0.010467814 -0.0040450864 0.0076053119
		 -0.0076053119 -0.0040450864 0.010467814 -0.0039983494 -0.0040450864 0.012305653 -3.856101e-10 -0.0040450864 0.012938929
		 0.003998348 -0.0040450864 0.012305652 0.0076053105 -0.0040450864 0.010467813 0.010467811 -0.0040450864 0.0076053115
		 0.012305652 -0.0040450864 0.0039983485 0.012938928 -0.0040450864 0;
	setAttr -s 260 ".ed";
	setAttr ".ed[0:165]"  0 1 0 1 2 0 2 3 0 3 4 0 4 5 0 5 6 0 6 7 0 7 8 0 8 9 0
		 9 10 0 10 11 0 11 12 0 12 13 0 13 14 0 14 15 0 15 16 0 16 17 0 17 18 0 18 19 0 19 0 0
		 20 21 1 21 22 1 22 23 1 23 24 1 24 25 1 25 26 1 26 27 1 27 28 1 28 29 1 29 30 1 30 31 1
		 31 32 1 32 33 1 33 34 1 34 35 1 35 36 1 36 37 1 37 38 1 38 39 1 39 20 1 40 41 1 41 42 1
		 42 43 1 43 44 1 44 45 1 45 46 1 46 47 1 47 48 1 48 49 1 49 50 1 50 51 1 51 52 1 52 53 1
		 53 54 1 54 55 1 55 56 1 56 57 1 57 58 1 58 59 1 59 40 1 60 61 1 61 62 1 62 63 1 63 64 1
		 64 65 1 65 66 1 66 67 1 67 68 1 68 69 1 69 70 1 70 71 1 71 72 1 72 73 1 73 74 1 74 75 1
		 75 76 1 76 77 1 77 78 1 78 79 1 79 60 1 80 81 1 81 82 1 82 83 1 83 84 1 84 85 1 85 86 1
		 86 87 1 87 88 1 88 89 1 89 90 1 90 91 1 91 92 1 92 93 1 93 94 1 94 95 1 95 96 1 96 97 1
		 97 98 1 98 99 1 99 80 1 100 101 1 101 102 1 102 103 1 103 104 1 104 105 1 105 106 1
		 106 107 1 107 108 1 108 109 1 109 110 1 110 111 1 111 112 1 112 113 1 113 114 1 114 115 1
		 115 116 1 116 117 1 117 118 1 118 119 1 119 100 1 120 121 0 121 122 0 122 123 0 123 124 0
		 124 125 0 125 126 0 126 127 0 127 128 0 128 129 0 129 130 0 130 131 0 131 132 0 132 133 0
		 133 134 0 134 135 0 135 136 0 136 137 0 137 138 0 138 139 0 139 120 0 0 20 1 1 21 1
		 2 22 1 3 23 1 4 24 1 5 25 1 6 26 1 7 27 1 8 28 1 9 29 1 10 30 1 11 31 1 12 32 1 13 33 1
		 14 34 1 15 35 1 16 36 1 17 37 1 18 38 1 19 39 1 20 40 1 21 41 1 22 42 1 23 43 1 24 44 1
		 25 45 1;
	setAttr ".ed[166:259]" 26 46 1 27 47 1 28 48 1 29 49 1 30 50 1 31 51 1 32 52 1
		 33 53 1 34 54 1 35 55 1 36 56 1 37 57 1 38 58 1 39 59 1 40 60 1 41 61 1 42 62 1 43 63 1
		 44 64 1 45 65 1 46 66 1 47 67 1 48 68 1 49 69 1 50 70 1 51 71 1 52 72 1 53 73 1 54 74 1
		 55 75 1 56 76 1 57 77 1 58 78 1 59 79 1 60 80 1 61 81 1 62 82 1 63 83 1 64 84 1 65 85 1
		 66 86 1 67 87 1 68 88 1 69 89 1 70 90 1 71 91 1 72 92 1 73 93 1 74 94 1 75 95 1 76 96 1
		 77 97 1 78 98 1 79 99 1 80 100 1 81 101 1 82 102 1 83 103 1 84 104 1 85 105 1 86 106 1
		 87 107 1 88 108 1 89 109 1 90 110 1 91 111 1 92 112 1 93 113 1 94 114 1 95 115 1
		 96 116 1 97 117 1 98 118 1 99 119 1 100 120 1 101 121 1 102 122 1 103 123 1 104 124 1
		 105 125 1 106 126 1 107 127 1 108 128 1 109 129 1 110 130 1 111 131 1 112 132 1 113 133 1
		 114 134 1 115 135 1 116 136 1 117 137 1 118 138 1 119 139 1;
	setAttr -s 120 -ch 480 ".fc[0:119]" -type "polyFaces" 
		f 4 -1 140 20 -142
		mu 0 4 1 0 21 22
		f 4 -2 141 21 -143
		mu 0 4 2 1 22 23
		f 4 -3 142 22 -144
		mu 0 4 3 2 23 24
		f 4 -4 143 23 -145
		mu 0 4 4 3 24 25
		f 4 -5 144 24 -146
		mu 0 4 5 4 25 26
		f 4 -6 145 25 -147
		mu 0 4 6 5 26 27
		f 4 -7 146 26 -148
		mu 0 4 7 6 27 28
		f 4 -8 147 27 -149
		mu 0 4 8 7 28 29
		f 4 -9 148 28 -150
		mu 0 4 9 8 29 30
		f 4 -10 149 29 -151
		mu 0 4 10 9 30 31
		f 4 -11 150 30 -152
		mu 0 4 11 10 31 32
		f 4 -12 151 31 -153
		mu 0 4 12 11 32 33
		f 4 -13 152 32 -154
		mu 0 4 13 12 33 34
		f 4 -14 153 33 -155
		mu 0 4 14 13 34 35
		f 4 -15 154 34 -156
		mu 0 4 15 14 35 36
		f 4 -16 155 35 -157
		mu 0 4 16 15 36 37
		f 4 -17 156 36 -158
		mu 0 4 17 16 37 38
		f 4 -18 157 37 -159
		mu 0 4 18 17 38 39
		f 4 -19 158 38 -160
		mu 0 4 19 18 39 40
		f 4 -20 159 39 -141
		mu 0 4 20 19 40 41
		f 4 -21 160 40 -162
		mu 0 4 22 21 42 43
		f 4 -22 161 41 -163
		mu 0 4 23 22 43 44
		f 4 -23 162 42 -164
		mu 0 4 24 23 44 45
		f 4 -24 163 43 -165
		mu 0 4 25 24 45 46
		f 4 -25 164 44 -166
		mu 0 4 26 25 46 47
		f 4 -26 165 45 -167
		mu 0 4 27 26 47 48
		f 4 -27 166 46 -168
		mu 0 4 28 27 48 49
		f 4 -28 167 47 -169
		mu 0 4 29 28 49 50
		f 4 -29 168 48 -170
		mu 0 4 30 29 50 51
		f 4 -30 169 49 -171
		mu 0 4 31 30 51 52
		f 4 -31 170 50 -172
		mu 0 4 32 31 52 53
		f 4 -32 171 51 -173
		mu 0 4 33 32 53 54
		f 4 -33 172 52 -174
		mu 0 4 34 33 54 55
		f 4 -34 173 53 -175
		mu 0 4 35 34 55 56
		f 4 -35 174 54 -176
		mu 0 4 36 35 56 57
		f 4 -36 175 55 -177
		mu 0 4 37 36 57 58
		f 4 -37 176 56 -178
		mu 0 4 38 37 58 59
		f 4 -38 177 57 -179
		mu 0 4 39 38 59 60
		f 4 -39 178 58 -180
		mu 0 4 40 39 60 61
		f 4 -40 179 59 -161
		mu 0 4 41 40 61 62
		f 4 -41 180 60 -182
		mu 0 4 43 42 63 64
		f 4 -42 181 61 -183
		mu 0 4 44 43 64 65
		f 4 -43 182 62 -184
		mu 0 4 45 44 65 66
		f 4 -44 183 63 -185
		mu 0 4 46 45 66 67
		f 4 -45 184 64 -186
		mu 0 4 47 46 67 68
		f 4 -46 185 65 -187
		mu 0 4 48 47 68 69
		f 4 -47 186 66 -188
		mu 0 4 49 48 69 70
		f 4 -48 187 67 -189
		mu 0 4 50 49 70 71
		f 4 -49 188 68 -190
		mu 0 4 51 50 71 72
		f 4 -50 189 69 -191
		mu 0 4 52 51 72 73
		f 4 -51 190 70 -192
		mu 0 4 53 52 73 74
		f 4 -52 191 71 -193
		mu 0 4 54 53 74 75
		f 4 -53 192 72 -194
		mu 0 4 55 54 75 76
		f 4 -54 193 73 -195
		mu 0 4 56 55 76 77
		f 4 -55 194 74 -196
		mu 0 4 57 56 77 78
		f 4 -56 195 75 -197
		mu 0 4 58 57 78 79
		f 4 -57 196 76 -198
		mu 0 4 59 58 79 80
		f 4 -58 197 77 -199
		mu 0 4 60 59 80 81
		f 4 -59 198 78 -200
		mu 0 4 61 60 81 82
		f 4 -60 199 79 -181
		mu 0 4 62 61 82 83
		f 4 -61 200 80 -202
		mu 0 4 64 63 84 85
		f 4 -62 201 81 -203
		mu 0 4 65 64 85 86
		f 4 -63 202 82 -204
		mu 0 4 66 65 86 87
		f 4 -64 203 83 -205
		mu 0 4 67 66 87 88
		f 4 -65 204 84 -206
		mu 0 4 68 67 88 89
		f 4 -66 205 85 -207
		mu 0 4 69 68 89 90
		f 4 -67 206 86 -208
		mu 0 4 70 69 90 91
		f 4 -68 207 87 -209
		mu 0 4 71 70 91 92
		f 4 -69 208 88 -210
		mu 0 4 72 71 92 93
		f 4 -70 209 89 -211
		mu 0 4 73 72 93 94
		f 4 -71 210 90 -212
		mu 0 4 74 73 94 95
		f 4 -72 211 91 -213
		mu 0 4 75 74 95 96
		f 4 -73 212 92 -214
		mu 0 4 76 75 96 97
		f 4 -74 213 93 -215
		mu 0 4 77 76 97 98
		f 4 -75 214 94 -216
		mu 0 4 78 77 98 99
		f 4 -76 215 95 -217
		mu 0 4 79 78 99 100
		f 4 -77 216 96 -218
		mu 0 4 80 79 100 101
		f 4 -78 217 97 -219
		mu 0 4 81 80 101 102
		f 4 -79 218 98 -220
		mu 0 4 82 81 102 103
		f 4 -80 219 99 -201
		mu 0 4 83 82 103 104
		f 4 -81 220 100 -222
		mu 0 4 85 84 105 106
		f 4 -82 221 101 -223
		mu 0 4 86 85 106 107
		f 4 -83 222 102 -224
		mu 0 4 87 86 107 108
		f 4 -84 223 103 -225
		mu 0 4 88 87 108 109
		f 4 -85 224 104 -226
		mu 0 4 89 88 109 110
		f 4 -86 225 105 -227
		mu 0 4 90 89 110 111
		f 4 -87 226 106 -228
		mu 0 4 91 90 111 112
		f 4 -88 227 107 -229
		mu 0 4 92 91 112 113
		f 4 -89 228 108 -230
		mu 0 4 93 92 113 114
		f 4 -90 229 109 -231
		mu 0 4 94 93 114 115
		f 4 -91 230 110 -232
		mu 0 4 95 94 115 116
		f 4 -92 231 111 -233
		mu 0 4 96 95 116 117
		f 4 -93 232 112 -234
		mu 0 4 97 96 117 118
		f 4 -94 233 113 -235
		mu 0 4 98 97 118 119
		f 4 -95 234 114 -236
		mu 0 4 99 98 119 120
		f 4 -96 235 115 -237
		mu 0 4 100 99 120 121
		f 4 -97 236 116 -238
		mu 0 4 101 100 121 122
		f 4 -98 237 117 -239
		mu 0 4 102 101 122 123
		f 4 -99 238 118 -240
		mu 0 4 103 102 123 124
		f 4 -100 239 119 -221
		mu 0 4 104 103 124 125
		f 4 -101 240 120 -242
		mu 0 4 106 105 126 127
		f 4 -102 241 121 -243
		mu 0 4 107 106 127 128
		f 4 -103 242 122 -244
		mu 0 4 108 107 128 129
		f 4 -104 243 123 -245
		mu 0 4 109 108 129 130
		f 4 -105 244 124 -246
		mu 0 4 110 109 130 131
		f 4 -106 245 125 -247
		mu 0 4 111 110 131 132
		f 4 -107 246 126 -248
		mu 0 4 112 111 132 133
		f 4 -108 247 127 -249
		mu 0 4 113 112 133 134
		f 4 -109 248 128 -250
		mu 0 4 114 113 134 135
		f 4 -110 249 129 -251
		mu 0 4 115 114 135 136
		f 4 -111 250 130 -252
		mu 0 4 116 115 136 137
		f 4 -112 251 131 -253
		mu 0 4 117 116 137 138
		f 4 -113 252 132 -254
		mu 0 4 118 117 138 139
		f 4 -114 253 133 -255
		mu 0 4 119 118 139 140
		f 4 -115 254 134 -256
		mu 0 4 120 119 140 141
		f 4 -116 255 135 -257
		mu 0 4 121 120 141 142
		f 4 -117 256 136 -258
		mu 0 4 122 121 142 143
		f 4 -118 257 137 -259
		mu 0 4 123 122 143 144
		f 4 -119 258 138 -260
		mu 0 4 124 123 144 145
		f 4 -120 259 139 -241
		mu 0 4 125 124 145 146;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode lightLinker -s -n "lightLinker1";
	rename -uid "151F5831-4966-1CC4-D17A-FEBB409B2CB0";
	setAttr -s 2 ".lnk";
	setAttr -s 2 ".slnk";
createNode shapeEditorManager -n "shapeEditorManager";
	rename -uid "40289462-4C9E-86CB-D395-8F9FEA135292";
createNode poseInterpolatorManager -n "poseInterpolatorManager";
	rename -uid "F0C5EBE0-4D37-8DD8-FA7A-D999D1224005";
createNode displayLayerManager -n "layerManager";
	rename -uid "29AE6F1B-4374-C4E5-D737-79B15D3052EE";
createNode displayLayer -n "defaultLayer";
	rename -uid "1FB9FB01-4719-9EBB-2B12-91A5B2524CCC";
	setAttr ".ufem" -type "stringArray" 0  ;
createNode renderLayerManager -n "renderLayerManager";
	rename -uid "6BCD1551-495F-ABEF-64A8-C98E0012DB29";
createNode renderLayer -n "defaultRenderLayer";
	rename -uid "BC74FBEE-478C-0815-53B9-6EBD372850B7";
	setAttr ".g" yes;
createNode script -n "uiConfigurationScriptNode";
	rename -uid "A5E4DBA4-4303-3627-A90D-CF9CDBD189C2";
	setAttr ".b" -type "string" (
		"// Maya Mel UI Configuration File.\n//\n//  This script is machine generated.  Edit at your own risk.\n//\n//\n\nglobal string $gMainPane;\nif (`paneLayout -exists $gMainPane`) {\n\n\tglobal int $gUseScenePanelConfig;\n\tint    $useSceneConfig = $gUseScenePanelConfig;\n\tint    $nodeEditorPanelVisible = stringArrayContains(\"nodeEditorPanel1\", `getPanel -vis`);\n\tint    $nodeEditorWorkspaceControlOpen = (`workspaceControl -exists nodeEditorPanel1Window` && `workspaceControl -q -visible nodeEditorPanel1Window`);\n\tint    $menusOkayInPanels = `optionVar -q allowMenusInPanels`;\n\tint    $nVisPanes = `paneLayout -q -nvp $gMainPane`;\n\tint    $nPanes = 0;\n\tstring $editorName;\n\tstring $panelName;\n\tstring $itemFilterName;\n\tstring $panelConfig;\n\n\t//\n\t//  get current state of the UI\n\t//\n\tsceneUIReplacement -update $gMainPane;\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Top View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"|top\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n"
		+ "            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n"
		+ "            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -bluePencil 1\n            -greasePencils 0\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n"
		+ "\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Side View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"|side\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n"
		+ "            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n"
		+ "            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -bluePencil 1\n            -greasePencils 0\n            -shadows 0\n            -captureSequenceNumber -1\n"
		+ "            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Front View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"|front\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n"
		+ "            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n"
		+ "            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n"
		+ "            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -bluePencil 1\n            -greasePencils 0\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1\n            -height 1\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Persp View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"|persp\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n"
		+ "            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 32768\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n"
		+ "            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n"
		+ "            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -bluePencil 1\n            -greasePencils 0\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1362\n            -height 919\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"ToggledOutliner\")) `;\n\tif (\"\" != $panelName) {\n"
		+ "\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"ToggledOutliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -docTag \"isolOutln_fromSeln\" \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 1\n            -showReferenceMembers 1\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n"
		+ "            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -isSet 0\n            -isSetMember 0\n            -showUfeItems 1\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -selectCommand \"print(\\\"\\\")\" \n            -showNamespace 1\n            -showPinIcons 0\n"
		+ "            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            -renderFilterIndex 0\n            -selectionOrder \"chronological\" \n            -expandAttribute 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"Outliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 0\n            -showReferenceMembers 0\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n"
		+ "            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"0\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -showUfeItems 1\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n"
		+ "            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"graphEditor\" (localizedPanelLabel(\"Graph Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n"
		+ "                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n"
		+ "                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -showUfeItems 1\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayValues 0\n                -snapTime \"integer\" \n"
		+ "                -snapValue \"none\" \n                -showPlayRangeShades \"on\" \n                -lockPlayRangeShades \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n                -keyMinScale 1\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -preSelectionHighlight 0\n                -constrainDrag 0\n                -valueLinesToggle 1\n                -highlightAffectedCurves 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dopeSheetPanel\" (localizedPanelLabel(\"Dope Sheet\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n"
		+ "                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n"
		+ "                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -showUfeItems 1\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n"
		+ "                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayValues 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"timeEditorPanel\" (localizedPanelLabel(\"Time Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Time Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"clipEditorPanel\" (localizedPanelLabel(\"Trax Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n"
		+ "\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayValues 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"sequenceEditorPanel\" (localizedPanelLabel(\"Camera Sequencer\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayValues 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 1 \n                $editorName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperGraphPanel\" (localizedPanelLabel(\"Hypergraph Hierarchy\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showConstraintLabels 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n"
		+ "                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperShadePanel\" (localizedPanelLabel(\"Hypershade\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"visorPanel\" (localizedPanelLabel(\"Visor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"nodeEditorPanel\" (localizedPanelLabel(\"Node Editor\")) `;\n\tif ($nodeEditorPanelVisible || $nodeEditorWorkspaceControlOpen) {\n\t\tif (\"\" == $panelName) {\n\t\t\tif ($useSceneConfig) {\n\t\t\t\t$panelName = `scriptedPanel -unParent  -type \"nodeEditorPanel\" -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -copyConnectionsOnPaste 0\n                -connectionStyle \"bezier\" \n                -defaultPinnedState 0\n"
		+ "                -additiveGraphingMode 0\n                -connectedGraphingMode 1\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -showUnitConversions 0\n                -editorMode \"default\" \n                -hasWatchpoint 0\n                $editorName;\n\t\t\t}\n\t\t} else {\n\t\t\t$label = `panel -q -label $panelName`;\n\t\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n"
		+ "                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -copyConnectionsOnPaste 0\n                -connectionStyle \"bezier\" \n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -connectedGraphingMode 1\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n"
		+ "                -extendToShapes 1\n                -showUnitConversions 0\n                -editorMode \"default\" \n                -hasWatchpoint 0\n                $editorName;\n\t\t\tif (!$useSceneConfig) {\n\t\t\t\tpanel -e -l $label $panelName;\n\t\t\t}\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"createNodePanel\" (localizedPanelLabel(\"Create Node\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"polyTexturePlacementPanel\" (localizedPanelLabel(\"UV Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"UV Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"renderWindowPanel\" (localizedPanelLabel(\"Render View\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"shapePanel\" (localizedPanelLabel(\"Shape Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tshapePanel -edit -l (localizedPanelLabel(\"Shape Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"posePanel\" (localizedPanelLabel(\"Pose Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tposePanel -edit -l (localizedPanelLabel(\"Pose Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynRelEdPanel\" (localizedPanelLabel(\"Dynamic Relationships\")) `;\n\tif (\"\" != $panelName) {\n"
		+ "\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"relationshipPanel\" (localizedPanelLabel(\"Relationship Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"referenceEditorPanel\" (localizedPanelLabel(\"Reference Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynPaintScriptedPanelType\" (localizedPanelLabel(\"Paint Effects\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"scriptEditorPanel\" (localizedPanelLabel(\"Script Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"profilerPanel\" (localizedPanelLabel(\"Profiler Tool\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Profiler Tool\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"contentBrowserPanel\" (localizedPanelLabel(\"Content Browser\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Content Browser\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\tif ($useSceneConfig) {\n        string $configName = `getPanel -cwl (localizedPanelLabel(\"Current Layout\"))`;\n        if (\"\" != $configName) {\n\t\t\tpanelConfiguration -edit -label (localizedPanelLabel(\"Current Layout\")) \n\t\t\t\t-userCreated false\n\t\t\t\t-defaultImage \"vacantCell.xP:/\"\n\t\t\t\t-image \"\"\n\t\t\t\t-sc false\n\t\t\t\t-configString \"global string $gMainPane; paneLayout -e -cn \\\"single\\\" -ps 1 100 100 $gMainPane;\"\n\t\t\t\t-removeAllPanels\n\t\t\t\t-ap true\n\t\t\t\t\t(localizedPanelLabel(\"Persp View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -bluePencil 1\\n    -greasePencils 0\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1362\\n    -height 919\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 32768\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -bluePencil 1\\n    -greasePencils 0\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1362\\n    -height 919\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t$configName;\n\n            setNamedPanelLayout (localizedPanelLabel(\"Current Layout\"));\n        }\n\n        panelHistory -e -clear mainPanelHistory;\n        sceneUIReplacement -clear;\n\t}\n\n\ngrid -spacing 5 -size 12 -divisions 10 -displayAxes yes -displayGridLines yes -displayDivisionLines yes -displayPerspectiveLabels no -displayOrthographicLabels no -displayAxesBold yes -perspectiveLabelPosition axis -orthographicLabelPosition edge;\nviewManip -drawCompass 0 -compassAngle 0 -frontParameters \"\" -homeParameters \"\" -selectionLockParameters \"\";\n}\n");
	setAttr ".st" 3;
createNode script -n "sceneConfigurationScriptNode";
	rename -uid "0EDCE170-4429-2EEF-183E-D7B7DEDFD3BD";
	setAttr ".b" -type "string" "playbackOptions -min 0 -max 120 -ast 0 -aet 200 ";
	setAttr ".st" 6;
createNode polySoftEdge -n "polySoftEdge1";
	rename -uid "440A4369-4C5A-8497-1D35-55BEE4EF21AE";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "e[*]";
	setAttr ".ix" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0 0 0 1;
	setAttr ".a" 180;
createNode polySmoothFace -n "polySmoothFace1";
	rename -uid "4C7C34B1-4ADC-EDC5-4A34-80AC195772A2";
	setAttr ".ics" -type "componentList" 1 "f[*]";
	setAttr ".sdt" 2;
	setAttr ".suv" yes;
	setAttr ".ps" 0.10000000149011612;
	setAttr ".ro" 1;
	setAttr ".ma" yes;
	setAttr ".m08" yes;
select -ne :time1;
	setAttr ".o" 0;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 2 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 5 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :initialShadingGroup;
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultRenderGlobals;
	addAttr -ci true -h true -sn "dss" -ln "defaultSurfaceShader" -dt "string";
	setAttr ".dss" -type "string" "lambert1";
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :defaultColorMgtGlobals;
	setAttr ".cfe" yes;
	setAttr ".cfp" -type "string" "<MAYA_RESOURCES>/OCIO-configs/Maya2022-default/config.ocio";
	setAttr ".vtn" -type "string" "ACES 1.0 SDR-video (sRGB)";
	setAttr ".vn" -type "string" "ACES 1.0 SDR-video";
	setAttr ".dn" -type "string" "sRGB";
	setAttr ".wsn" -type "string" "ACEScg";
	setAttr ".otn" -type "string" "ACES 1.0 SDR-video (sRGB)";
	setAttr ".potn" -type "string" "ACES 1.0 SDR-video (sRGB)";
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
select -ne :ikSystem;
	setAttr -s 4 ".sol";
connectAttr "polySmoothFace1.out" "pTorusShape1.i";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "polySurfaceShape1.o" "polySoftEdge1.ip";
connectAttr "pTorusShape1.wm" "polySoftEdge1.mp";
connectAttr "polySoftEdge1.out" "polySmoothFace1.ip";
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
connectAttr "pTorusShape1.iog" ":initialShadingGroup.dsm" -na;
// End of PackageSlamFXMayaScene.ma
