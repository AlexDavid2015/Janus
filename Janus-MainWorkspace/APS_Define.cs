using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;

namespace APS_Define_W32
{
	//[StructLayout(LayoutKind.Sequential)]
	//public struct APS_Define
	//public cla APS_Define
	enum APS_Define
	{
	// Initial option 
				INIT_MANUAL_ID 						= (0x1),	 //CardId manual by dip switch, Input parameter of APS_initial=( cardId, "MODE" ),

	// Board parameter define =(General),
		   	PRB_EMG_LOGIC       			= (0x0),  // Board EMG logic
		   PRB_WDT0_LIMIT							= (0x10),  // Set / Get watch dog limit.
		   PRB_WDT0_COUNTER	    			= (0x11),  // Reset Wdt / Get Wdt_Count_Value
		   PRB_WDT0_UNIT							= (0x12),  // wdt_unit
		   PRB_WDT0_ACTION				    = (0x13),  // wdt_action

		   PRB_TMR0_BASE						  = (0x20),  // Set TMR Value
		   PRB_TMR0_VALUE  	          = (0x21),  // Get timer System.Int32 count value

		   PRB_SYS_TMP_MONITOR				= (0x30),  // Get system temperature monitor data
		   PRB_CPU_TMP_MONITOR				= (0x31),  // Get CPU temperature monitor data
		   PRB_AUX_TMP_MONITOR				= (0x32),  // Get AUX temperature monitor data
	
		   PRB_UART_MULTIPLIER				= (0x40),  // Set UART Multiplier

		   PRB_PSR_MODE						    = (0x90),	// Config pulser mode
		   PRB_PSR_EA_LOGIC						= (0x91),	// Set EA inverted
		   PRB_PSR_EB_LOGIC						= (0x92),	// Set EB inverted

	// Board parameter define =(For PCI-8253/56),
		   PRB_DENOMINATOR					  =(0x80),	// Floating number denominator
	//   PRB_PSR_MODE								=(0x90),	// Config pulser mode
		   PRB_PSR_ENABLE							=(0x91),	// Enable/disable pulser mode
		   PRB_BOOT_SETTING						=(0x100),	// Load motion parameter method when DSP boot

	// Board parameter define =(For PCI-8392 SSCNET), 
		   PRB_SSC_APPLICATION				=(0x10000), // Reserved
		   PRB_SSC_CYCLE_TIME					=(0x10000), // SSCNET cycle time selection=(vaild befor start sscnet),
		   PRB_PARA_INIT_OPT					=(0x00020), // Initial boot mode.
			 PRB_WATCH_DOG_LIMIT				=(0x00010), // Set / Get watch dog limit.
		   PRB_WATCH_DOG_COUNTER			=(0x00011), //Watch dog counter
	// Board parameter define =(For DPAC), 
		   PRB_DPAC_DISPLAY_MODE			=(0x10001), //DPAC Display mode
		   PRB_DPAC_DI_MODE    				=(0x10002), //Set DI pin modes

		   PRB_DPAC_THERMAL_MONITOR_NO     =(0x20001), //DPAC TEST
		   PRB_DPAC_THERMAL_MONITOR_VALUE  =(0x20002), //DPAC TEST

	// Axis parameter define =(General),
		   PRA_EL_LOGIC								=(0x00),	// EL logic
		   PRA_ORG_LOGIC							=(0x01),	// ORG logic
		   PRA_EL_MODE								=(0x02),  // EL stop mode
		   PRA_MDM_CONDI							=(0x03),  // Motion done condition
		   PRA_EL_EXCHANGE						=(0x04),  //PEL, MEL exchange enable

