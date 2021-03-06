#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_1
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Project")]
	public partial class ProjectDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCustomer(Customer instance);
    partial void UpdateCustomer(Customer instance);
    partial void DeleteCustomer(Customer instance);
    partial void InsertLoginUser(LoginUser instance);
    partial void UpdateLoginUser(LoginUser instance);
    partial void DeleteLoginUser(LoginUser instance);
    partial void InsertTour(Tour instance);
    partial void UpdateTour(Tour instance);
    partial void DeleteTour(Tour instance);
    #endregion
		
		public ProjectDataContext() : 
				base(global::Project_1.Properties.Settings.Default.ProjectConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ProjectDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ProjectDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ProjectDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ProjectDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Customer> Customers
		{
			get
			{
				return this.GetTable<Customer>();
			}
		}
		
		public System.Data.Linq.Table<LoginUser> LoginUsers
		{
			get
			{
				return this.GetTable<LoginUser>();
			}
		}
		
		public System.Data.Linq.Table<Tour> Tours
		{
			get
			{
				return this.GetTable<Tour>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Customer")]
	public partial class Customer : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _CusId;
		
		private string _CusName;
		
		private System.Nullable<bool> _Gender;
		
		private System.Nullable<System.DateTime> _Birthday;
		
		private string _CusAddress;
		
		private string _Phone;
		
		private string _Email;
		
		private string _TourId;
		
		private EntityRef<Tour> _Tour;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnCusIdChanging(string value);
    partial void OnCusIdChanged();
    partial void OnCusNameChanging(string value);
    partial void OnCusNameChanged();
    partial void OnGenderChanging(System.Nullable<bool> value);
    partial void OnGenderChanged();
    partial void OnBirthdayChanging(System.Nullable<System.DateTime> value);
    partial void OnBirthdayChanged();
    partial void OnCusAddressChanging(string value);
    partial void OnCusAddressChanged();
    partial void OnPhoneChanging(string value);
    partial void OnPhoneChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnTourIdChanging(string value);
    partial void OnTourIdChanged();
    #endregion
		
		public Customer()
		{
			this._Tour = default(EntityRef<Tour>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CusId", DbType="VarChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string CusId
		{
			get
			{
				return this._CusId;
			}
			set
			{
				if ((this._CusId != value))
				{
					this.OnCusIdChanging(value);
					this.SendPropertyChanging();
					this._CusId = value;
					this.SendPropertyChanged("CusId");
					this.OnCusIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CusName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string CusName
		{
			get
			{
				return this._CusName;
			}
			set
			{
				if ((this._CusName != value))
				{
					this.OnCusNameChanging(value);
					this.SendPropertyChanging();
					this._CusName = value;
					this.SendPropertyChanged("CusName");
					this.OnCusNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gender", DbType="Bit")]
		public System.Nullable<bool> Gender
		{
			get
			{
				return this._Gender;
			}
			set
			{
				if ((this._Gender != value))
				{
					this.OnGenderChanging(value);
					this.SendPropertyChanging();
					this._Gender = value;
					this.SendPropertyChanged("Gender");
					this.OnGenderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Birthday", DbType="DateTime")]
		public System.Nullable<System.DateTime> Birthday
		{
			get
			{
				return this._Birthday;
			}
			set
			{
				if ((this._Birthday != value))
				{
					this.OnBirthdayChanging(value);
					this.SendPropertyChanging();
					this._Birthday = value;
					this.SendPropertyChanged("Birthday");
					this.OnBirthdayChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CusAddress", DbType="NVarChar(100)")]
		public string CusAddress
		{
			get
			{
				return this._CusAddress;
			}
			set
			{
				if ((this._CusAddress != value))
				{
					this.OnCusAddressChanging(value);
					this.SendPropertyChanging();
					this._CusAddress = value;
					this.SendPropertyChanged("CusAddress");
					this.OnCusAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Phone", DbType="NVarChar(20)")]
		public string Phone
		{
			get
			{
				return this._Phone;
			}
			set
			{
				if ((this._Phone != value))
				{
					this.OnPhoneChanging(value);
					this.SendPropertyChanging();
					this._Phone = value;
					this.SendPropertyChanged("Phone");
					this.OnPhoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(50)")]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TourId", DbType="VarChar(20)")]
		public string TourId
		{
			get
			{
				return this._TourId;
			}
			set
			{
				if ((this._TourId != value))
				{
					if (this._Tour.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnTourIdChanging(value);
					this.SendPropertyChanging();
					this._TourId = value;
					this.SendPropertyChanged("TourId");
					this.OnTourIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Tour_Customer", Storage="_Tour", ThisKey="TourId", OtherKey="TourId", IsForeignKey=true)]
		public Tour Tour
		{
			get
			{
				return this._Tour.Entity;
			}
			set
			{
				Tour previousValue = this._Tour.Entity;
				if (((previousValue != value) 
							|| (this._Tour.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Tour.Entity = null;
						previousValue.Customers.Remove(this);
					}
					this._Tour.Entity = value;
					if ((value != null))
					{
						value.Customers.Add(this);
						this._TourId = value.TourId;
					}
					else
					{
						this._TourId = default(string);
					}
					this.SendPropertyChanged("Tour");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.LoginUser")]
	public partial class LoginUser : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserId;
		
		private string _UserName;
		
		private string _Pass;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnPassChanging(string value);
    partial void OnPassChanged();
    #endregion
		
		public LoginUser()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="NVarChar(50)")]
		public string UserName
		{
			get
			{
				return this._UserName;
			}
			set
			{
				if ((this._UserName != value))
				{
					this.OnUserNameChanging(value);
					this.SendPropertyChanging();
					this._UserName = value;
					this.SendPropertyChanged("UserName");
					this.OnUserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Pass", DbType="NVarChar(50)")]
		public string Pass
		{
			get
			{
				return this._Pass;
			}
			set
			{
				if ((this._Pass != value))
				{
					this.OnPassChanging(value);
					this.SendPropertyChanging();
					this._Pass = value;
					this.SendPropertyChanged("Pass");
					this.OnPassChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Tour")]
	public partial class Tour : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _TourId;
		
		private string _TourName;
		
		private string _Destinations;
		
		private System.Nullable<double> _Price;
		
		private string _Describle;
		
		private string _TourTime;
		
		private string _Vehicle;
		
		private string _TourType;
		
		private string _TourGuide;
		
		private EntitySet<Customer> _Customers;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnTourIdChanging(string value);
    partial void OnTourIdChanged();
    partial void OnTourNameChanging(string value);
    partial void OnTourNameChanged();
    partial void OnDestinationsChanging(string value);
    partial void OnDestinationsChanged();
    partial void OnPriceChanging(System.Nullable<double> value);
    partial void OnPriceChanged();
    partial void OnDescribleChanging(string value);
    partial void OnDescribleChanged();
    partial void OnTourTimeChanging(string value);
    partial void OnTourTimeChanged();
    partial void OnVehicleChanging(string value);
    partial void OnVehicleChanged();
    partial void OnTourTypeChanging(string value);
    partial void OnTourTypeChanged();
    partial void OnTourGuideChanging(string value);
    partial void OnTourGuideChanged();
    #endregion
		
		public Tour()
		{
			this._Customers = new EntitySet<Customer>(new Action<Customer>(this.attach_Customers), new Action<Customer>(this.detach_Customers));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TourId", DbType="VarChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string TourId
		{
			get
			{
				return this._TourId;
			}
			set
			{
				if ((this._TourId != value))
				{
					this.OnTourIdChanging(value);
					this.SendPropertyChanging();
					this._TourId = value;
					this.SendPropertyChanged("TourId");
					this.OnTourIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TourName", DbType="NVarChar(200) NOT NULL", CanBeNull=false)]
		public string TourName
		{
			get
			{
				return this._TourName;
			}
			set
			{
				if ((this._TourName != value))
				{
					this.OnTourNameChanging(value);
					this.SendPropertyChanging();
					this._TourName = value;
					this.SendPropertyChanged("TourName");
					this.OnTourNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Destinations", DbType="NVarChar(200)")]
		public string Destinations
		{
			get
			{
				return this._Destinations;
			}
			set
			{
				if ((this._Destinations != value))
				{
					this.OnDestinationsChanging(value);
					this.SendPropertyChanging();
					this._Destinations = value;
					this.SendPropertyChanged("Destinations");
					this.OnDestinationsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Float")]
		public System.Nullable<double> Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Describle", DbType="NVarChar(1500)")]
		public string Describle
		{
			get
			{
				return this._Describle;
			}
			set
			{
				if ((this._Describle != value))
				{
					this.OnDescribleChanging(value);
					this.SendPropertyChanging();
					this._Describle = value;
					this.SendPropertyChanged("Describle");
					this.OnDescribleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TourTime", DbType="NVarChar(100)")]
		public string TourTime
		{
			get
			{
				return this._TourTime;
			}
			set
			{
				if ((this._TourTime != value))
				{
					this.OnTourTimeChanging(value);
					this.SendPropertyChanging();
					this._TourTime = value;
					this.SendPropertyChanged("TourTime");
					this.OnTourTimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Vehicle", DbType="NVarChar(100)")]
		public string Vehicle
		{
			get
			{
				return this._Vehicle;
			}
			set
			{
				if ((this._Vehicle != value))
				{
					this.OnVehicleChanging(value);
					this.SendPropertyChanging();
					this._Vehicle = value;
					this.SendPropertyChanged("Vehicle");
					this.OnVehicleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TourType", DbType="NVarChar(100)")]
		public string TourType
		{
			get
			{
				return this._TourType;
			}
			set
			{
				if ((this._TourType != value))
				{
					this.OnTourTypeChanging(value);
					this.SendPropertyChanging();
					this._TourType = value;
					this.SendPropertyChanged("TourType");
					this.OnTourTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TourGuide", DbType="NVarChar(100)")]
		public string TourGuide
		{
			get
			{
				return this._TourGuide;
			}
			set
			{
				if ((this._TourGuide != value))
				{
					this.OnTourGuideChanging(value);
					this.SendPropertyChanging();
					this._TourGuide = value;
					this.SendPropertyChanged("TourGuide");
					this.OnTourGuideChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Tour_Customer", Storage="_Customers", ThisKey="TourId", OtherKey="TourId")]
		public EntitySet<Customer> Customers
		{
			get
			{
				return this._Customers;
			}
			set
			{
				this._Customers.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Customers(Customer entity)
		{
			this.SendPropertyChanging();
			entity.Tour = this;
		}
		
		private void detach_Customers(Customer entity)
		{
			this.SendPropertyChanging();
			entity.Tour = null;
		}
	}
}
#pragma warning restore 1591
