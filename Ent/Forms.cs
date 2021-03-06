using System;
using System.Collections;

namespace BildChile.ENT
{
	/// <summary>
	/// Entidad de negocio Forms.
	/// </summary>
	public partial class Forms
	{
		#region Miembros privados
		private int _Id;
		private string _Name;
		private Hashtable nulosHash;
		#endregion	

		#region Constructor
		
		public Forms()
		{
			nulosHash = new Hashtable();	
			nulosHash.Add("Id",true);
			nulosHash.Add("Name",true);
		}
		
		#endregion
		
		#region Propiedades públicas
		
		public int Id
		{
			get { return _Id; }
			set { _Id = value; nulosHash["Id"] = false; }		
		}
		
		public string Name
		{
			get { return _Name; }
			set { _Name = value; nulosHash["Name"] = false; }		
		}
		

		#endregion		
		
		#region Métodos públicos
		
		public bool EsNulo(string nombreCampo)
		{
			try
			{
				return (bool) nulosHash[nombreCampo];
			}
			catch
			{
				return true;
			}
		}	
		
		#endregion	
	}	

}