		   PRA_ALM_LOGIC							=(0x04),	// ALM logic [PCI-8253/56 only]
		   PRA_ZSP_LOGIC       				=(0x05),	// ZSP logic [PCI-8253/56 only]
		   PRA_EZ_LOGIC								=(0x06),	// EZ logic  [PCI-8253/56 only]
		   PRA_STP_DEC								=(0x07),	// Stop deceleration
		   PRA_SPEL_EN								=(0x08),	// SPEL Enable
		   PRA_SMEL_EN							  =(0x09),	// SMEL Enable
		   PRA_EFB_POS0								=(0x0A),	// EFB position 0
		   PRA_EFB_POS1								=(0x0B),	// EFB position 1
		   PRA_EFB_CONDI0							=(0x0C),	// EFB position 0 condition 
		   PRA_EFB_CONDI1						  =(0x0D),	// EFB position 1 condition 
		   PRA_EFB_SRC0								=(0x0E),	// EFB position 0 source
		   PRA_EFB_SRC1								=(0x0F),	// EFB position 1 source 
		   PRA_HOME_MODE						  =(0x10),	// home mode
		   PRA_HOME_DIR								=(0x11),	// homing direction
		   PRA_HOME_CURVE							=(0x12),	// homing curve parten=(T or s curve),
		   PRA_HOME_ACC								=(0x13),	// Acceleration deceleration rate	
		   PRA_HOME_VS								=(0x14),	// homing start velocity
		   PRA_HOME_VM								=(0x15),	// homing max velocity
		   PRA_HOME_VA							  =(0x16),	// homing approach velocity	[PCI-8253/56 only]
		   PRA_HOME_EZA								=(0x18),	// EZ alignment enable
		   PRA_HOME_VO								=(0x19),	// Homing leave ORG velocity
		   PRA_HOME_OFFSET					  =(0x1A),	// The escape pulse amounts=(Leaving home by position),
		
		
		   PRA_CURVE								  =(0x20),	// Move curve pattern
		   PRA_ACC										=(0x21),	// Move acceleration
		   PRA_DEC										=(0x22),	// Move deceleration
		   PRA_VS										  =(0x23),	// Move start velocity
		   PRA_VE										  =(0x25),  // Move end velocity
		   PRA_SACC									  =(0x26),  // Scrve acceleration
			 PRA_SDEC									  =(0x27),  // Scrve deceleration

		   PRA_JG_MODE						    =(0x40),	// Jog mode
		   PRA_JG_DIR									=(0x41),	// Jog move direction
		   PRA_JG_CURVE								=(0x42),	// Jog curve parten=(T or s curve),
		   PRA_JG_ACC									=(0x43),	// Jog move acceleration
		   PRA_JG_DEC									=(0x44),	// Jog move deceleration
		   PRA_JG_VM									=(0x45),  // Jog move max velocity
		   PRA_JG_STEP						    =(0x46),	// Jog offset =(For step mode),
		   PRA_JG_DELAY								=(0x47),	// Jog delay =(For step mode),

		   PRA_MDN_DELAY							=(0x50),	// NSTP delay setting
		   PRA_SINP_WDW								=(0x51),	// Soft INP window setting
		   PRA_SINP_STBL							=(0x52),	// Soft INP stable cycle 
		   PRA_SERVO_LOGIC						=(0x53),//  SERVO logic
 
		// Axis parameter define =(For PCI-8253/56),
		   PRA_PLS_IPT_MODE						=(0x80),	// Pulse input mode setting
		   PRA_PLS_OPT_MODE    			  =(0x81),	// Pulse output mode setting
		   PRA_MAX_E_LIMIT					  =(0x82),	// Maximum encoder count limit
		   PRA_ENC_FILTER					    =(0x83),	// Encoder filter 
		   PRA_EGEAR									=(0x84),	// E-Gear ratio

		   PRA_KP_GAIN								=(0x90),	// PID controller Kp gain
		   PRA_KI_GAIN							  =(0x91),	// PID controller Ki gain
		   PRA_KD_GAIN								=(0x92),	// PID controller Kd gain
		   PRA_KFF_GAIN								=(0x93),	// Feed forward Kff gain
		   PRA_KVGTY_GAIN							=(0x94),	// Gantry controller Kvgty gain
		   PRA_KPGTY_GAIN							=(0x95),	// Gantry controller Kpgty gain
		   PRA_IKP_GAIN								=(0x96),	// PID controller Kp gain in torque mode
		   PRA_IKI_GAIN								=(0x97),	// PID controller Ki gain in torque mode
		   PRA_IKD_GAIN								=(0x98),	// PID controller Kd gain in torque mode
		   PRA_IKFF_GAIN							=(0x99),	// Feed forward Kff gain in torque mode

		   PRA_M_INTERFACE						=(0x100),	// Motion System.Int32erface 
		
