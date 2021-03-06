using System;
using System.Collections;

namespace BildChile.ENT
{
	/// <summary>
	/// Entidad de negocio Inputs.
	/// </summary>
	public partial class Inputs
	{
		#region Miembros privados
		private int _Id;
		private int _IdForms;
		private string _Name;
		private string _Type;
		private bool _Required;
		private Hashtable nulosHash;
		#endregion	

		#region Constructor
		
		public Inputs()
		{
			nulosHash = new Hashtable();	
			nulosHash.Add("Id",true);
			nulosHash.Add("IdForms",true);
			nulosHash.Add("Name",true);
			nulosHash.Add("Type",true);
			nulosHash.Add("Required",true);
		}
		
		#endregion
		
		#region Propiedades públicas
		
		public int Id
		{
			get { return _Id; }
			set { _Id = value; nulosHash["Id"] = false; }		
		}
		
		public int IdForms
		{
			get { return _IdForms; }
			set { _IdForms = value; nulosHash["IdForms"] = false; }		
		}
		
		public string Name
		{
			get { return _Name; }
			set { _Name = value; nulosHash["Name"] = false; }		
		}
		
		public string Type
		{
			get { return _Type; }
			set { _Type = value; nulosHash["Type"] = false; }		
		}
		
		public bool Required
		{
			get { return _Required; }
			set { _Required = value; nulosHash["Required"] = false; }		
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

