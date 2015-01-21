using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;


namespace APS168_W32
{

    //ADLINK Struct++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [StructLayout(LayoutKind.Sequential)]
    public struct STR_SAMP_DATA_4CH
    {
        public Int32 tick;
        public Int32 data_0;      //Total channel = 4
        public Int32 data_1;      //Total channel = 4
        public Int32 data_2;      //Total channel = 4
        public Int32 data_3;      //Total channel = 4
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MOVE_PARA
    {
        public Int16 i16_accType;	//Axis parameter
        public Int16 i16_decType;	//Axis parameter
        public Int32 i32_acc;		//Axis parameter
        public Int32 i32_dec;		//Axis parameter
        public Int32 i32_initSpeed;	//Axis parameter
        public Int32 i32_maxSpeed;	//Axis parameter
        public Int32 i32_endSpeed; 	//Axis parameter
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT_DATA
    {
        public Int32 i32_pos;		// Position data (relative or absolute) (pulse)
        public Int16 i16_accType;	// Acceleration pattern 0: T-curve,  1: S-curve
        public Int16 i16_decType;	// Deceleration pattern 0: T-curve,  1: S-curve
        public Int32 i32_acc;		// Acceleration rate ( pulse / ss )
        public Int32 i32_dec;		// Deceleration rate ( pulse / ss )
        public Int32 i32_initSpeed;	// Start velocity	( pulse / s )
        public Int32 i32_maxSpeed;	// Maximum velocity  ( pulse / s )
        public Int32 i32_endSpeed; 	// End velocity		( pulse / s )
        public Int32 i32_angle;		// Arc move angle    ( degree, -360 ~ 360 )
        public Int32 u32_dwell;		// Dwell times       ( unit: ms )
        public Int32 i32_opt;    	// Option //0xABCD , D:0 absolute, 1:relative
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT_DATA2
    {
        public Int32 i32_pos_0;	// Position data (relative or absolute) (pulse) , ArraySize =16
        public Int32 i32_pos_1;	// Position data (relative or absolute) (pulse) , ArraySize =16
        public Int32 i32_pos_2;	// Position data (relative or absolute) (pulse) , ArraySize =16
        public Int32 i32_pos_3;	// Position data (relative or absolute) (pulse) , ArraySize =16
        public Int32 i32_pos_4;	// Position data (relative or absolute) (pulse) , ArraySize =16
        public Int32 i32_pos_5;	// Position data (relative or absolute) (pulse) , ArraySize =16
        public Int32 i32_pos_6;	// Position data (relative or absolute) (pulse) , ArraySize =16
        public Int32 i32_pos_7;	// Position data (relative or absolute) (pulse) , ArraySize =16
        public Int32 i32_pos_8;	// Position data (relative or absolute) (pulse) , ArraySize =16
        public Int32 i32_pos_9;	// Position data (relative or absolute) (pulse) , ArraySize =16
        public Int32 i32_pos_10;	// Position data (relative or absolute) (pulse) , ArraySize =16
        public Int32 i32_pos_11;	// Position data (relative or absolute) (pulse) , ArraySize =16
        public Int32 i32_pos_12;	// Position data (relative or absolute) (pulse) , ArraySize =16
        public Int32 i32_pos_13;	// Position data (relative or absolute) (pulse) , ArraySize =16
        public Int32 i32_pos_14;	// Position data (relative or absolute) (pulse) , ArraySize =16
        public Int32 i32_pos_15;	// Position data (relative or absolute) (pulse) , ArraySize =16

        public Int32 i32_initSpeed;	// Start velocity	( pulse / s ) 
        public Int32 i32_maxSpeed;	// Maximum velocity  ( pulse / s ) 
        public Int32 i32_angle;		// Arc move angle    ( degree, -360 ~ 360 ) 
        public Int32 u32_dwell;		// Dwell times       ( unit: ms ) 
        public Int32 i32_opt;    	// Option //0xABCD , D:0 absolute, 1:relative
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT_DATA3
    {
        public Int32 i32_pos_0;   //Array Size = 4 
        public Int32 i32_pos_1;   //Array Size = 4 
        public Int32 i32_pos_2;   //Array Size = 4 
        public Int32 i32_pos_3;   //Array Size = 4 

        public Int32 i32_maxSpeed;

        public Int32 i32_endPos_0;  //Array Size = 2
        public Int32 i32_endPos_1;  //Array Size = 2

        public Int32 i32_dir;
        public Int32 i32_opt;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct JOG_DATA
    {

        public Int16 i16_jogMode;	// Jog mode. 0:Free running mode, 1:Step mode
        public Int16 i16_dir;		// Jog direction. 0:positive, 1:negative direction
        public Int16 i16_accType;	// Acceleration pattern 0: T-curve,  1: S-curve
        public Int32 i32_acc;		// Acceleration rate ( pulse / ss )
        public Int32 i32_dec;		// Deceleration rate ( pulse / ss )
        public Int32 i32_maxSpeed;	// Positive value, maximum velocity  ( pulse / s )
        public Int32 i32_offset;		// Positive value, a step (pulse)
        public Int32 i32_delayTime;  // Delay time, ( range: 0 ~ 65535 millisecond, align by cycle time)
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HOME_PARA
    {
        public ushort u8_homeMode;
        public ushort u8_homeDir;
        public ushort u8_curveType;
        public Int32 i32_orgOffset;
        public Int32 i32_acceleration;
        public Int32 i32_startVelocity;
        public Int32 i32_maxVelocity;
        public Int32 i32_OrgVelocity;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct FILTER_COEF
    {
        public double a1;			// Biquad filter output polynomial coefficient
        public double a2;			// Biquad filter output polynomial coefficient
        public double b0;			// Biquad filter input polynomial coefficient
        public double b1;			// Biquad filter input polynomial coefficient
        public double b2;			// Biquad filter input polynomial coefficient
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PNT_DATA_2D
    {
        public UInt32 u32_opt;        // option, [0x00000000,0xFFFFFFFF]
        public Int32  i32_x;          // x-axis component (pulse), [-2147483648,2147484647]
        public Int32  i32_y;          // y-axis component (pulse), [-2147483648,2147484647]
        public Int32  i32_theta;      // x-y plane arc move angle (0.001 degree), [-360000,360000]
        public Int32  i32_acc;        // acceleration rate (pulse/ss), [0,2147484647]
        public Int32  i32_dec;        // deceleration rate (pulse/ss), [0,2147484647]
        public Int32  i32_vi;         // initial velocity (pulse/s), [0,2147484647]
        public Int32  i32_vm;         // maximum velocity (pulse/s), [0,2147484647]
        public Int32  i32_ve;         // ending velocity (pulse/s), [0,2147484647]
    }

    // Point table structure (Four dimension)
    [StructLayout(LayoutKind.Sequential)]
    public struct PNT_DATA_4DL
    {
        public UInt32 u32_opt;        // option, [0x00000000,0xFFFFFFFF]
        public Int32  i32_x;          // x-axis component (pulse), [-2147483648,2147484647]
        public Int32  i32_y;          // y-axis component (pulse), [-2147483648,2147484647]
        public Int32  i32_z;          // z-axis component (pulse), [-2147483648,2147484647]
        public Int32  i32_u;          // u-axis component (pulse), [-2147483648,2147484647]
        public Int32  i32_acc;        // acceleration rate (pulse/ss), [0,2147484647]
        public Int32  i32_dec;        // deceleration rate (pulse/ss), [0,2147484647]
        public Int32  i32_vi;         // initial velocity (pulse/s), [0,2147484647]
        public Int32  i32_vm;         // maximum velocity (pulse/s), [0,2147484647]
        public Int32  i32_ve;         // ending velocity (pulse/s), [0,2147484647]
    }

    // Point table structure (One dimension)
    [StructLayout(LayoutKind.Sequential)]
    public struct PNT_DATA
    {
        public UInt32 u32_opt;        // option, [0x00000000,0xFFFFFFFF]
        public Int32  i32_x;          // x-axis component (pulse), [-2147483648,2147484647]
        public Int32  i32_theta;      // x-y plane arc move angle (0.001 degree), [-360000,360000]
        public Int32  i32_acc;        // acceleration rate (pulse/ss), [0,2147484647]
        public Int32  i32_dec;        // deceleration rate (pulse/ss), [0,2147484647]
        public Int32  i32_vi;         // initial velocity (pulse/s), [0,2147484647]
        public Int32  i32_vm;         // maximum velocity (pulse/s), [0,2147484647]
        public Int32  i32_ve;         // ending velocity (pulse/s), [0,2147484647]
    }
    //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++	
	
	public class APS168
	{
		

		// System & Initialization
		[DllImport("APS168.dll")]public static extern Int32  APS_initial( ref System.Int32  BoardID_InBits, System.Int32 Mode );
		[DllImport("APS168.dll")]public static extern Int32  APS_close();
		[DllImport("APS168.dll")]public static extern Int32  APS_version();
		[DllImport("APS168.dll")]public static extern Int32  APS_device_driver_version( System.Int32 Board_ID );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_axis_info( System.Int32 Axis_ID, ref System.Int32 Board_ID, ref System.Int32  Axis_No, ref System.Int32 Port_ID, ref System.Int32  Module_ID );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_board_param( System.Int32 Board_ID, System.Int32 BOD_Param_No, System.Int32 BOD_Param );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_board_param( System.Int32 Board_ID, System.Int32 BOD_Param_No, ref System.Int32  BOD_Param );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_axis_param( System.Int32 Axis_ID, System.Int32 AXS_Param_No, System.Int32  AXS_Param );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_axis_param( System.Int32 Axis_ID, System.Int32 AXS_Param_No, ref System.Int32  AXS_Param );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_watch_timer( System.Int32 Board_ID, ref System.Int32  Timer );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_device_info( System.Int32 Board_ID, System.Int32 Info_No, ref System.Int32  Info );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_card_name( System.Int32 Board_ID, ref System.Int32 CardName );
        [DllImport("APS168.dll")]public static extern Int32  APS_disable_device( System.Int32 DeviceName );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_first_axisId( System.Int32   Board_ID, ref System.Int32  StartAxisID, ref System.Int32  TotalAxisNum );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_security_key( System.Int32   Board_ID, System.Int32   OldPassword, System.Int32   NewPassword );
	    [DllImport("APS168.dll")]public static extern Int32  APS_check_security_key( System.Int32   Board_ID, System.Int32   Password );
		[DllImport("APS168.dll")]public static extern Int32  APS_reset_security_key( System.Int32   Board_ID );
		[DllImport("APS168.dll")]public static extern Int32  APS_load_param_from_file( ref char pXMLFile );
	
		// Flash function [Only for PCI-8253/56, PCI-8392(H)]
		[DllImport("APS168.dll")]public static extern Int32  APS_save_parameter_to_flash( System.Int32 Board_ID );
		[DllImport("APS168.dll")]public static extern Int32  APS_load_parameter_from_flash( System.Int32 Board_ID );
		[DllImport("APS168.dll")]public static extern Int32  APS_load_parameter_from_default( System.Int32 Board_ID );
		
		// SSCNET-3 functions [Only for PCI-8392(H)] 
		[DllImport("APS168.dll")]public static extern Int32  APS_start_sscnet( System.Int32 Board_ID, ref System.Int32  AxisFound_InBits );
		[DllImport("APS168.dll")]public static extern Int32  APS_stop_sscnet( System.Int32 Board_ID );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_sscnet_servo_param( System.Int32 Axis_ID, System.Int32 Para_No1, ref System.Int32  Para_Dat1, System.Int32 Para_No2, ref System.Int32  Para_Dat2 );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_sscnet_servo_param( System.Int32 Axis_ID, System.Int32 Para_No1, System.Int32 Para_Dat1, System.Int32 Para_No2, System.Int32 Para_Dat2 );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_sscnet_servo_alarm( System.Int32 Axis_ID, ref System.Int32  Alarm_No, ref System.Int32  Alarm_Detail );
		[DllImport("APS168.dll")]public static extern Int32  APS_reset_sscnet_servo_alarm( System.Int32 Axis_ID );
		[DllImport("APS168.dll")]public static extern Int32  APS_save_sscnet_servo_param( System.Int32 Board_ID );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_sscnet_servo_abs_position( System.Int32 Axis_ID, ref System.Int32  Cyc_Cnt, ref System.Int32  Res_Cnt );
		[DllImport("APS168.dll")]public static extern Int32  APS_save_sscnet_servo_abs_position( System.Int32 Board_ID );
		[DllImport("APS168.dll")]public static extern Int32  APS_load_sscnet_servo_abs_position( System.Int32 Axis_ID, System.Int32 Abs_Option, ref System.Int32  Cyc_Cnt, ref System.Int32  Res_Cnt );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_sscnet_link_status( System.Int32 Board_ID, ref System.Int32  Link_Status );
	    [DllImport("APS168.dll")]public static extern Int32  APS_set_sscnet_servo_monitor_src( System.Int32 Axis_ID, System.Int32 Mon_No, System.Int32 Mon_Src );
        [DllImport("APS168.dll")]public static extern Int32  APS_get_sscnet_servo_monitor_src( System.Int32 Axis_ID, System.Int32 Mon_No, ref System.Int32 Mon_Src );
        [DllImport("APS168.dll")]public static extern Int32  APS_get_sscnet_servo_monitor_data( System.Int32 Axis_ID, System.Int32 Arr_Size, ref System.Int32 Data_Arr );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_sscnet_control_mode( System.Int32 Axis_ID, System.Int32 Mode );

		// Motion IO & motion status
		[DllImport("APS168.dll")]public static extern Int32  APS_get_command( System.Int32 Axis_ID, ref System.Int32  Command );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_command(System.Int32 Axis_ID, System.Int32 Command);
		[DllImport("APS168.dll")]public static extern Int32  APS_motion_status( System.Int32 Axis_ID );
		[DllImport("APS168.dll")]public static extern Int32  APS_motion_io_status( System.Int32 Axis_ID );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_servo_on( System.Int32 Axis_ID, System.Int32 Servo_On );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_position( System.Int32 Axis_ID, ref System.Int32  Position );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_position(System.Int32 Axis_ID, System.Int32 Position);
		[DllImport("APS168.dll")]public static extern Int32  APS_get_command_velocity(System.Int32 Axis_ID, ref System.Int32  Velocity );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_feedback_velocity(System.Int32 Axis_ID, ref System.Int32  Velocity );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_error_position( System.Int32 Axis_ID, ref System.Int32  Err_Pos );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_target_position( System.Int32 Axis_ID, ref System.Int32 Targ_Pos );
		
		// Single axis motion
		[DllImport("APS168.dll")]public static extern Int32  APS_relative_move( System.Int32 Axis_ID, System.Int32 Distance, System.Int32 Max_Speed );
		[DllImport("APS168.dll")]public static extern Int32  APS_absolute_move( System.Int32 Axis_ID, System.Int32 Position, System.Int32 Max_Speed );
		[DllImport("APS168.dll")]public static extern Int32  APS_velocity_move( System.Int32 Axis_ID, System.Int32 Max_Speed );
		[DllImport("APS168.dll")]public static extern Int32  APS_home_move( System.Int32 Axis_ID );
		[DllImport("APS168.dll")]public static extern Int32  APS_stop_move( System.Int32 Axis_ID );
		[DllImport("APS168.dll")]public static extern Int32  APS_emg_stop( System.Int32 Axis_ID );
		[DllImport("APS168.dll")]public static extern Int32  APS_relative_move2( System.Int32 Axis_ID, System.Int32 Distance, System.Int32 Start_Speed, System.Int32 Max_Speed, System.Int32 End_Speed, System.Int32 Acc_Rate, System.Int32 Dec_Rate );
		[DllImport("APS168.dll")]public static extern Int32  APS_absolute_move2( System.Int32 Axis_ID, System.Int32 Position, System.Int32 Start_Speed, System.Int32 Max_Speed, System.Int32 End_Speed, System.Int32 Acc_Rate, System.Int32 Dec_Rate );
		[DllImport("APS168.dll")]public static extern Int32  APS_home_move2( System.Int32 Axis_ID, System.Int32 Dir, System.Int32 Acc, System.Int32 Start_Speed, System.Int32 Max_Speed, System.Int32 ORG_Speed );

    
		//Simultaneous move [Only for MNET series]
    [DllImport("APS168.dll")]public static extern Int32 APS_set_relative_simultaneous_move( System.Int32 Dimension, ref System.Int32 Axis_ID_Array, ref System.Int32 Distance_Array,ref System.Int32 Max_Speed_Array );
    [DllImport("APS168.dll")]public static extern Int32 APS_set_absolute_simultaneous_move( System.Int32 Dimension, ref System.Int32 Axis_ID_Array, ref System.Int32 Position_Array,ref System.Int32 Max_Speed_Array );
    [DllImport("APS168.dll")]public static extern Int32 APS_start_simultaneous_move(System.Int32 Axis_ID);
    [DllImport("APS168.dll")]public static extern Int32 APS_stop_simultaneous_move(System.Int32 Axis_ID);

    [DllImport("APS168.dll")]public static extern Int32 APS_set_velocity_simultaneous_move( System.Int32 Dimension, ref System.Int32 Axis_ID_Array, ref System.Int32 Max_Speed_Array );
    [DllImport("APS168.dll")]public static extern Int32 APS_Release_simultaneous_move( System.Int32 Axis_ID );
		
		//Override functions [Only for MNET-1XMO/MNET-4XMO/MNET-4XMO-C]
		[DllImport("APS168.dll")]public static extern Int32  APS_speed_override( System.Int32 Axis_ID, System.Int32 MaxSpeed );		
		[DllImport("APS168.dll")]public static extern Int32  APS_relative_move_ovrd( System.Int32 Axis_ID, System.Int32 Distance, System.Int32 Max_Speed );
		[DllImport("APS168.dll")]public static extern Int32  APS_absolute_move_ovrd( System.Int32 Axis_ID, System.Int32 Position, System.Int32 Max_Speed );
	
	
		//JOG functions [Only for PCI-8392, PCI-8253/56]
		[DllImport("APS168.dll")]public static extern Int32  APS_set_jog_param( System.Int32 Axis_ID, ref JOG_DATA pStr_Jog, System.Int32 Mask );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_jog_param( System.Int32 Axis_ID, ref JOG_DATA pStr_Jog );
		[DllImport("APS168.dll")]public static extern Int32  APS_jog_mode_switch( System.Int32 Axis_ID, System.Int32 Turn_No );
		[DllImport("APS168.dll")]public static extern Int32  APS_jog_start( System.Int32 Axis_ID, System.Int32 STA_On );
		
		// Interpolation
		[DllImport("APS168.dll")]public static extern Int32  APS_absolute_linear_move( System.Int32 Dimension, ref System.Int32 Axis_ID_Array, ref System.Int32 Position_Array, System.Int32 Max_Linear_Speed );
		[DllImport("APS168.dll")]public static extern Int32  APS_relative_linear_move( System.Int32 Dimension, ref System.Int32 Axis_ID_Array, ref System.Int32 Distance_Array, System.Int32 Max_Linear_Speed );
		[DllImport("APS168.dll")]public static extern Int32  APS_absolute_arc_move( System.Int32 Dimension, ref System.Int32 Axis_ID_Array, ref System.Int32 Center_Pos_Array, System.Int32 Max_Arc_Speed, System.Int32 Angle );
		[DllImport("APS168.dll")]public static extern Int32  APS_relative_arc_move( System.Int32 Dimension, ref System.Int32 Axis_ID_Array, ref System.Int32 Center_Offset_Array, System.Int32 Max_Arc_Speed, System.Int32 Angle );
		
		// Helical interpolation [Only for PCI-8392, PCI-8253/56]
		[DllImport("APS168.dll")]public static extern Int32   APS_absolute_helix_move( System.Int32   Dimension, ref System.Int32  Axis_ID_Array, ref System.Int32  Center_Pos_Array, System.Int32   Max_Arc_Speed, System.Int32   Pitch, System.Int32   TotalHeight, System.Int32   CwOrCcw );
		[DllImport("APS168.dll")]public static extern Int32   APS_relative_helix_move( System.Int32   Dimension, ref System.Int32  Axis_ID_Array, ref System.Int32  Center_PosOffset_Array, System.Int32   Max_Arc_Speed, System.Int32   Pitch, System.Int32   TotalHeight, System.Int32   CwOrCcw );

		// Circular interpolation( Support 2D and 3D ) [Only for PCI-8392, PCI-8253/56]
		[DllImport("APS168.dll")]public static extern Int32   APS_absolute_arc_move_3pe(System.Int32   Dimension, ref System.Int32  Axis_ID_Array, ref System.Int32  Pass_Pos_Array, ref System.Int32  End_Pos_Array, System.Int32   Max_Arc_Speed );
		[DllImport("APS168.dll")]public static extern Int32   APS_relative_arc_move_3pe(System.Int32   Dimension, ref System.Int32  Axis_ID_Array, ref System.Int32  Pass_PosOffset_Array, ref System.Int32  End_PosOffset_Array, System.Int32   Max_Arc_Speed );

		// Interrupt functions
		[DllImport("APS168.dll")]public static extern Int32  APS_int_enable( System.Int32 Board_ID, System.Int32 Enable );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_int_factor( System.Int32 Board_ID, System.Int32 Item_No, System.Int32 Factor_No, System.Int32 Enable );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_int_factor( System.Int32 Board_ID, System.Int32 Item_No, System.Int32 Factor_No, ref System.Int32 Enable );
		
		[DllImport("APS168.dll")]public static extern Int32  APS_set_field_bus_int_factor_di( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No,     System.Int32 bitsOfCheck );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_int_factor_di( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, ref System.Int32 bitsOfCheck );
			
			//[Only for PCI-7856 motion interrupt]
		[DllImport("APS168.dll")]public static extern Int32  APS_set_field_bus_int_factor_motion( System.Int32 Axis_ID, System.Int32 Factor_No,     System.Int32 Enable );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_int_factor_motion( System.Int32 Axis_ID, System.Int32 Factor_No, ref System.Int32 Enable );
		[DllImport("APS168.dll")]public static extern Int32  APS_reset_field_bus_int_motion(      System.Int32 Axis_ID );
		[DllImport("APS168.dll")]public static extern Int32  APS_wait_field_bus_error_int_motion( System.Int32 Axis_ID, System.Int32 Time_Out );

		[DllImport("APS168.dll")]public static extern IntPtr APS_set_int_factorH(  System.Int32 Board_ID, System.Int32 Item_No, System.Int32 Factor_No, System.Int32 Enable );
	    [DllImport("APS168.dll")]public static extern IntPtr APS_int_no_to_handle( System.Int32 Int_No );
		
		[DllImport("APS168.dll")]public static extern Int32  APS_wait_single_int( System.Int32 Int_No, System.Int32 Time_Out );
		[DllImport("APS168.dll")]public static extern Int32  APS_wait_multiple_int( System.Int32 Int_Count, ref System.Int32 Int_No_Array, System.Int32 Wait_All, System.Int32 Time_Out );
		[DllImport("APS168.dll")]public static extern Int32  APS_reset_int( System.Int32 Int_No );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_int( System.Int32 Int_No );
		//[Only for PCI-8154/58]
		[DllImport("APS168.dll")]public static extern Int32  APS_wait_error_int( System.Int32 Board_ID, System.Int32 Item_No, System.Int32 Time_Out );
		
		// Sampling functions [Only for PCI-8392, PCI-8253/56]
		[DllImport("APS168.dll")]public static extern Int32  APS_set_sampling_param( System.Int32 Board_ID, System.Int32 ParaNum, System.Int32 ParaDat );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_sampling_param( System.Int32 Board_ID, System.Int32 ParaNum, ref System.Int32 ParaDat );
		[DllImport("APS168.dll")]public static extern Int32  APS_wait_trigger_sampling( System.Int32 Board_ID, System.Int32 Length, System.Int32 PretrgLen, System.Int32 TimeOutMs, ref STR_SAMP_DATA_4CH DataArr );
		[DllImport("APS168.dll")]public static extern Int32  APS_wait_trigger_sampling_async( System.Int32 Board_ID, System.Int32 Length, System.Int32 PretrgLen, System.Int32 TimeOutMs, ref STR_SAMP_DATA_4CH DataArr );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_sampling_count( System.Int32 Board_ID, ref System.Int32 SampCnt );
		[DllImport("APS168.dll")]public static extern Int32  APS_stop_wait_sampling( System.Int32 Board_ID );
		
		//DIO & AIO
		[DllImport("APS168.dll")]public static extern Int32  APS_write_d_output(System.Int32 Board_ID, System.Int32 DO_Group, System.Int32 DO_Data);
		[DllImport("APS168.dll")]public static extern Int32  APS_read_d_output(System.Int32 Board_ID, System.Int32 DO_Group, ref System.Int32 DO_Data);
		[DllImport("APS168.dll")]public static extern Int32  APS_read_d_input(System.Int32 Board_ID, System.Int32 DI_Group, ref System.Int32 DI_Data);
		
		[DllImport("APS168.dll")]public static extern Int32  APS_read_a_input_value(System.Int32 Board_ID, System.Int32 Channel_No, ref System.Double Convert_Data);
		[DllImport("APS168.dll")]public static extern Int32  APS_read_a_input_data(System.Int32 Board_ID, System.Int32 Channel_No, ref System.Int32 Raw_Data);
		[DllImport("APS168.dll")]public static extern Int32  APS_write_a_output_value(System.Int32 Board_ID, System.Int32 Channel_No, System.Double  Convert_Data);
		[DllImport("APS168.dll")]public static extern Int32  APS_write_a_output_data(System.Int32 Board_ID, System.Int32 Channel_No, System.Int32 Raw_Data);
		
		//Point table move
		[DllImport("APS168.dll")]public static extern Int32  APS_set_point_table( System.Int32 Axis_ID, System.Int32 Index, ref POINT_DATA Point );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_point_table( System.Int32 Axis_ID, System.Int32 Index, ref POINT_DATA Point );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_running_point_index( System.Int32 Axis_ID, ref System.Int32 Index );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_start_point_index( System.Int32 Axis_ID, ref System.Int32 Index );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_end_point_index( System.Int32 Axis_ID, ref System.Int32 Index );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_table_move_pause( System.Int32 Axis_ID, System.Int32 Pause_en );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_table_move_repeat( System.Int32 Axis_ID, System.Int32 Repeat_en );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_table_move_repeat_count( System.Int32 Axis_ID, ref System.Int32 RepeatCnt );
		[DllImport("APS168.dll")]public static extern Int32  APS_point_table_move( System.Int32 Dimension, ref System.Int32 Axis_ID_Array, System.Int32 StartIndex, System.Int32 EndIndex );
		
		[DllImport("APS168.dll")]public static extern Int32  APS_set_point_tableEx( System.Int32 Axis_ID, ref PNT_DATA pStr_PNT );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_point_table_4DL( ref System.Int32 Axis_ID_Array, System.Int32 Index,  ref PNT_DATA_4DL pStr_PNT_4DL );
		
		//Point table + IO - Pause / Resume
		[DllImport("APS168.dll")]public static extern Int32  APS_set_table_move_ex_pause( System.Int32 Axis_ID );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_table_move_ex_rollback( System.Int32 Axis_ID, System.Int32 Max_Speed );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_table_move_ex_resume( System.Int32 Axis_ID );
		
		//Point table Feeder (Only for PCI-825x)
		[DllImport("APS168.dll")]public static extern Int32  APS_set_feeder_group(         System.Int32 GroupId,     System.Int32 Dimension,  ref System.Int32 Axis_ID_Array );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_feeder_group(         System.Int32 GroupId, ref System.Int32 Dimension,  ref System.Int32 Axis_ID_Array );
		[DllImport("APS168.dll")]public static extern Int32  APS_free_feeder_group(        System.Int32 GroupId                         );
		[DllImport("APS168.dll")]public static extern Int32  APS_reset_feeder_buffer(      System.Int32 GroupId                         );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_feeder_point_2D(      System.Int32 GroupId, ref PNT_DATA_2D pStr_PNT_2D, System.Int32 Size, System.Int32 LastFlag );
		[DllImport("APS168.dll")]public static extern Int32  APS_start_feeder_move(        System.Int32 GroupId                         );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_feeder_running_index( System.Int32 GroupId, ref System.Int32 Index );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_feeder_feed_index(    System.Int32 GroupId, ref System.Int32 Index );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_feeder_ex_pause(      System.Int32 GroupId                         );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_feeder_ex_rollback(   System.Int32 GroupId, System.Int32 Max_Speed );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_feeder_ex_resume(     System.Int32 GroupId                         );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_feeder_cfg_acc_type(  System.Int32 GroupId, System.Int32 Type      );

		//Point table move2
		[DllImport("APS168.dll")]public static extern Int32   APS_set_point_table_mode2( System.Int32   Axis_ID, System.Int32   Mode );
		[DllImport("APS168.dll")]public static extern Int32   APS_set_point_table2( System.Int32   Dimension, ref System.Int32  Axis_ID_Array, System.Int32   Index, ref POINT_DATA2 Point );
		[DllImport("APS168.dll")]public static extern Int32   APS_point_table_continuous_move2( System.Int32   Dimension, ref System.Int32  Axis_ID_Array );
		[DllImport("APS168.dll")]public static extern Int32   APS_point_table_single_move2( System.Int32   Axis_ID, System.Int32   Index );
		[DllImport("APS168.dll")]public static extern Int32   APS_get_running_point_index2( System.Int32   Axis_ID, ref System.Int32  Index );
		[DllImport("APS168.dll")]public static extern Int32   APS_point_table_status2( System.Int32   Axis_ID, ref System.Int32  Status );

		//Point table Only for HSL-4XMO
		[DllImport("APS168.dll")]public static extern Int32   APS_set_point_table3( System.Int32   Dimension, ref System.Int32  Axis_ID_Array, System.Int32   Index, ref POINT_DATA3 Point );
		[DllImport("APS168.dll")]public static extern Int32   APS_point_table_move3( System.Int32   Dimension, ref System.Int32  Axis_ID_Array, System.Int32   StartIndex, System.Int32   EndIndex );
		[DllImport("APS168.dll")]public static extern Int32   APS_set_point_table_param3( System.Int32   FirstAxid, System.Int32   ParaNum, System.Int32   ParaDat );

		// Gantry functions. [Only for PCI-8392, PCI-8253/56]
		[DllImport("APS168.dll")]public static extern Int32  APS_set_gantry_param( System.Int32 Board_ID, System.Int32 GroupNum, System.Int32 ParaNum, System.Int32 ParaDat );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_gantry_param( System.Int32 Board_ID, System.Int32 GroupNum, System.Int32 ParaNum, ref System.Int32 ParaDat );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_gantry_axis( System.Int32 Board_ID, System.Int32 GroupNum, System.Int32 Master_Axis_ID, System.Int32 Slave_Axis_ID );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_gantry_axis( System.Int32 Board_ID, System.Int32 GroupNum, ref System.Int32 Master_Axis_ID, ref System.Int32 Slave_Axis_ID );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_gantry_error( System.Int32 Board_ID, System.Int32 GroupNum, ref System.Int32 GentryError );
		
		// Digital filter functions. [Only for PCI-8253/56]
		[DllImport("APS168.dll")]public static extern Int32   APS_set_filter_param( System.Int32   Axis_ID, System.Int32   Filter_paramNo, System.Int32   param_val );
		[DllImport("APS168.dll")]public static extern Int32   APS_get_filter_param( System.Int32   Axis_ID, System.Int32   Filter_paramNo, ref System.Int32  param_val );
		[DllImport("APS168.dll")]public static extern Int32   APS_manual_set_filter( System.Int32   Axis_ID, FILTER_COEF Coefficient );
		[DllImport("APS168.dll")]public static extern Int32   APS_get_filter_coef( System.Int32   Axis_ID, ref FILTER_COEF Coefficient );

		//Field bus master fucntions For PCI-8392(H)
		[DllImport("APS168.dll")]public static extern Int32  APS_set_field_bus_param( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 BUS_Param_No, System.Int32  BUS_Param );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_param( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 BUS_Param_No, ref System.Int32 BUS_Param );
		[DllImport("APS168.dll")]public static extern Int32  APS_start_field_bus( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 Start_Axis_ID );
		[DllImport("APS168.dll")]public static extern Int32  APS_stop_field_bus( System.Int32 Board_ID, System.Int32 BUS_No );
		
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_device_info( System.Int32   Board_ID, System.Int32   BUS_No, System.Int32   MOD_No, System.Int32   Info_No, ref System.Int32  Info );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_last_scan_info( System.Int32 Board_ID, System.Int32 BUS_No, ref System.Int32 Info_Array, System.Int32 Array_Size, ref System.Int32 Info_Count );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_master_type( System.Int32 Board_ID, System.Int32 BUS_No, ref System.Int32 BUS_Type );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_slave_type( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, ref System.Int32 MOD_Type );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_slave_name( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, ref System.Int32 MOD_Name );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_slave_first_axisno( System.Int32   Board_ID, System.Int32   BUS_No, System.Int32   MOD_No, ref System.Int32  AxisNo, ref System.Int32  TotalAxes );
	
		//Field bus slave general functions
		[DllImport("APS168.dll")]public static extern Int32  APS_set_field_bus_slave_param( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, System.Int32 Ch_No, System.Int32 ParaNum, System.Int32 ParaDat  );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_slave_param( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, System.Int32 Ch_No, System.Int32 ParaNum, ref System.Int32 ParaDat );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_slave_connect_quality( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, ref System.Int32 Sts_data );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_slave_online_status( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, ref System.Int32 Live );

		//Field bus DIO slave fucntions For PCI-8392(H)
		[DllImport("APS168.dll")]public static extern Int32  APS_set_field_bus_d_output( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, System.Int32 DO_Value );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_d_output( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, ref System.Int32 DO_Value );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_d_input( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, ref System.Int32 DI_Value );

		[DllImport("APS168.dll")]public static extern Int32  APS_set_field_bus_d_channel_output( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, System.Int32 Ch_No, System.Int32 DO_Value );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_d_channel_output( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, System.Int32 Ch_No, ref System.Int32 DO_Value );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_d_channel_input(  System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, System.Int32 Ch_No, ref System.Int32 DI_Value );
		
		//Field bus AIO slave function
		[DllImport("APS168.dll")]public static extern Int32  APS_set_field_bus_a_output(     System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, System.Int32 Ch_No, System.Double AO_Value );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_field_bus_a_output_plc( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, System.Int32 Ch_No, System.Double AO_Value, System.Int16 RunStep );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_a_output(     System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, System.Int32 Ch_No, ref System.Double AO_Value );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_a_input(      System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, System.Int32 Ch_No, ref System.Double AI_Value );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_a_input_plc(  System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, System.Int32 Ch_No, ref System.Double AI_Value, System.Int16 RunStep );

		//Field bus Comparing trigger functions
		[DllImport("APS168.dll")]public static extern Int32  APS_set_field_bus_trigger_param( System.Int32   Board_ID, System.Int32   BUS_No, System.Int32   MOD_No, System.Int32   Param_No, System.Int32   Param_Val );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_trigger_param( System.Int32   Board_ID, System.Int32   BUS_No, System.Int32   MOD_No, System.Int32   Param_No, ref System.Int32  Param_Val );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_field_bus_trigger_linear( System.Int32   Board_ID, System.Int32   BUS_No, System.Int32   MOD_No, System.Int32   LCmpCh, System.Int32   StartPoint, System.Int32   RepeatTimes, System.Int32   Interval );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_field_bus_trigger_table( System.Int32   Board_ID, System.Int32   BUS_No, System.Int32   MOD_No, System.Int32   TCmpCh, ref System.Int32  DataArr, System.Int32   ArraySize ); 
		[DllImport("APS168.dll")]public static extern Int32  APS_set_field_bus_trigger_manual( System.Int32   Board_ID, System.Int32   BUS_No, System.Int32   MOD_No, System.Int32   TrgCh );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_field_bus_trigger_manual_s( System.Int32   Board_ID, System.Int32   BUS_No, System.Int32   MOD_No, System.Int32   TrgChInBit );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_trigger_table_cmp( System.Int32   Board_ID, System.Int32   BUS_No, System.Int32   MOD_No, System.Int32   TCmpCh, ref System.Int32  CmpVal );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_trigger_linear_cmp( System.Int32   Board_ID, System.Int32   BUS_No, System.Int32   MOD_No, System.Int32   LCmpCh, ref System.Int32  CmpVal );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_trigger_count( System.Int32   Board_ID, System.Int32   BUS_No, System.Int32   MOD_No, System.Int32   TrgCh, ref System.Int32  TrgCnt );
		[DllImport("APS168.dll")]public static extern Int32  APS_reset_field_bus_trigger_count( System.Int32   Board_ID, System.Int32   BUS_No, System.Int32   MOD_No, System.Int32   TrgCh );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_linear_cmp_remain_count( System.Int32   Board_ID, System.Int32   BUS_No, System.Int32   MOD_No, System.Int32   LCmpCh, ref System.Int32  Cnt );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_table_cmp_remain_count( System.Int32   Board_ID, System.Int32   BUS_No, System.Int32   MOD_No, System.Int32   TCmpCh, ref System.Int32  Cnt );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_field_bus_encoder( System.Int32   Board_ID, System.Int32   BUS_No, System.Int32   MOD_No, System.Int32   EncCh, ref System.Int32  EncCnt );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_field_bus_encoder( System.Int32   Board_ID, System.Int32   BUS_No, System.Int32   MOD_No, System.Int32   EncCh, System.Int32   EncCnt );

		// Comparing trigger functions
		[DllImport("APS168.dll")]public static extern Int32  APS_set_trigger_param( System.Int32 Board_ID, System.Int32 Param_No, System.Int32 Param_Val );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_trigger_param( System.Int32 Board_ID, System.Int32 Param_No, ref System.Int32 Param_Val );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_trigger_linear( System.Int32 Board_ID, System.Int32 LCmpCh, System.Int32 StartPoint, System.Int32 RepeatTimes, System.Int32 Interval );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_trigger_table( System.Int32 Board_ID, System.Int32 TCmpCh, ref System.Int32 DataArr, System.Int32 ArraySize ); 
		[DllImport("APS168.dll")]public static extern Int32  APS_set_trigger_manual( System.Int32 Board_ID, System.Int32 TrgCh );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_trigger_manual_s( System.Int32 Board_ID, System.Int32 TrgChInBit );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_trigger_table_cmp( System.Int32 Board_ID, System.Int32 TCmpCh, ref System.Int32 CmpVal );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_trigger_linear_cmp( System.Int32 Board_ID, System.Int32 LCmpCh, ref System.Int32 CmpVal );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_trigger_count( System.Int32 Board_ID, System.Int32 TrgCh, ref System.Int32 TrgCnt );
		[DllImport("APS168.dll")]public static extern Int32  APS_reset_trigger_count( System.Int32 Board_ID, System.Int32 TrgCh );
	
		// Pulser counter function
		[DllImport("APS168.dll")]public static extern Int32  APS_get_pulser_counter( System.Int32 Board_ID, ref System.Int32 Counter );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_pulser_counter( System.Int32 Board_ID, System.Int32 Counter );
		
		// Reserved functions
		[DllImport("APS168.dll")]public static extern Int32  APS_field_bus_slave_set_param( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, System.Int32 Ch_No, System.Int32 ParaNum, System.Int32 ParaDat  );
		[DllImport("APS168.dll")]public static extern Int32  APS_field_bus_slave_get_param( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, System.Int32 Ch_No, System.Int32 ParaNum, ref System.Int32 ParaDat );
	
		[DllImport("APS168.dll")]public static extern Int32  APS_field_bus_d_set_output( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, System.Int32 DO_Value );
		[DllImport("APS168.dll")]public static extern Int32  APS_field_bus_d_get_output( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, ref System.Int32 DO_Value );
		[DllImport("APS168.dll")]public static extern Int32  APS_field_bus_d_get_input( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, ref System.Int32 DI_Value );
		
		[DllImport("APS168.dll")]public static extern Int32  APS_field_bus_A_set_output(     System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, System.Int32 Ch_No, System.Double     AO_Value );
		[DllImport("APS168.dll")]public static extern Int32  APS_field_bus_A_set_output_plc( System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, System.Int32 Ch_No, System.Double     AO_Value, System.Int16 RunStep );
		[DllImport("APS168.dll")]public static extern Int32  APS_field_bus_A_get_output(     System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, System.Int32 Ch_No, ref System.Double AO_Value );
		[DllImport("APS168.dll")]public static extern Int32  APS_field_bus_A_get_input(      System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, System.Int32 Ch_No, ref System.Double AI_Value );
		[DllImport("APS168.dll")]public static extern Int32  APS_field_bus_A_get_input_plc(  System.Int32 Board_ID, System.Int32 BUS_No, System.Int32 MOD_No, System.Int32 Ch_No, ref System.Double AI_Value, System.Int16 RunStep );
		
		//Dpac Function
		[DllImport("APS168.dll")]public static extern Int32  APS_rescan_CF( System.Int32 Board_ID );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_battery_status( System.Int32 Board_ID, ref System.Int32 Battery_status);
		
		//DPAC Display & Display Button
		[DllImport("APS168.dll")]public static extern Int32  APS_get_display_data( System.Int32 Board_ID, System.Int32 displayDigit, ref System.Int32 displayIndex);
		[DllImport("APS168.dll")]public static extern Int32  APS_set_display_data( System.Int32 Board_ID, System.Int32 displayDigit, System.Int32 displayIndex);
		[DllImport("APS168.dll")]public static extern Int32  APS_get_button_status( System.Int32 Board_ID, ref System.Int32 buttonstatus);
		
		//nv RAM funciton
		[DllImport("APS168.dll")]public static extern Int32  APS_set_nv_ram( System.Int32 Board_ID, System.Int32 RamNo, System.Int32 DataWidth, System.Int32 Offset, System.Int32 Data );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_nv_ram( System.Int32 Board_ID, System.Int32 RamNo, System.Int32 DataWidth, System.Int32 Offset, ref System.Int32 Data );
		[DllImport("APS168.dll")]public static extern Int32  APS_clear_nv_ram( System.Int32 Board_ID, System.Int32 RamNo );
		
		
		
		//VAO function(Laser function) [Only for PCI-8256]
		[DllImport("APS168.dll")]public static extern Int32  APS_set_vao_param( System.Int32 Board_ID, System.Int32 Param_No,     System.Int32 Param_Val );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_vao_param( System.Int32 Board_ID, System.Int32 Param_No, ref System.Int32 Param_Val );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_vao_table( System.Int32 Board_ID, System.Int32 TableNum,     System.Int32 MinVelocity, System.Int32 VelInterval, System.Int32 TotalPoints, ref System.Int32 MappingDataArray );
		[DllImport("APS168.dll")]public static extern Int32  APS_start_vao(     System.Int32 Board_ID, System.Int32 TableNum,     System.Int32 Enable    );

		//PWM function
		[DllImport("APS168.dll")]public static extern Int32  APS_set_pwm_width(     System.Int32 Board_ID, System.Int32 PWM_Ch,     System.Int32 Width     );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_pwm_width(     System.Int32 Board_ID, System.Int32 PWM_Ch, ref System.Int32 Width     );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_pwm_frequency( System.Int32 Board_ID, System.Int32 PWM_Ch,     System.Int32 Frequency );
		[DllImport("APS168.dll")]public static extern Int32  APS_get_pwm_frequency( System.Int32 Board_ID, System.Int32 PWM_Ch, ref System.Int32 Frequency );
		[DllImport("APS168.dll")]public static extern Int32  APS_set_pwm_on(        System.Int32 Board_ID, System.Int32 PWM_Ch,     System.Int32 PWM_On    );


        internal static int APS_get_field_bus_a_output(int CardID, int BusNo, int moduleAO, int i, ref int AO_Value)
        {
            throw new NotImplementedException();
        }
    }
}