		   PRA_M_VOL_RANGE						=(0x110),	// Motor voltage input range
		   PRA_M_MAX_SPEED						=(0x111),	// Motor maximum speed 
		   PRA_M_ENC_RES							=(0x112),	// Motor encoder resolution
	
		   PRA_V_OFFSET								=(0x120),	// Voltage offset
		   PRA_DZ_LOW									=(0x121),	// Dead zone low side
		   PRA_DZ_UP									=(0x122),	// Dead zone up side
		   PRA_SAT_LIMIT							=(0x123),	// Voltage saturation output limit
		   PRA_ERR_C_LEVEL						=(0x124),	// Error counter check level
		   PRA_V_INVERSE							=(0x125),	// Output voltage inverse

		   PRA_PSR_LINK								=(0x130), // Connect pulser number
		   PRA_PSR_RATIO							=(0X131), // Set pulser ratio

		   PRA_DA_TYPE								=(0x140),	// DAC output type
		   PRA_CONTROL_MODE						=(0x141),	// Closed loop control mode

		// Axis parameter define =(For PCI-8154/58),
		// Input/Output Mode
		   PRA_PLS_IPT_LOGIC					=(0x200), //Reverse pulse input counting
		   PRA_FEEDBACK_SRC						=(0x201), //Select feedback conter

		//IO Config
		   PRA_ALM_MODE								=(0x210), //ALM Mode
		   PRA_INP_LOGIC							=(0x211), //INP Logic
		   PRA_SD_EN									=(0x212), //SD Enable -- Bit 8
		   PRA_SD_MODE								=(0x213), //SD Mode
		   PRA_SD_LOGIC								=(0x214), //SD Logic
		   PRA_SD_LATCH								=(0x215), //SD Latch
		   PRA_ERC_MODE							  =(0x216), //ERC Mode
		   PRA_ERC_LOGIC							=(0x217), //ERC logic
		   PRA_ERC_LEN								=(0x218), //ERC pulse width
			 PRA_CLR_MODE							  =(0x219), //CLR Mode
			 PRA_CLR_TARGET							=(0x21A), //CLR Target counter
			 PRA_PIN_FLT								=(0x21B), //EA/EB Filter Enable
			 PRA_INP_MODE							  =(0x21C), //INP Mode
			 PRA_LTC_LOGIC							=(0x21D), //LTC LOGIC 
			 PRA_SOFT_PLIMIT						=(0x21E), //SOFT PLIMIT
			 PRA_SOFT_MLIMIT						=(0x21F), //SOFT MLIMIT
			 PRA_SOFT_LIMIT_EN				  =(0x220), //SOFT ENABLE
			 PRA_BACKLASH_PULSE  				=(0x221), //BACKLASH PULSE
			 PRA_BACKLASH_MODE  				=(0x222), //BACKLASH MODE
			 PRA_LTC_SRC		    				=(0x223), //LTC Source
			 PRA_LTC_DEST							  =(0x224), //LTC Destination
			 PRA_LTC_DATA								=(0x225), //Get LTC DATA
			 PRA_GCMP_EN							  =(0x226),	// CMP Enable
			 PRA_GCMP_POS							  =(0x227),	// Get CMP position
			 PRA_GCMP_SRC							  =(0x228),	// CMP source
			 PRA_GCMP_ACTION						=(0x229),	// CMP Action
			 PRA_GCMP_STS							  =(0x22A),	// CMP Status

		   //PRA_ERC_LEN							=(0x230), //ERC pulse width
		   //PRA_CLR_MODE							=(0x231), //CLR Mode
		   //PRA_CLR_TARGET						=(0x232), //CLR Target counter
		   PRA_GPDO_SEL							  =(0x233), //Select DO/CMP Output mode
		   
		//Fixed Speed
		   PRA_SPD_LIMIT							=(0x240), // Set Fixed Speed
		   PRA_MAX_ACCDEC							=(0x241), // Get max acceleration by fixed speed
		   PRA_MIN_ACCDEC							=(0x242), // Get max acceleration by fixed speed
           PRA_ENABLE_SPD                           =(0x243), // Disable/Enable Fixed Speed only for HSL-4XMO.

