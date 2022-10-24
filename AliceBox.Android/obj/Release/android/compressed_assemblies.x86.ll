; ModuleID = 'obj/Release/android/compressed_assemblies.x86.ll'
source_filename = "obj/Release/android/compressed_assemblies.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android"


%struct.CompressedAssemblyDescriptor = type {
	i32,; uint32_t uncompressed_file_size
	i8,; bool loaded
	i8*; uint8_t* data
}

%struct.CompressedAssemblies = type {
	i32,; uint32_t count
	%struct.CompressedAssemblyDescriptor*; CompressedAssemblyDescriptor* descriptors
}
@__CompressedAssemblyDescriptor_data_0 = internal global [322560 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_1 = internal global [53248 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_2 = internal global [27024 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_3 = internal global [203776 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_4 = internal global [30067712 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_5 = internal global [241664 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_6 = internal global [5120 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_7 = internal global [10240 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_8 = internal global [258560 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_9 = internal global [1084928 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_10 = internal global [29696 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_11 = internal global [1926144 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_12 = internal global [161280 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_13 = internal global [18432 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_14 = internal global [115712 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_15 = internal global [4608 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_16 = internal global [282624 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_17 = internal global [12288 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_18 = internal global [119808 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_19 = internal global [866816 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_20 = internal global [12288 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_21 = internal global [218624 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_22 = internal global [32256 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_23 = internal global [214528 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_24 = internal global [137728 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_25 = internal global [2442752 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_26 = internal global [1959936 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_27 = internal global [29064 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_28 = internal global [25472 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_29 = internal global [149904 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_30 = internal global [65928 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_31 = internal global [1028608 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_32 = internal global [30608 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_33 = internal global [24448 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_34 = internal global [22408 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_35 = internal global [284536 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_36 = internal global [30088 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_37 = internal global [74104 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_38 = internal global [101760 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_39 = internal global [1404792 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_40 = internal global [56712 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_41 = internal global [63368 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_42 = internal global [28040 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_43 = internal global [59272 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_44 = internal global [258440 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_45 = internal global [21896 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_46 = internal global [34184 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_47 = internal global [18824 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_48 = internal global [14216 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_49 = internal global [42384 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_50 = internal global [30088 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_51 = internal global [24456 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_52 = internal global [25488 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_53 = internal global [32648 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_54 = internal global [19848 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_55 = internal global [61832 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_56 = internal global [18824 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_57 = internal global [382344 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_58 = internal global [14216 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_59 = internal global [22400 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_60 = internal global [563592 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_61 = internal global [29064 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_62 = internal global [43400 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_63 = internal global [66440 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_64 = internal global [139776 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_65 = internal global [44424 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_66 = internal global [31112 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_67 = internal global [106896 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_68 = internal global [83336 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_69 = internal global [53128 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_70 = internal global [217504 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_71 = internal global [1222032 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_72 = internal global [865792 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_73 = internal global [189328 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_74 = internal global [113552 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_75 = internal global [1520128 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_76 = internal global [18072 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_77 = internal global [4504576 x i8] zeroinitializer, align 1
@__CompressedAssemblyDescriptor_data_78 = internal global [90624 x i8] zeroinitializer, align 1


; Compressed assembly data storage
@compressed_assembly_descriptors = internal global [79 x %struct.CompressedAssemblyDescriptor] [
	; 0
	%struct.CompressedAssemblyDescriptor {
		i32 322560, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([322560 x i8], [322560 x i8]* @__CompressedAssemblyDescriptor_data_0, i32 0, i32 0); data
	}, 
	; 1
	%struct.CompressedAssemblyDescriptor {
		i32 53248, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([53248 x i8], [53248 x i8]* @__CompressedAssemblyDescriptor_data_1, i32 0, i32 0); data
	}, 
	; 2
	%struct.CompressedAssemblyDescriptor {
		i32 27024, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([27024 x i8], [27024 x i8]* @__CompressedAssemblyDescriptor_data_2, i32 0, i32 0); data
	}, 
	; 3
	%struct.CompressedAssemblyDescriptor {
		i32 203776, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([203776 x i8], [203776 x i8]* @__CompressedAssemblyDescriptor_data_3, i32 0, i32 0); data
	}, 
	; 4
	%struct.CompressedAssemblyDescriptor {
		i32 30067712, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([30067712 x i8], [30067712 x i8]* @__CompressedAssemblyDescriptor_data_4, i32 0, i32 0); data
	}, 
	; 5
	%struct.CompressedAssemblyDescriptor {
		i32 241664, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([241664 x i8], [241664 x i8]* @__CompressedAssemblyDescriptor_data_5, i32 0, i32 0); data
	}, 
	; 6
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([5120 x i8], [5120 x i8]* @__CompressedAssemblyDescriptor_data_6, i32 0, i32 0); data
	}, 
	; 7
	%struct.CompressedAssemblyDescriptor {
		i32 10240, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([10240 x i8], [10240 x i8]* @__CompressedAssemblyDescriptor_data_7, i32 0, i32 0); data
	}, 
	; 8
	%struct.CompressedAssemblyDescriptor {
		i32 258560, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([258560 x i8], [258560 x i8]* @__CompressedAssemblyDescriptor_data_8, i32 0, i32 0); data
	}, 
	; 9
	%struct.CompressedAssemblyDescriptor {
		i32 1084928, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1084928 x i8], [1084928 x i8]* @__CompressedAssemblyDescriptor_data_9, i32 0, i32 0); data
	}, 
	; 10
	%struct.CompressedAssemblyDescriptor {
		i32 29696, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([29696 x i8], [29696 x i8]* @__CompressedAssemblyDescriptor_data_10, i32 0, i32 0); data
	}, 
	; 11
	%struct.CompressedAssemblyDescriptor {
		i32 1926144, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1926144 x i8], [1926144 x i8]* @__CompressedAssemblyDescriptor_data_11, i32 0, i32 0); data
	}, 
	; 12
	%struct.CompressedAssemblyDescriptor {
		i32 161280, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([161280 x i8], [161280 x i8]* @__CompressedAssemblyDescriptor_data_12, i32 0, i32 0); data
	}, 
	; 13
	%struct.CompressedAssemblyDescriptor {
		i32 18432, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([18432 x i8], [18432 x i8]* @__CompressedAssemblyDescriptor_data_13, i32 0, i32 0); data
	}, 
	; 14
	%struct.CompressedAssemblyDescriptor {
		i32 115712, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([115712 x i8], [115712 x i8]* @__CompressedAssemblyDescriptor_data_14, i32 0, i32 0); data
	}, 
	; 15
	%struct.CompressedAssemblyDescriptor {
		i32 4608, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([4608 x i8], [4608 x i8]* @__CompressedAssemblyDescriptor_data_15, i32 0, i32 0); data
	}, 
	; 16
	%struct.CompressedAssemblyDescriptor {
		i32 282624, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([282624 x i8], [282624 x i8]* @__CompressedAssemblyDescriptor_data_16, i32 0, i32 0); data
	}, 
	; 17
	%struct.CompressedAssemblyDescriptor {
		i32 12288, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([12288 x i8], [12288 x i8]* @__CompressedAssemblyDescriptor_data_17, i32 0, i32 0); data
	}, 
	; 18
	%struct.CompressedAssemblyDescriptor {
		i32 119808, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([119808 x i8], [119808 x i8]* @__CompressedAssemblyDescriptor_data_18, i32 0, i32 0); data
	}, 
	; 19
	%struct.CompressedAssemblyDescriptor {
		i32 866816, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([866816 x i8], [866816 x i8]* @__CompressedAssemblyDescriptor_data_19, i32 0, i32 0); data
	}, 
	; 20
	%struct.CompressedAssemblyDescriptor {
		i32 12288, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([12288 x i8], [12288 x i8]* @__CompressedAssemblyDescriptor_data_20, i32 0, i32 0); data
	}, 
	; 21
	%struct.CompressedAssemblyDescriptor {
		i32 218624, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([218624 x i8], [218624 x i8]* @__CompressedAssemblyDescriptor_data_21, i32 0, i32 0); data
	}, 
	; 22
	%struct.CompressedAssemblyDescriptor {
		i32 32256, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([32256 x i8], [32256 x i8]* @__CompressedAssemblyDescriptor_data_22, i32 0, i32 0); data
	}, 
	; 23
	%struct.CompressedAssemblyDescriptor {
		i32 214528, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([214528 x i8], [214528 x i8]* @__CompressedAssemblyDescriptor_data_23, i32 0, i32 0); data
	}, 
	; 24
	%struct.CompressedAssemblyDescriptor {
		i32 137728, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([137728 x i8], [137728 x i8]* @__CompressedAssemblyDescriptor_data_24, i32 0, i32 0); data
	}, 
	; 25
	%struct.CompressedAssemblyDescriptor {
		i32 2442752, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([2442752 x i8], [2442752 x i8]* @__CompressedAssemblyDescriptor_data_25, i32 0, i32 0); data
	}, 
	; 26
	%struct.CompressedAssemblyDescriptor {
		i32 1959936, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1959936 x i8], [1959936 x i8]* @__CompressedAssemblyDescriptor_data_26, i32 0, i32 0); data
	}, 
	; 27
	%struct.CompressedAssemblyDescriptor {
		i32 29064, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([29064 x i8], [29064 x i8]* @__CompressedAssemblyDescriptor_data_27, i32 0, i32 0); data
	}, 
	; 28
	%struct.CompressedAssemblyDescriptor {
		i32 25472, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([25472 x i8], [25472 x i8]* @__CompressedAssemblyDescriptor_data_28, i32 0, i32 0); data
	}, 
	; 29
	%struct.CompressedAssemblyDescriptor {
		i32 149904, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([149904 x i8], [149904 x i8]* @__CompressedAssemblyDescriptor_data_29, i32 0, i32 0); data
	}, 
	; 30
	%struct.CompressedAssemblyDescriptor {
		i32 65928, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([65928 x i8], [65928 x i8]* @__CompressedAssemblyDescriptor_data_30, i32 0, i32 0); data
	}, 
	; 31
	%struct.CompressedAssemblyDescriptor {
		i32 1028608, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1028608 x i8], [1028608 x i8]* @__CompressedAssemblyDescriptor_data_31, i32 0, i32 0); data
	}, 
	; 32
	%struct.CompressedAssemblyDescriptor {
		i32 30608, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([30608 x i8], [30608 x i8]* @__CompressedAssemblyDescriptor_data_32, i32 0, i32 0); data
	}, 
	; 33
	%struct.CompressedAssemblyDescriptor {
		i32 24448, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([24448 x i8], [24448 x i8]* @__CompressedAssemblyDescriptor_data_33, i32 0, i32 0); data
	}, 
	; 34
	%struct.CompressedAssemblyDescriptor {
		i32 22408, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([22408 x i8], [22408 x i8]* @__CompressedAssemblyDescriptor_data_34, i32 0, i32 0); data
	}, 
	; 35
	%struct.CompressedAssemblyDescriptor {
		i32 284536, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([284536 x i8], [284536 x i8]* @__CompressedAssemblyDescriptor_data_35, i32 0, i32 0); data
	}, 
	; 36
	%struct.CompressedAssemblyDescriptor {
		i32 30088, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([30088 x i8], [30088 x i8]* @__CompressedAssemblyDescriptor_data_36, i32 0, i32 0); data
	}, 
	; 37
	%struct.CompressedAssemblyDescriptor {
		i32 74104, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([74104 x i8], [74104 x i8]* @__CompressedAssemblyDescriptor_data_37, i32 0, i32 0); data
	}, 
	; 38
	%struct.CompressedAssemblyDescriptor {
		i32 101760, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([101760 x i8], [101760 x i8]* @__CompressedAssemblyDescriptor_data_38, i32 0, i32 0); data
	}, 
	; 39
	%struct.CompressedAssemblyDescriptor {
		i32 1404792, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1404792 x i8], [1404792 x i8]* @__CompressedAssemblyDescriptor_data_39, i32 0, i32 0); data
	}, 
	; 40
	%struct.CompressedAssemblyDescriptor {
		i32 56712, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([56712 x i8], [56712 x i8]* @__CompressedAssemblyDescriptor_data_40, i32 0, i32 0); data
	}, 
	; 41
	%struct.CompressedAssemblyDescriptor {
		i32 63368, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([63368 x i8], [63368 x i8]* @__CompressedAssemblyDescriptor_data_41, i32 0, i32 0); data
	}, 
	; 42
	%struct.CompressedAssemblyDescriptor {
		i32 28040, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([28040 x i8], [28040 x i8]* @__CompressedAssemblyDescriptor_data_42, i32 0, i32 0); data
	}, 
	; 43
	%struct.CompressedAssemblyDescriptor {
		i32 59272, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([59272 x i8], [59272 x i8]* @__CompressedAssemblyDescriptor_data_43, i32 0, i32 0); data
	}, 
	; 44
	%struct.CompressedAssemblyDescriptor {
		i32 258440, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([258440 x i8], [258440 x i8]* @__CompressedAssemblyDescriptor_data_44, i32 0, i32 0); data
	}, 
	; 45
	%struct.CompressedAssemblyDescriptor {
		i32 21896, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([21896 x i8], [21896 x i8]* @__CompressedAssemblyDescriptor_data_45, i32 0, i32 0); data
	}, 
	; 46
	%struct.CompressedAssemblyDescriptor {
		i32 34184, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([34184 x i8], [34184 x i8]* @__CompressedAssemblyDescriptor_data_46, i32 0, i32 0); data
	}, 
	; 47
	%struct.CompressedAssemblyDescriptor {
		i32 18824, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([18824 x i8], [18824 x i8]* @__CompressedAssemblyDescriptor_data_47, i32 0, i32 0); data
	}, 
	; 48
	%struct.CompressedAssemblyDescriptor {
		i32 14216, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14216 x i8], [14216 x i8]* @__CompressedAssemblyDescriptor_data_48, i32 0, i32 0); data
	}, 
	; 49
	%struct.CompressedAssemblyDescriptor {
		i32 42384, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([42384 x i8], [42384 x i8]* @__CompressedAssemblyDescriptor_data_49, i32 0, i32 0); data
	}, 
	; 50
	%struct.CompressedAssemblyDescriptor {
		i32 30088, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([30088 x i8], [30088 x i8]* @__CompressedAssemblyDescriptor_data_50, i32 0, i32 0); data
	}, 
	; 51
	%struct.CompressedAssemblyDescriptor {
		i32 24456, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([24456 x i8], [24456 x i8]* @__CompressedAssemblyDescriptor_data_51, i32 0, i32 0); data
	}, 
	; 52
	%struct.CompressedAssemblyDescriptor {
		i32 25488, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([25488 x i8], [25488 x i8]* @__CompressedAssemblyDescriptor_data_52, i32 0, i32 0); data
	}, 
	; 53
	%struct.CompressedAssemblyDescriptor {
		i32 32648, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([32648 x i8], [32648 x i8]* @__CompressedAssemblyDescriptor_data_53, i32 0, i32 0); data
	}, 
	; 54
	%struct.CompressedAssemblyDescriptor {
		i32 19848, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([19848 x i8], [19848 x i8]* @__CompressedAssemblyDescriptor_data_54, i32 0, i32 0); data
	}, 
	; 55
	%struct.CompressedAssemblyDescriptor {
		i32 61832, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([61832 x i8], [61832 x i8]* @__CompressedAssemblyDescriptor_data_55, i32 0, i32 0); data
	}, 
	; 56
	%struct.CompressedAssemblyDescriptor {
		i32 18824, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([18824 x i8], [18824 x i8]* @__CompressedAssemblyDescriptor_data_56, i32 0, i32 0); data
	}, 
	; 57
	%struct.CompressedAssemblyDescriptor {
		i32 382344, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([382344 x i8], [382344 x i8]* @__CompressedAssemblyDescriptor_data_57, i32 0, i32 0); data
	}, 
	; 58
	%struct.CompressedAssemblyDescriptor {
		i32 14216, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([14216 x i8], [14216 x i8]* @__CompressedAssemblyDescriptor_data_58, i32 0, i32 0); data
	}, 
	; 59
	%struct.CompressedAssemblyDescriptor {
		i32 22400, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([22400 x i8], [22400 x i8]* @__CompressedAssemblyDescriptor_data_59, i32 0, i32 0); data
	}, 
	; 60
	%struct.CompressedAssemblyDescriptor {
		i32 563592, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([563592 x i8], [563592 x i8]* @__CompressedAssemblyDescriptor_data_60, i32 0, i32 0); data
	}, 
	; 61
	%struct.CompressedAssemblyDescriptor {
		i32 29064, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([29064 x i8], [29064 x i8]* @__CompressedAssemblyDescriptor_data_61, i32 0, i32 0); data
	}, 
	; 62
	%struct.CompressedAssemblyDescriptor {
		i32 43400, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([43400 x i8], [43400 x i8]* @__CompressedAssemblyDescriptor_data_62, i32 0, i32 0); data
	}, 
	; 63
	%struct.CompressedAssemblyDescriptor {
		i32 66440, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([66440 x i8], [66440 x i8]* @__CompressedAssemblyDescriptor_data_63, i32 0, i32 0); data
	}, 
	; 64
	%struct.CompressedAssemblyDescriptor {
		i32 139776, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([139776 x i8], [139776 x i8]* @__CompressedAssemblyDescriptor_data_64, i32 0, i32 0); data
	}, 
	; 65
	%struct.CompressedAssemblyDescriptor {
		i32 44424, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([44424 x i8], [44424 x i8]* @__CompressedAssemblyDescriptor_data_65, i32 0, i32 0); data
	}, 
	; 66
	%struct.CompressedAssemblyDescriptor {
		i32 31112, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([31112 x i8], [31112 x i8]* @__CompressedAssemblyDescriptor_data_66, i32 0, i32 0); data
	}, 
	; 67
	%struct.CompressedAssemblyDescriptor {
		i32 106896, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([106896 x i8], [106896 x i8]* @__CompressedAssemblyDescriptor_data_67, i32 0, i32 0); data
	}, 
	; 68
	%struct.CompressedAssemblyDescriptor {
		i32 83336, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([83336 x i8], [83336 x i8]* @__CompressedAssemblyDescriptor_data_68, i32 0, i32 0); data
	}, 
	; 69
	%struct.CompressedAssemblyDescriptor {
		i32 53128, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([53128 x i8], [53128 x i8]* @__CompressedAssemblyDescriptor_data_69, i32 0, i32 0); data
	}, 
	; 70
	%struct.CompressedAssemblyDescriptor {
		i32 217504, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([217504 x i8], [217504 x i8]* @__CompressedAssemblyDescriptor_data_70, i32 0, i32 0); data
	}, 
	; 71
	%struct.CompressedAssemblyDescriptor {
		i32 1222032, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1222032 x i8], [1222032 x i8]* @__CompressedAssemblyDescriptor_data_71, i32 0, i32 0); data
	}, 
	; 72
	%struct.CompressedAssemblyDescriptor {
		i32 865792, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([865792 x i8], [865792 x i8]* @__CompressedAssemblyDescriptor_data_72, i32 0, i32 0); data
	}, 
	; 73
	%struct.CompressedAssemblyDescriptor {
		i32 189328, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([189328 x i8], [189328 x i8]* @__CompressedAssemblyDescriptor_data_73, i32 0, i32 0); data
	}, 
	; 74
	%struct.CompressedAssemblyDescriptor {
		i32 113552, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([113552 x i8], [113552 x i8]* @__CompressedAssemblyDescriptor_data_74, i32 0, i32 0); data
	}, 
	; 75
	%struct.CompressedAssemblyDescriptor {
		i32 1520128, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([1520128 x i8], [1520128 x i8]* @__CompressedAssemblyDescriptor_data_75, i32 0, i32 0); data
	}, 
	; 76
	%struct.CompressedAssemblyDescriptor {
		i32 18072, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([18072 x i8], [18072 x i8]* @__CompressedAssemblyDescriptor_data_76, i32 0, i32 0); data
	}, 
	; 77
	%struct.CompressedAssemblyDescriptor {
		i32 4504576, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([4504576 x i8], [4504576 x i8]* @__CompressedAssemblyDescriptor_data_77, i32 0, i32 0); data
	}, 
	; 78
	%struct.CompressedAssemblyDescriptor {
		i32 90624, ; uncompressed_file_size
		i8 0, ; loaded
		i8* getelementptr inbounds ([90624 x i8], [90624 x i8]* @__CompressedAssemblyDescriptor_data_78, i32 0, i32 0); data
	}
], align 4; end of 'compressed_assembly_descriptors' array


; compressed_assemblies
@compressed_assemblies = local_unnamed_addr global %struct.CompressedAssemblies {
	i32 79, ; count
	%struct.CompressedAssemblyDescriptor* getelementptr inbounds ([79 x %struct.CompressedAssemblyDescriptor], [79 x %struct.CompressedAssemblyDescriptor]* @compressed_assembly_descriptors, i32 0, i32 0); descriptors
}, align 4


!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"NumRegisterParameters", i32 0}
!3 = !{!"Xamarin.Android remotes/origin/d17-3 @ 030cd63c06d95a6b0d0f563fe9b9d537f84cb84b"}
