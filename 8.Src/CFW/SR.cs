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

using System;
using System.Resources;
using System.Globalization;
using System.Threading;
using System.ComponentModel;

namespace Infragistics.Shared
{
	internal sealed class SR
	{
		#region Member Variables

		private static SR					loader = null;

		// AS 6/28/04
		// Changed implementation to support multiple string resource files.
		//
		//private ResourceManager				resources = null;
		private ResourceManager[]				resources = null;

		#endregion Member Variables

		#region Contructor
		private SR()
		{
			string baseName = AssemblyRef.BaseResourceName;

			// AS 6/28/04
			// The resource could contain multiple string resource files so
			// we'll parse the base name and store the resource managers
			// in an array.
			//
			//this.resources = new ResourceManager( baseName, this.GetType().Assembly );
			System.Diagnostics.Debug.Assert(baseName != null, string.Format("Invalid 'AssemblyRef.BaseResource' constant defined for the assembly '{0}'", typeof(SR).Assembly.FullName) );

			string[] resourceNames = baseName.Split(';');

			int resourceCount = 0;

			// count them up since someone could have empty items in the list
			// or have the string end with a semi-colon
			foreach(string resource in resourceNames)
			{
				if (resource != null && resource.Length > 0)
					resourceCount++;
			}

			System.Diagnostics.Debug.Assert(resourceCount > 0, "No valid resource string names listed in the 'AssemblyRef.BaseResource'");

			// create the array
			this.resources = new ResourceManager[resourceCount];

			System.Reflection.Assembly assembly = this.GetType().Assembly;
			int index = 0;

			// count them up since someone could have empty items in the list
			foreach(string resource in resourceNames)
			{
				if (resource != null && resource.Length > 0)
					this.resources[index++] = new ResourceManager(resource, assembly);
			}
		}
		#endregion Contructor

		#region Methods

		#region GetLoader
		private static SR GetLoader()
		{
			if (SR.loader == null)
			{
				Type type = typeof(SR);

				Monitor.Enter( type );

				try
				{
					if (SR.loader == null)
					{
						SR.loader = new SR();
					}
				}
				finally
				{
					Monitor.Exit( type );
				}
			}
			return SR.loader;
		}
		#endregion GetLoader

		#region GetString methods

		public static string GetString( string name )
		{
			return SR.GetString( null, name );
		}

		public static string GetString( string name, params object[] args )
		{
			return SR.GetString( null, name, args );
		}

		public static string GetString( CultureInfo culture, string name )
		{
			return SR.GetString( culture, name, null );
		}

		public static string GetString( CultureInfo culture, string name, params object[] args )
		{
			return GetStringHelper( true, culture, name, args );
		}

		private static string GetStringHelper( bool allowCustomizedStrings, CultureInfo culture, string name, params object[] args )
		{
			string str = null;

			// JJD 8/27/02
			// See if someone specified a customized string first.
			if ( allowCustomizedStrings )
				str = ResourceCustomizerLocator.Customizer.GetCustomizedString( name );

			if ( str == null )
			{
				SR sr = SR.GetLoader();

				// JJD 5/24/04
				// Never return null. Instead return an empty string
				if (sr == null)
					return string.Empty; //return null;

				// AS 6/28/04
				// Use a helper method which will check the array.
				//
				//str = sr.resources.GetString( name, culture );
				str = sr.GetString( name, culture );

				// JJD 5/24/04
				// Never return null. Instead return an empty string
				if (str == null )
					str = string.Empty;
			}

			// JJD 5/24/04
			// Only call string.Format if the base string is at least
			// 3 characters long which is the minimum to contain a 
			// substition string (e.g. '{0}')
			if (args != null && args.Length > 0 && str.Length > 2)
			{
				// AS 4/30/03 FxCop Change
				// Explicitly call the overload that takes an IFormatProvider
				//
				//str = string.Format( str, args );

				// JJD 5/24/04
				// Wrap the string.Format in a try/catch so that we will
				// return the original unformatted resource string in the case 
				// where there were more arguments than their were substition
				// literals in the string
				try
				{
					str = string.Format( null, str, args ); 
				}
				catch
				{
				}
			}

			return str;
		}

		// AS 6/28/04
		// Added a helper method to check the array of resource managers
		//
		private string GetString( string name, CultureInfo culture )
		{
			foreach(ResourceManager rm in this.resources)
			{
				string value = rm.GetString(name, culture);

				if (value != null)
					return value;
			}

			return null;
		}
		#endregion GetString methods