        //Continuous Move
           PRA_CONTI_MODE                           =(0x250), // Continuous Mode
           PRA_CONTI_BUFF                           =(0x251), // Continuous Buffer
        
		// Axis parameter define =(For PCI-8392 SSCNET),
		   PRA_SSC_SERVO_PARAM_SRC		=(0x10000), //Servo parameter source	
		   PRA_SSC_SERVO_ABS_POS_OPT	=(0x10001), //Absolute position system option
		   PRA_SSC_SERVO_ABS_CYC_CNT	=(0x10002), //Absolute cycle counter of servo driver
		   PRA_SSC_SERVO_ABS_RES_CNT	=(0x10003), //Absolute resolution counter of servo driver
		   PRA_SSC_TORQUE_LIMIT_P 		=(0x10004), //Torque limit positive =(0.1%),
		   PRA_SSC_TORQUE_LIMIT_N			=(0x10005), //Torque limit negative =(0.1%),
		   PRA_SSC_TORQUE_CTRL				=(0x10006), //Torque control
		   PRA_SSC_RESOLUTION					=(0x10007), //resolution =(E-gear),
		   PRA_SSC_GMR					=(0x10008), //resolution =(New E-gear),
		   PRA_SSC_GDR					=(0x10009), //resolution =(New E-gear),

		// Sampling parameter define
		   SAMP_PA_RATE               =(0x0), //Sampling rate
		   SAMP_PA_EDGE               =(0x2), //Edge select
		   SAMP_PA_LEVEL				 			=(0x3), //Level select
		   SAMP_PA_TRIGCH		          =(0x5), //Select trigger channel

		   SAMP_PA_SRC_CH0		        =(0x10), //Sample source of channel 0
		   SAMP_PA_SRC_CH1		        =(0x11), //Sample source of channel 1
		   SAMP_PA_SRC_CH2		        =(0x12), //Sample source of channel 2
		   SAMP_PA_SRC_CH3		        =(0x13), //Sample source of channel 3

		// Sampling source
		   SAMP_AXIS_MASK		          =(0xF00),
		   SAMP_PARAM_MASK		        =(0xFF),
		  	SAMP_COM_POS		       	  =(0x00), //command position
		   SAMP_FBK_POS	              =(0x01), //feedback position
		   SAMP_CMD_VEL		            =(0x02), //command velocity
		   SAMP_FBK_VEL		            =(0x03), //feedback velocity
		   SAMP_MIO			              =(0x04), //motion IO
		   SAMP_MSTS									=(0x05), //motion status
		   SAMP_MSTS_ACC							=(0x06), //motion status acc
		   SAMP_MSTS_MV								=(0x07), //motion status at max velocity
		   SAMP_MSTS_DEC							=(0x08), //motion status at dec
		   SAMP_MSTS_CSTP							=(0x09), //motion status CSTP
		   SAMP_MSTS_NSTP							=(0x0A), //motion status NSTP
		   SAMP_MIO_INP								=(0x0B), //motion status INP
		   SAMP_MIO_ZERO							=(0x0C), //motion status ZERO
		   SAMP_MIO_ORG								=(0x0D), //motion status OGR
	
			 SAMP_SSC_MON_0							=(0x10),  // SSCNET servo monitor ch0
			 SAMP_SSC_MON_1							=(0x11),  // SSCNET servo monitor ch1
			 SAMP_SSC_MON_2							=(0x12),  // SSCNET servo monitor ch2
			 SAMP_SSC_MON_3							=(0x13) , // SSCNET servo monitor ch3

			 SAMP_CONTROL_VOL						=(0x20),  //
			 SAMP_GTY_DEVIATION 			  =(0x21),
			 SAMP_ENCODER_RAW		     	  =(0x22),
			 SAMP_ERROR_COUNTER         =(0x23),
			 
		//FieldBus parameter define
		   PRF_COMMUNICATION_TYPE			=(0x00),// FiledBus Communication Type=(Full/half duplex),
		   PRF_TRANSFER_RATE					=(0x01),// FiledBus Transfer Rate
		   PRF_HUB_NUMBER							=(0x02),// FiledBus Hub Number
			 PRF_INITIAL_TYPE						=(0x03),// FiledBus Initial Type(Clear/Reserve Do area)
		
