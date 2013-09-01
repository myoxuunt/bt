#region Copyright (c) 2001-2005 Infragistics, Inc. All Rights Reserved
/* ---------------------------------------------------------------------*
*                           Infragistics, Inc.                          *
*              Copyright (c) 2001-2005 All Rights reserved               *
*                                                                       *
*                                                                       *
* This file and its contents are protected by United States and         *
* International copyright laws.  Unauthorized reproduction and/or       *
* distribution of all or any portion of the code contained herein       *
* is strictly prohibited and will result in severe civil and criminal   *
* penalties.  Any violations of this copyright will be prosecuted       *
* to the fullest extent possible under law.                             *
*                                                                       *
* THE SOURCE CODE CONTAINED HEREIN AND IN RELATED FILES IS PROVIDED     *
* TO THE REGISTERED DEVELOPER FOR THE PURPOSES OF EDUCATION AND         *
* TROUBLESHOOTING. UNDER NO CIRCUMSTANCES MAY ANY PORTION OF THE SOURCE *
* CODE BE DISTRIBUTED, DISCLOSED OR OTHERWISE MADE AVAILABLE TO ANY     *
* THIRD PARTY WITHOUT THE EXPRESS WRITTEN CONSENT OF INFRAGISTICS, INC. *
*                                                                       *
* UNDER NO CIRCUMSTANCES MAY THE SOURCE CODE BE USED IN WHOLE OR IN     *
* PART, AS THE BASIS FOR CREATING A PRODUCT THAT PROVIDES THE SAME, OR  *
* SUBSTANTIALLY THE SAME, FUNCTIONALITY AS ANY INFRAGISTICS PRODUCT.    *
*                                                                       *
* THE REGISTERED DEVELOPER ACKNOWLEDGES THAT THIS SOURCE CODE           *
* CONTAINS VALUABLE AND PROPRIETARY TRADE SECRETS OF INFRAGISTICS,      *
* INC.  THE REGISTERED DEVELOPER AGREES TO EXPEND EVERY EFFORT TO       *
* INSURE ITS CONFIDENTIALITY.                                           *
*                                                                       *
* THE END USER LICENSE AGREEMENT (EULA) ACCOMPANYING THE PRODUCT        *
* PERMITS THE REGISTERED DEVELOPER TO REDISTRIBUTE THE PRODUCT IN       *
* EXECUTABLE FORM ONLY IN SUPPORT OF APPLICATIONS WRITTEN USING         *
* THE PRODUCT.  IT DOES NOT PROVIDE ANY RIGHTS REGARDING THE            *
* SOURCE CODE CONTAINED HEREIN.                                         *
*                                                                       *
* THIS COPYRIGHT NOTICE MAY NOT BE REMOVED FROM THIS FILE.              *
* --------------------------------------------------------------------- *
*/
#endregion Copyright (c) 2001-2005 Infragistics, Inc. All Rights Reserved

// JJD 8/28/02 - Added support for runtime string customizations
// This class needs to be outside the namespace
internal class ResourceCustomizerLocator
{
	internal static readonly Infragistics.Shared.ResourceCustomizer Customizer = new Infragistics.Shared.ResourceCustomizer();
}

//-----------------------------------------------------------------
// Note: The only code that needs to be changed is the namespace
//       below, which should be the name of the primary namespace
//       of the assembly. However, no 2 assemblies should have an
//       instance of this file with the same namespace specified 
//       below.
//-----------------------------------------------------------------
//namespace Infragistics.Win.UltraWinListBar // change this line only to the unigue namespace of this assembly
namespace CFW // change this line only to the unigue namespace of this assembly
{
	/// <summary>
	/// Exposes a <see cref="Infragistics.Shared.ResourceCustomizer"/> instance for this assembly. 
	/// </summary>
	/// <seealso cref="Customizer"/> 
	/// <seealso cref="Infragistics.Shared.ResourceCustomizer"/> 
	// JJD 12/16/02 - FxCop
	// Added ComVisible attribute to avoid fxcop violation
	[System.Runtime.InteropServices.ComVisible(false)]
	sealed public class Resources
	{
		// JJD 12/16/02 - FxCop
		// Add private constructor to remove FxCop warning.
		private Resources(){}

		/// <summary>
		/// Returns the <see cref="Infragistics.Shared.ResourceCustomizer"/> for this assembly.
		/// </summary>
		/// <seealso cref="Infragistics.Shared.ResourceCustomizer"/> 
		public static Infragistics.Shared.ResourceCustomizer Customizer { get { return ResourceCustomizerLocator.Customizer; } }
	}
}
