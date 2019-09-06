using System;
using System.Data;

namespace PersonalLib2.Sql.Attributes
{
	[AttributeUsage(AttributeTargets.Property), Serializable]
	public class KeyFieldAttribute : BaseFieldAttribute
	{
		private bool _keyIdentity = false;

		public KeyFieldAttribute(string columnName) : this(columnName, DbType.String)
		{
		}

		public KeyFieldAttribute(string columnName, DbType dbType) : this(columnName, dbType, 0)
		{
		}

		public KeyFieldAttribute(string columnName, DbType dbType, int size) : this(columnName, dbType, size, "=")
		{
		}

		public KeyFieldAttribute(string columnName, DbType dbType, int size, string compare) : this(columnName, dbType, size, compare, true)
		{
		}

		public KeyFieldAttribute(string columnName, DbType dbType, int size, string compare, bool caseSensitive) : this(columnName, dbType, size, compare, caseSensitive, null)
		{
		}

		public KeyFieldAttribute(string columnName, DbType dbType, int size, string compare, bool caseSensitive, string format) : this(columnName, dbType, size, compare, caseSensitive, format, BaseFieldScope.Select + BaseFieldScope.Update + BaseFieldScope.Insert + BaseFieldScope.Where)
		{
		}

		public KeyFieldAttribute(string columnName, DbType dbType, int size, string compare, bool caseSensitive, string format, int dbScope) : this(columnName, dbType, size, compare, caseSensitive, format, dbScope, SetType.Always)
		{
		}

		public KeyFieldAttribute(string columnName, DbType dbType, int size, string compare, bool caseSensitive, string format, int dbScope, SetType setMode) : this(columnName, dbType, size, compare, caseSensitive, format, dbScope, setMode, false)
		{
		}

		public KeyFieldAttribute(string columnName, DbType dbType, int size, string compare, bool caseSensitive, string format, int dbScope, SetType setMode, bool keyIdentity) : base(columnName, dbType, size, compare, caseSensitive, format, dbScope, setMode)
		{
			_keyIdentity = keyIdentity;
		}

		/// <summary>
		/// Se True, in inserimento, la propriet� viene impostata al come la max+1 all'interno della chiave primaria della tabella.
		/// Es.
		///		in una tabella con chiave primaria key1+key2 se la propriet� che descrive la colonna key2 � KeyIdentity=True
		///		allora il suo valore prima dell'inserimento viene impostato con la seguente query SELECT Max(key2)+1 From Table Where key1=x
		///		dove x � il valore contenuto dalla propriet� key1.
		///		Se la propriet� key2 � l'unica propriet� con attributo KeyFieldAttribute allora, dalla query di esempio, verrebbe esclusa
		///		la condizione Where.
		/// </summary>
		public bool KeyIdentity
		{
			get { return _keyIdentity; }
			set { _keyIdentity = value; }
		}
	} ;
}