		//Gantry parameter number define [Only for PCI-8392, PCI-8253/56]
		   GANTRY_MODE								=(0x0),
		   GENTRY_DEVIATION						=(0x1),
		   GENTRY_DEVIATION_STP				=(0x2),
		
		// Filter parameter number define [Only for PCI-8253/56]
			 FTR_TYPE										=(0x00),	// Filter type
			 FTR_FC										  =(0x01),	// Filter cutoff frequency
			 FTR_BW										  =(0x02),	// Filter bandwidth
			 FTR_ENABLE					        =(0x03),	// Filter enable/disable
			 
		// Device name define
		   DEVICE_NAME_NULL			      =(0xFFFF),
		   DEVICE_NAME_PCI_8392		    =(0),
		   DEVICE_NAME_PCI_825X		    =(1),
		   DEVICE_NAME_PCI_8154		    =(2),
		   DEVICE_NAME_PCI_785X		    =(3),
		   DEVICE_NAME_PCI_8158		    =(4),
		   DEVICE_NAME_PCI_7856		    =(5),
		   DEVICE_NAME_ISA_DPAC1000	  =(6),
		   DEVICE_NAME_ISA_DPAC3000	  =(7),
		   DEVICE_NAME_PCI_8144		    =(8),

///////////////////////////////////////////////
//   HSL Slave module definition
///////////////////////////////////////////////
		   SLAVE_NAME_UNKNOWN					=(0x000),
		   SLAVE_NAME_HSL_DI32				=(0x100),
		   SLAVE_NAME_HSL_DO32				=(0x101),
		   SLAVE_NAME_HSL_DI16DO16		=(0x102),
		   SLAVE_NAME_HSL_AO4					=(0x103),
		   SLAVE_NAME_HSL_AI16AO2_VV	=(0x104),
		   SLAVE_NAME_HSL_AI16AO2_AV	=(0x105),
		   SLAVE_NAME_HSL_DI16UL			=(0x106),	
		   SLAVE_NAME_HSL_DI16RO8			=(0x107),
		   SLAVE_NAME_HSL_4XMO				=(0x108),
		
///////////////////////////////////////////////
//   MNET Slave module definition
///////////////////////////////////////////////
		   SLAVE_NAME_MNET_1XMO				=(0x200),
		   SLAVE_NAME_MNET_4XMO				=(0x201),
       SLAVE_NAME_MNET_4XMO_C			=(0x202),
		
//Trigger parameter number define. [Only for PCI-8253/56]
		   TG_LCMP0_SRC								=(0x00),
		   TG_LCMP1_SRC								=(0x01),
		   TG_TCMP0_SRC								=(0x02),
		   TG_TCMP1_SRC								=(0x03),

		   TG_LCMP0_EN		 						=(0x04),
		   TG_LCMP1_EN		 						=(0x05),
		   TG_TCMP0_EN		 						=(0x06),
		   TG_TCMP1_EN		 						=(0x07),

		   TG_TRG0_SRC		 						=(0x10),
		   TG_TRG1_SRC		 						=(0x11),
		   TG_TRG2_SRC		 						=(0x12),
		   TG_TRG3_SRC		 						=(0x13),

		   TG_TRG0_PWD		 						=(0x14),
		   TG_TRG1_PWD		 						=(0x15),
		   TG_TRG2_PWD		 						=(0x16),
		   TG_TRG3_PWD		 						=(0x17),

		   TG_TRG0_CFG		 						=(0x18),
		   TG_TRG1_CFG		 						=(0x19),
		   TG_TRG2_CFG		 						=(0x1A),
		   TG_TRG3_CFG		 						=(0x1B),

		   TMR_ITV     		 						=(0x20),
		   TMR_EN		 		      				=(0x21),
           
       //Trigger parameter number define. [Only for MNET-4XMO-C]
			 TG_CMP0_SRC							 =(0x00),
			 TG_CMP1_SRC							 =(0x01),
			 TG_CMP2_SRC							 =(0x02),
			 TG_CMP3_SRC							 =(0x03),
			 TG_CMP0_EN			           =(0x04),
			 TG_CMP1_EN			           =(0x05),
			 TG_CMP2_EN			           =(0x06),
			 TG_CMP3_EN			           =(0x07),
			 TG_CMP0_TYPE			         =(0x08),
			 TG_CMP1_TYPE			         =(0x09),
			 TG_CMP2_TYPE			         =(0x0A),
			 TG_CMP3_TYPE			         =(0x0B),
			 TG_CMPH_EN			           =(0x0C),
			 TG_CMPH_DIR_EN			       =(0x0D),
			 TG_CMPH_DIR			         =(0x0E),