		#region GetUncustomizedString methods

		public static string GetUncustomizedString( string name )
		{
			return SR.GetUncustomizedString( null, name );
		}

		public static string GetUncustomizedString( string name, params object[] args )
		{
			return SR.GetUncustomizedString( null, name, args );
		}

		public static string GetUncustomizedString( CultureInfo culture, string name )
		{
			return SR.GetUncustomizedString( culture, name, null );
		}

		public static string GetUncustomizedString( CultureInfo culture, string name, params object[] args )
		{
			return GetStringHelper( false, culture, name, args );
		}

		#endregion GetUncustomizedString methods

		#region GetObject
		public static object GetObject( string name )
		{
			return SR.GetObject( null, name );
		}

		public static object GetObject( CultureInfo culture, string name )
		{
			SR sr = SR.GetLoader();

			if (sr == null)
				return null;

			// AS 6/28/04
			// Use a helper method which will check the array.
			//
			//return sr.resources.GetObject(name, culture);
			return sr.GetObject(name, culture);
		}

		// AS 6/28/04
		// Added a helper method to check the array of resource managers
		//
		private object GetObject( string name, CultureInfo culture )
		{
			foreach(ResourceManager rm in this.resources)
			{
				object value = rm.GetObject(name, culture);

				if (value != null)
					return value;
			}

			return null;
		}
		#endregion //GetObject

		#endregion Methods
	}

	#region Localized Atttribute classes 


		#region LocalizedCategoryAttribute

	[AttributeUsage(AttributeTargets.All, AllowMultiple=false, Inherited=true)]
	internal sealed class LocalizedCategoryAttribute : CategoryAttribute
	{
		#region Constructor
		public LocalizedCategoryAttribute(string category) : base(category)
		{
		}
		#endregion //Constructor

		#region Properties
		/// <summary>
		/// Returns the localized category name
		/// </summary>
		/// <param name="value">Name of the category to retreive</param>
		/// <returns>The localized string value</returns>
		protected override string GetLocalizedString(string value)
		{
			// AS 4/30/03 FxCop Change
			// Explicitly call the overload that takes a culture info.
			//
			//return SR.GetUncustomizedString(value);
			return SR.GetUncustomizedString(null, value);
		}
		#endregion //Properties
	}

		#endregion //LocalizedCategoryAttribute

		#region LocalizedDescriptionAttribute

	[AttributeUsage(AttributeTargets.All, AllowMultiple=false, Inherited=true)]
	internal sealed class LocalizedDescriptionAttribute : DescriptionAttribute
	{
		#region Member Variables

		private bool loaded = false;

		#endregion //Member Variables

		#region Constructor
		public LocalizedDescriptionAttribute( string description ) : base(description)
		{
		}
		#endregion //Constructor

		#region Properties

		public override string Description
		{
			get
			{
				if (!loaded)
				{
					loaded = true;
					// AS 4/30/03 FxCop Change
					// Explicitly call the overload that takes a culture info.
					//
					//base.DescriptionValue = SR.GetUncustomizedString(base.Description);
					base.DescriptionValue = SR.GetUncustomizedString(null, base.Description);
				}

				return base.Description;
			}
		}

		#endregion //Properties
	}

		#endregion //LocalizedDescriptionAttribute

		#region LocalizedUltraPropertyPageAttribute

	[AttributeUsage(AttributeTargets.Class, AllowMultiple=true)]
	internal sealed class LocalizedUltraPropertyPageAttribute : Infragistics.Shared.UltraPropertyPageAttribute
	{
		#region Constructor
		public LocalizedUltraPropertyPageAttribute( string tabCaption, System.Type ultraPropControlType ) : base(tabCaption, ultraPropControlType)
		{
		}

		public LocalizedUltraPropertyPageAttribute( string tabCaption, string ultraPropControlType ) : base(tabCaption,ultraPropControlType)
		{
		}
		#endregion //Constructor

		#region TabCaption
		public override string TabCaption
		{
			get 
			{ 
				// AS 4/30/03 FxCop Change
				// Explicitly call the overload that takes a culture info.
				//
				//return SR.GetUncustomizedString(base.TabCaption);
				return SR.GetUncustomizedString(null, base.TabCaption);
			}
		}
		#endregion //TabCaption
	}

		#endregion //LocalizedUltraPropertyPageAttribute


	#endregion Localized Atttribute classes 
}