			 //TG_TRG0_SRC		=	(0x10),
			 //TG_TRG1_SRC		=	(0x11),
			 //TG_TRG2_SRC		=	(0x12),
			 //TG_TRG3_SRC		=	(0x13),
					
			 //TG_TRG0_PWD		=	(0x14),
			 //TG_TRG1_PWD		=	(0x15),
			 //TG_TRG2_PWD		=	(0x16),
			 //TG_TRG3_PWD		=	(0x17),

			 //TG_TRG0_CFG		=	(0x18),
			 //TG_TRG1_CFG		=	(0x19),
			 //TG_TRG2_CFG		=	(0x1A),
			 //TG_TRG3_CFG		=	(0x1B),
		
			 TG_ENCH_CFG							  =(0x20),
			 TG_TRG0_CMP_DIR						=(0x21),
			 TG_TRG1_CMP_DIR						=(0x22),
			 TG_TRG2_CMP_DIR						=(0x23),
			 TG_TRG3_CMP_DIR						=(0x24),

        // Motion IO status bit number define.
       MIO_ALM								    =(0),		// Servo alarm.
       MIO_PEL								    =(1),		// Positive end limit.
       MIO_MEL								    =(2),		// Negative end limit.
       MIO_ORG								    =(3),		// ORG (Home)
       MIO_EMG								    =(4),		// Emergency stop
       MIO_EZ								      =(5),		// EZ.
       MIO_INP								    =(6),		// In position.
       MIO_SVON		     	          =(7),		// Servo on signal.
       MIO_RDY								    =(8),		// Ready.
       MIO_WARN			    	        =(9),		// Warning.
       MIO_ZSP								    =(10),	// Zero speed.
       MIO_SPEL		    		        =(11),	// Soft positive end limit.
       MIO_SMEL		    		        =(12),	// Soft negative end limit.
       MIO_TLC		              	=(13),	// Torque is limited by torque limit value.
       MIO_ABSL				            =(14),	// Absolute position lost.
       MIO_STA			              =(15),	// External start signal.
       MIO_PSD								    =(16),	// Positive slow down signal
       MIO_MSD								    =(17),	// Negative slow down signal

            // Motion status bit number define.
       MTS_CSTP			    	        =(0),			// Command stop signal. 
       MTS_VM			    						=(1),			// At maximum velocity.
       MTS_ACC								    =(2),			// In acceleration.
       MTS_DEC								    =(3),			// In deceleration.
       MTS_DIR								    =(4),			// (Last)Moving direction.
       NSTP		    		            =(5),			// Normal stop(Motion done).
       MTS_HMV								    =(6),			// In home operation.
       MTS_SMV								    =(7),			// Single axis move( relative, absolute, velocity move).
       MTS_LIP								    =(8),			// Linear interpolation.
       MTS_CIP								    =(9),			// Circular interpolation.
       MTS_VS								      =(10),		// At start velocity.
       MTS_PMV								    =(11),		// Point table move.
       MTS_PDW								    =(12),		// Point table dwell move.
       MTS_PPS								    =(13),		// Point table pause state.
       MTS_SLV								    =(14),		// Slave axis move.
       MTS_JOG								    =(15),		// Jog move.
       MTS_ASTP			    	        =(16),		// Abnormal stop.
       MTS_SVONS								  =(17),		// Servo off stopped.
       MTS_EMGS								    =(18),		// EMG / SEMG stopped.
       MTS_ALMS								    =(19),		// Alarm stop.
       MTS_WANS								    =(20),		// Warning stopped.
       MTS_PELS								    =(21),		// PEL stopped.
       MTS_MELS								    =(22),		// MEL stopped.
       MTS_ECES								    =(23),		// Error counter check level reaches and stopped.
       MTS_SPELS								  =(24),		// Soft PEL stopped.
       MTS_SMELS								  =(25),		// Soft MEL stopped.
       MTS_STPOA								  =(26),		// Stop by others axes.
       MTS_GDCES								  =(27),		// Gantry deviation error level reaches and stopped.
       MTS_GTM								    =(28),		// Gantry mode turn on.
       MTS_PAPB								    =(29),		// Pulsar mode turn on.
             
        // Motion IO status bit value define.
       MIO_ALM_V								  =(0x1),		// Servo alarm.
       MIO_PEL_V    		          =(0x2),		// Positive end limit.
       MIO_MEL_V    		          =(0x4),		// Negative end limit.
       MIO_ORG_V								  =(0x8),		// ORG (Home).
       MIO_EMG_V								  =(0x10),	// Emergency stop.
       MIO_EZ_V								    =(0x20),	// EZ.
       MIO_INP_V								  =(0x40),	// In position.
       MIO_SVON_V								  =(0x80),	// Servo on signal.
       MIO_RDY_V								  =(0x100),	// Ready.
       MIO_WARN_V								  =(0x200),	// Warning.
       MIO_ZSP_V								  =(0x400),	// Zero speed.
       MIO_SPEL_V								  =(0x800),	// Soft positive end limit.
       MIO_SMEL_V								  =(0x1000),	// Soft negative end limit.
       MIO_TLC_V								  =(0x2000),	// Torque is limited by torque limit value.
       MIO_ABSL_V								  =(0x4000),	// Absolute position lost.
       MIO_STA_V								  =(0x8000),	// External start signal.
       MIO_PSD_V								  =(0x10000),	// Positive slow down signal.
       MIO_MSD_V								  =(0x20000),	// Negative slow down signal.

// Motion status bit define.
       MTS_CSTP_V								  =(0x1),			// Command stop signal. 
       MTS_VM_V								    =(0x2),			// At maximum velocity.
       MTS_ACC_V    		        	=(0x4),			// In acceleration.
       MTS_DEC_V    		        	=(0x8),			// In deceleration.
       MTS_DIR_V    		        	=(0x10),		// (Last)Moving direction.
       MTS_NSTP_V   		        	=(0x20),		// Normal stop(Motion done).
       MTS_HMV_V    		        	=(0x40),		// In home operation.
       MTS_SMV_V    		        	=(0x80),		// Single axis move( relative, absolute, velocity move).
       MTS_LIP_V    		        	=(0x100),		// Linear interpolation.
       MTS_CIP_V    		        	=(0x200),		// Circular interpolation.
       MTS_VS_V     		        	=(0x400),		// At start velocity.
       MTS_PMV_V    		        	=(0x800),		// Point table move.
       MTS_PDW_V    		        	=(0x1000),		// Point table dwell move.
       MTS_PPS_V    		        	=(0x2000),		// Point table pause state.
       MTS_SLV_V    		        	=(0x4000),		// Slave axis move.
       MTS_JOG_V    		        	=(0x8000),		// Jog move.
       MTS_ASTP_V   		        	=(0x10000),		// Abnormal stop.
       MTS_SVONS_V  		        	=(0x20000),		// Servo off stopped.
       MTS_EMGS_V   		        	=(0x40000),		// EMG / SEMG stopped.
       MTS_ALMS_V   		        	=(0x80000),		// Alarm stop.
       MTS_WANS_V   		        	=(0x100000),	// Warning stopped.
       MTS_PELS_V   		        	=(0x200000),	// PEL stopped.
       MTS_MELS_V   		        	=(0x400000),	// MEL stopped.
       MTS_ECES_V   		        	=(0x800000),	// Error counter check level reaches and stopped.
       MTS_SPELS_V  		        	=(0x1000000),	// Soft PEL stopped.
       MTS_SMELS_V  		        	=(0x2000000),	// Soft MEL stopped.
       MTS_STPOA_V  		        	=(0x4000000),	// Stop by others axes.
       MTS_GDCES_V  		        	=(0x8000000),	// Gantry deviation error level reaches and stopped.
       MTS_GTM_V    		        	=(0x10000000),	// Gantry mode turn on.
       MTS_PAPB_V   		        	=(0x20000000)	// Pulsar mode turn on.
							  }	
}