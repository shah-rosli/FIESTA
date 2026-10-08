using FIESTA_Backend.Converters;
using Microsoft.EntityFrameworkCore;

namespace FIESTA_Backend.EfModels;

public partial class MDMDbContext : DbContext
{
    public MDMDbContext()
    {
    }

    public MDMDbContext(DbContextOptions<MDMDbContext> options)
        : base(options)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Properties<DateOnly>()
                            .HaveConversion<DateOnlyConverter>()
                            .HaveColumnType("DATE");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            var environmentName = Environment.GetEnvironmentVariable("FIESTA_ENVIRONMENT", EnvironmentVariableTarget.Machine);
            var connectionString = configuration.GetConnectionString("ConnectionString_SB_" + environmentName);
            optionsBuilder.UseOracle(connectionString, b => b.UseOracleSQLCompatibility(OracleSQLCompatibility.DatabaseVersion19));

            //optionsBuilder.UseOracle("Data Source=fiestadv.c8h5vit1o7xb.us-west-2.rds.amazonaws.com:1521/fiestadv;User Id=fiestaadm;Password=R3n3S@$23;");
        }
    }

    public virtual DbSet<OUT_CUS_BILL_TO> OUT_CUS_BILL_TOs { get; set; }
    public virtual DbSet<OUT_CUS_END_CUSTOMER> OUT_CUS_END_CUSTOMERs { get; set; }
    public virtual DbSet<OUT_CUS_SHIP_TO> OUT_CUS_SHIP_TOs { get; set; }
    public virtual DbSet<OUT_CUS_SOLD_TO> OUT_CUS_SOLD_TOs { get; set; }
    public virtual DbSet<OUT_FIN_COST_CENTER> OUT_FIN_COST_CENTERs { get; set; }
    public virtual DbSet<OUT_FIN_IP_CUSTOMER> OUT_FIN_IP_CUSTOMERs { get; set; }
    public virtual DbSet<OUT_FIN_IP_OPN> OUT_FIN_IP_OPNs { get; set; }
    public virtual DbSet<OUT_VEN_VENDOR> OUT_VEN_VENDORs { get; set; }
    public virtual DbSet<OUT_VEN_VENDOR_COMPANY> OUT_VEN_VENDOR_COMPANies { get; set; }
    public virtual DbSet<OUT_VEN_VENDOR_PURCHASE_INFO_REC> OUT_VEN_VENDOR_PURCHASE_INFO_RECs { get; set; }
    public virtual DbSet<CFG_APP_APPLICATION1> CFG_APP_APPLICATION1s { get; set; }
    public virtual DbSet<CFG_APP_APPLICATION2> CFG_APP_APPLICATION2s { get; set; }
    public virtual DbSet<CFG_APP_APPLICATION3> CFG_APP_APPLICATION3s { get; set; }
    public virtual DbSet<V_CFG_APP_APPLICATION1> V_CFG_APP_APPLICATION1s { get; set; }
    public virtual DbSet<V_CFG_APP_APPLICATION1_HI> V_CFG_APP_APPLICATION1_HIs { get; set; }
    public virtual DbSet<V_CFG_APP_APPLICATION2> V_CFG_APP_APPLICATION2s { get; set; }
    public virtual DbSet<V_CFG_APP_APPLICATION2_HI> V_CFG_APP_APPLICATION2_HIs { get; set; }
    public virtual DbSet<V_CFG_APP_APPLICATION3> V_CFG_APP_APPLICATION3s { get; set; }
    public virtual DbSet<V_CFG_APP_APPLICATION3_HI> V_CFG_APP_APPLICATION3_HIs { get; set; }
    public virtual DbSet<RAW_CFG_APP_APPLICATION1> RAW_CFG_APP_APPLICATION1s { get; set; }
    public virtual DbSet<RAW_CFG_APP_APPLICATION2> RAW_CFG_APP_APPLICATION2s { get; set; }
    public virtual DbSet<RAW_CFG_APP_APPLICATION3> RAW_CFG_APP_APPLICATION3s { get; set; }
    public virtual DbSet<CFG_COMPANY_CODE> CFG_COMPANY_CODEs { get; set; }
    public virtual DbSet<CFG_PLANT> CFG_PLANTs { get; set; }
    public virtual DbSet<CFG_PRODUCTION_GROUP_STAGE> CFG_PRODUCTION_GROUP_STAGEs { get; set; }
    public virtual DbSet<CFG_PRODUCTION_GROUP_STAGE_CONVERSION> CFG_PRODUCTION_GROUP_STAGE_CONVERSIONs { get; set; }
    public virtual DbSet<CFG_PRODUCTION_PLANT_CONVERSION> CFG_PRODUCTION_PLANT_CONVERSIONs { get; set; }
    public virtual DbSet<CFG_STORAGE_LOCATION> CFG_STORAGE_LOCATIONs { get; set; }
    public virtual DbSet<RAW_CFG_COMPANY_CODE> RAW_CFG_COMPANY_CODEs { get; set; }
    public virtual DbSet<RAW_CFG_PLANT> RAW_CFG_PLANTs { get; set; }
    public virtual DbSet<RAW_CFG_PRODUCTION_GROUP_STAGE> RAW_CFG_PRODUCTION_GROUP_STAGEs { get; set; }
    public virtual DbSet<RAW_CFG_PRODUCTION_GROUP_STAGE_CONVERSION> RAW_CFG_PRODUCTION_GROUP_STAGE_CONVERSIONs { get; set; }
    public virtual DbSet<RAW_CFG_PRODUCTION_PLANT_CONVERSION> RAW_CFG_PRODUCTION_PLANT_CONVERSIONs { get; set; }
    public virtual DbSet<RAW_CFG_STORAGE_LOCATION> RAW_CFG_STORAGE_LOCATIONs { get; set; }
    public virtual DbSet<V_CFG_COMPANY_CODE> V_CFG_COMPANY_CODEs { get; set; }
    public virtual DbSet<V_CFG_COMPANY_CODE_HI> V_CFG_COMPANY_CODE_HIs { get; set; }
    public virtual DbSet<V_CFG_PLANT> V_CFG_PLANTs { get; set; }
    public virtual DbSet<V_CFG_PLANTS_HI> V_CFG_PLANTS_HIs { get; set; }
    public virtual DbSet<V_CFG_PRODUCTION_GROUP_STAGE> V_CFG_PRODUCTION_GROUP_STAGEs { get; set; }
    public virtual DbSet<V_CFG_PRODUCTION_GROUP_STAGE_CONVERSION> V_CFG_PRODUCTION_GROUP_STAGE_CONVERSIONs { get; set; }
    public virtual DbSet<V_CFG_PRODUCTION_GROUP_STAGE_CONVERSION_HI> V_CFG_PRODUCTION_GROUP_STAGE_CONVERSION_HIs { get; set; }
    public virtual DbSet<V_CFG_PRODUCTION_GROUP_STAGE_HI> V_CFG_PRODUCTION_GROUP_STAGE_HIs { get; set; }
    public virtual DbSet<V_CFG_PRODUCTION_PLANT_CONVERSION> V_CFG_PRODUCTION_PLANT_CONVERSIONs { get; set; }
    public virtual DbSet<V_CFG_PRODUCTION_PLANT_CONVERSION_HI> V_CFG_PRODUCTION_PLANT_CONVERSION_HIs { get; set; }
    public virtual DbSet<V_CFG_STORAGE_LOCATION> V_CFG_STORAGE_LOCATIONs { get; set; }
    public virtual DbSet<V_CFG_STORAGE_LOCATION_HI> V_CFG_STORAGE_LOCATION_HIs { get; set; }
    public virtual DbSet<CFG_PRODUCT_ECCN_CONVERSION> CFG_PRODUCT_ECCN_CONVERSIONs { get; set; }
    public virtual DbSet<CFG_PRODUCT_HISTORICAL> CFG_PRODUCT_HISTORICALs { get; set; }
    public virtual DbSet<CFG_PRODUCT_HS_CONVERSION> CFG_PRODUCT_HS_CONVERSIONs { get; set; }
    public virtual DbSet<CFG_PRODUCT_LINE> CFG_PRODUCT_LINEs { get; set; }
    public virtual DbSet<CFG_PRODUCT_SALES_ROOT_PARTNUMBER> CFG_PRODUCT_SALES_ROOT_PARTNUMBERs { get; set; }
    public virtual DbSet<CFG_PRODUCT_TYPE> CFG_PRODUCT_TYPEs { get; set; }
    public virtual DbSet<RAW_CFG_PRODUCT_ECCN_CONVERSION> RAW_CFG_PRODUCT_ECCN_CONVERSIONs { get; set; }
    public virtual DbSet<RAW_CFG_PRODUCT_HISTORICAL> RAW_CFG_PRODUCT_HISTORICALs { get; set; }
    public virtual DbSet<RAW_CFG_PRODUCT_HS_CONVERSION> RAW_CFG_PRODUCT_HS_CONVERSIONs { get; set; }
    public virtual DbSet<RAW_CFG_PRODUCT_LINE> RAW_CFG_PRODUCT_LINEs { get; set; }
    public virtual DbSet<RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER> RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBERs { get; set; }
    public virtual DbSet<RAW_CFG_PRODUCT_TYPE> RAW_CFG_PRODUCT_TYPEs { get; set; }
    public virtual DbSet<V_CFG_PRODUCT_ECCN_CONVERSION> V_CFG_PRODUCT_ECCN_CONVERSIONs { get; set; }
    public virtual DbSet<V_CFG_PRODUCT_ECCN_CONVERSION_HI> V_CFG_PRODUCT_ECCN_CONVERSION_HIs { get; set; }
    public virtual DbSet<V_CFG_PRODUCT_HISTORICAL> V_CFG_PRODUCT_HISTORICALs { get; set; }
    public virtual DbSet<V_CFG_PRODUCT_HISTORICAL_HI> V_CFG_PRODUCT_HISTORICAL_HIs { get; set; }
    public virtual DbSet<V_CFG_PRODUCT_HS_CONVERSION> V_CFG_PRODUCT_HS_CONVERSIONs { get; set; }
    public virtual DbSet<V_CFG_PRODUCT_HS_CONVERSION_HI> V_CFG_PRODUCT_HS_CONVERSION_HIs { get; set; }
    public virtual DbSet<V_CFG_PRODUCT_LINE> V_CFG_PRODUCT_LINEs { get; set; }
    public virtual DbSet<V_CFG_PRODUCT_LINE_HI> V_CFG_PRODUCT_LINE_HIs { get; set; }
    public virtual DbSet<V_CFG_PRODUCT_SALES_ROOT_PARTNUMBER> V_CFG_PRODUCT_SALES_ROOT_PARTNUMBERs { get; set; }
    public virtual DbSet<V_CFG_PRODUCT_SALES_ROOT_PARTNUMBER_HI> V_CFG_PRODUCT_SALES_ROOT_PARTNUMBER_HIs { get; set; }
    public virtual DbSet<V_CFG_PRODUCT_TYPE> V_CFG_PRODUCT_TYPEs { get; set; }
    public virtual DbSet<V_CFG_PRODUCT_TYPE_HI> V_CFG_PRODUCT_TYPE_HIs { get; set; }
    public virtual DbSet<V_OUT_APP_APPLICATION1> V_OUT_APP_APPLICATION1s { get; set; }
    public virtual DbSet<V_OUT_APP_APPLICATION2> V_OUT_APP_APPLICATION2s { get; set; }
    public virtual DbSet<V_OUT_APP_APPLICATION3> V_OUT_APP_APPLICATION3s { get; set; }
    public virtual DbSet<V_OUT_PRODUCT_ECCN_CONVERSION> V_OUT_PRODUCT_ECCN_CONVERSIONs { get; set; }
    public virtual DbSet<V_OUT_PRODUCT_HISTORICAL> V_OUT_PRODUCT_HISTORICALs { get; set; }
    public virtual DbSet<V_OUT_PRODUCT_HS_CONVERSION> V_OUT_PRODUCT_HS_CONVERSIONs { get; set; }
    public virtual DbSet<V_OUT_PRODUCT_LINE> V_OUT_PRODUCT_LINEs { get; set; }
    public virtual DbSet<V_OUT_PRODUCT_SALES_ROOT_PARTNUMBER> V_OUT_PRODUCT_SALES_ROOT_PARTNUMBERs { get; set; }
    public virtual DbSet<V_OUT_PRODUCT_TYPE> V_OUT_PRODUCT_TYPEs { get; set; }
    public virtual DbSet<V_MDM_COMPANY_CODE> V_MDM_COMPANY_CODEs { get; set; }
    public virtual DbSet<V_MDM_PLANT> V_MDM_PLANTs { get; set; }
    public virtual DbSet<V_MDM_PRODUCTION_GROUP_STAGE> V_MDM_PRODUCTION_GROUP_STAGEs { get; set; }
    public virtual DbSet<V_MDM_PRODUCTION_GROUP_STAGE_CONVERSION> V_MDM_PRODUCTION_GROUP_STAGE_CONVERSIONs { get; set; }
    public virtual DbSet<V_MDM_PRODUCTION_PLANT_CONVERSION> V_MDM_PRODUCTION_PLANT_CONVERSIONs { get; set; }
    public virtual DbSet<V_MDM_STORAGE_LOCATION> V_MDM_STORAGE_LOCATIONs { get; set; }
    public virtual DbSet<V_OUT_CUS_BILL_TO> V_OUT_CUS_BILL_TOs { get; set; }
    public virtual DbSet<V_OUT_CUS_END_CUSTOMER> V_OUT_CUS_END_CUSTOMERs { get; set; }
    public virtual DbSet<V_OUT_CUS_PARTNER_FUNCTION> V_OUT_CUS_PARTNER_FUNCTIONs { get; set; }
    public virtual DbSet<V_OUT_CUS_SHIP_TO> V_OUT_CUS_SHIP_TOs { get; set; }
    public virtual DbSet<V_OUT_CUS_SOLD_TO> V_OUT_CUS_SOLD_TOs { get; set; }
    public virtual DbSet<V_OUT_FIN_COST_CENTER> V_OUT_FIN_COST_CENTERs { get; set; }
    public virtual DbSet<V_OUT_FIN_IP_CUSTOMER> V_OUT_FIN_IP_CUSTOMERs { get; set; }
    public virtual DbSet<V_OUT_FIN_IP_OPN> V_OUT_FIN_IP_OPNs { get; set; }
    public virtual DbSet<V_OUT_PRODUCT_STANDARD_COST> V_OUT_PRODUCT_STANDARD_COSTs { get; set; }
    public virtual DbSet<V_OUT_PRODUCT_WIP_SELL_PRICE> V_OUT_PRODUCT_WIP_SELL_PRICEs { get; set; }
    public virtual DbSet<V_OUT_VEN_VENDOR> V_OUT_VEN_VENDORs { get; set; }
    public virtual DbSet<V_OUT_VEN_VENDOR_COMPANY> V_OUT_VEN_VENDOR_COMPANies { get; set; }
    public virtual DbSet<V_OUT_VEN_VENDOR_PURCHASE_INFO_REC> V_OUT_VEN_VENDOR_PURCHASE_INFO_RECs { get; set; }
    public virtual DbSet<V_MDM_PRODUCT_HIERARCHY> V_MDM_PRODUCT_HIERARCHies { get; set; }
    public virtual DbSet<V_MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION> V_MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSIONs { get; set; }
    public virtual DbSet<V_MDM_PROFIT_CENTER> V_MDM_PROFIT_CENTERs { get; set; }
    public virtual DbSet<V_MDM_PROFIT_CENTER_HIERARCHY> V_MDM_PROFIT_CENTER_HIERARCHies { get; set; }
    public virtual DbSet<V_OUT_NONPRODUCTION_PRODUCT> V_OUT_NONPRODUCTION_PRODUCTs { get; set; }
    public virtual DbSet<V_OUT_NONPRODUCTION_PRODUCT_PLANT> V_OUT_NONPRODUCTION_PRODUCT_PLANTs { get; set; }
    public virtual DbSet<V_OUT_NONPRODUCTION_PRODUCT_SALE> V_OUT_NONPRODUCTION_PRODUCT_SALEs { get; set; }
    public virtual DbSet<V_OUT_PRODUCT_CAN_FLAGS4> V_OUT_PRODUCT_CAN_FLAGS4s { get; set; }
    public virtual DbSet<CFG_FIN_IP_OPN> CFG_FIN_IP_OPNs { get; set; }
    public virtual DbSet<RAW_CFG_FIN_IP_OPN> RAW_CFG_FIN_IP_OPNs { get; set; }
    public virtual DbSet<V_CFG_FIN_IP_OPN> V_CFG_FIN_IP_OPNs { get; set; }
    public virtual DbSet<V_CFG_FIN_IP_OPN_HI> V_CFG_FIN_IP_OPN_HIs { get; set; }
    public virtual DbSet<MV_OUT_PRODUCT_PLANT_CONSOLIDATE> MV_OUT_PRODUCT_PLANT_CONSOLIDATEs { get; set; }
    public virtual DbSet<MV_OUT_PRODUCT_SALES_CONSOLIDATE> MV_OUT_PRODUCT_SALES_CONSOLIDATEs { get; set; }
    public virtual DbSet<OUT_PRODUCT_CONSOLIDATE> OUT_PRODUCT_CONSOLIDATEs { get; set; }
    public virtual DbSet<CFG_SYSTEM_PARAM> CFG_SYSTEM_PARAMs { get; set; }
    public virtual DbSet<RAW_CFG_PRODUCT_V2> RAW_CFG_PRODUCT_V2s { get; set; }
    public virtual DbSet<V_CFG_PRODUCT_HIS_V2> V_CFG_PRODUCT_HIS_V2s { get; set; }
    public virtual DbSet<V_CFG_PRODUCT_V2> V_CFG_PRODUCT_V2s { get; set; }
    public virtual DbSet<V_GLM_SLOC_PLANT_COMPANY> V_GLM_SLOC_PLANT_COMPANies { get; set; }

    public virtual DbSet<OUT_APP_APPLICATION1> OUT_APP_APPLICATION1s { get; set; }
    public virtual DbSet<OUT_APP_APPLICATION2> OUT_APP_APPLICATION2s { get; set; }
    public virtual DbSet<OUT_APP_APPLICATION3> OUT_APP_APPLICATION3s { get; set; }
    public virtual DbSet<OUT_PRODUCT_STANDARD_COST> OUT_PRODUCT_STANDARD_COSTs { get; set; }
    public virtual DbSet<V_MODELN_CUS_SHIP_TO> V_MODELN_CUS_SHIP_TOs { get; set; }
    public virtual DbSet<V_MODELN_CUS_BILL_TO> V_MODELN_CUS_BILL_TOs { get; set; }
    public virtual DbSet<OUT_PRODUCT_HISTORICAL> OUT_PRODUCT_HISTORICALs { get; set; }
    public virtual DbSet<OUT_PRODUCT_SALES_ROOT_PARTNUMBER> OUT_PRODUCT_SALES_ROOT_PARTNUMBERs { get; set; }

    public virtual DbSet<OUT_PRODUCT_WIP_SELL_PRICE> OUT_PRODUCT_WIP_SELL_PRICEs { get; set; }
    public virtual DbSet<OUT_PRODUCT_ECCN_CONVERSION> OUT_PRODUCT_ECCN_CONVERSIONs { get; set; }
    public virtual DbSet<OUT_PRODUCT_HS_CONVERSION> OUT_PRODUCT_HS_CONVERSIONs { get; set; }
    public virtual DbSet<OUT_COMPONENT> OUT_COMPONENTs { get; set; }
    public virtual DbSet<OUT_PRODUCT_VENDOR_CHAR> OUT_PRODUCT_VENDOR_CHARs { get; set; }
    public virtual DbSet<OUT_PRODUCT_MATRIX> OUT_PRODUCT_MATRices { get; set; }
    public virtual DbSet<OUT_PRODUCTION_BOM> OUT_PRODUCTION_BOMs { get; set; }
    public virtual DbSet<OUT_PRODUCTION_ROUTING> OUT_PRODUCTION_ROUTINGs { get; set; }
    public virtual DbSet<OUT_PRODUCTION_ROUTING_S4> OUT_PRODUCTION_ROUTING_S4s { get; set; }
    public virtual DbSet<OUT_PRODUCTION_VERSION> OUT_PRODUCTION_VERSIONs { get; set; }
    public virtual DbSet<OUT_PRODUCTION_ALTERNATIVES_MIX_RATIO> OUT_PRODUCTION_ALTERNATIVES_MIX_RATIOs { get; set; }
    public virtual DbSet<OUT_PRODUCTION_CYCLETIME> OUT_PRODUCTION_CYCLETIMEs { get; set; }
    public virtual DbSet<OUT_PRODUCTION_LEADTIME> OUT_PRODUCTION_LEADTIMEs { get; set; }
    public virtual DbSet<OUT_PRODUCTION_LOTSIZE> OUT_PRODUCTION_LOTSIZEs { get; set; }
    public virtual DbSet<OUT_PRODUCTION_YIELD> OUT_PRODUCTION_YIELDs { get; set; }
    public virtual DbSet<MDM_PRODUCTION_STAGE> MDM_PRODUCTION_STAGEs { get; set; }
    public virtual DbSet<MDM_PRODUCTION_STAGE_CONVERSION> MDM_PRODUCTION_STAGE_CONVERSIONs { get; set; }
    public virtual DbSet<OUT_PRODUCT_CAN_FLAGS4> OUT_PRODUCT_CAN_FLAGS4s { get; set; }
    public virtual DbSet<OUT_PRODUCT_LINE> OUT_PRODUCT_LINEs { get; set; }
    public virtual DbSet<OUT_PRODUCT_TYPE> OUT_PRODUCT_TYPEs { get; set; }
    public virtual DbSet<CFG_PRODUCT_CANFLAG> CFG_PRODUCT_CANFLAGs { get; set; }
    public virtual DbSet<RAW_CFG_PRODUCT_CANFLAG_PATTERN> RAW_CFG_PRODUCT_CANFLAG_PATTERNs { get; set; }
    public virtual DbSet<V_CFG_PRODUCT_CANFLAG_PATTERN> V_CFG_PRODUCT_CANFLAG_PATTERNs { get; set; }
    public virtual DbSet<V_CFG_PRODUCT_CANFLAG_PATTERN_HI> V_CFG_PRODUCT_CANFLAG_PATTERN_HIs { get; set; }
    public virtual DbSet<V_DASHBOARD_STATS_V2> V_DASHBOARD_STATS_V2s { get; set; }
    public virtual DbSet<V_OUT_PRODUCT_CONSOLIDATE> V_OUT_PRODUCT_CONSOLIDATEs { get; set; }
    public virtual DbSet<LOG_PUSH> LOG_PUSHes { get; set; }


    

    

    

    

    

    

    

    

    

    

    

    

    

    



























    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("FIESTAADM")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<OUT_PRODUCT_WIP_SELL_PRICE>(entity =>
        {
            entity.HasKey(e => new { e.sellingPlant, e.partNumberKey, e.validFromDate }).HasName("OUT_PROD_WIP_SELL_PK");

            entity.ToTable("OUT_PRODUCT_WIP_SELL_PRICE");

            entity.Property(e => e.sellingPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.validFromDate).HasColumnType("DATE");
            entity.Property(e => e.createDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.currency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("'N'")
                .IsFixedLength();
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.price).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("0");
            entity.Property(e => e.recordKey)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.validToDate).HasColumnType("DATE");
        });

        modelBuilder.Entity<OUT_CUS_BILL_TO>(entity =>
        {
            entity.HasKey(e => e.customerCode).HasName("OUT_CUS_BILL_TO_PK");

            entity.ToTable("OUT_CUS_BILL_TO");

            entity.Property(e => e.customerCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.accountAssignmentGroup)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.accountAtCustomer)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.attribute1)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute10)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute2)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute3)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute4)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute5)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute6)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute7)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute8)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute9)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.bpRole)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.buGroup)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.building)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.businessPartnerCategory)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.centralDeletionFlag)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.characteristicName1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.characteristicValue1)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.cityCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyIdTradingPartner)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.completeDeliveryDefined)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.countryCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.creditControlArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.currency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.customerClassification)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup1)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup2)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup3)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup4)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup5)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerName1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerName2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerName3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerName4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerOrderBlock)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.customersFactoryCalendar)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.defaultUnloadingPoint)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("'N'")
                .IsFixedLength();
            entity.Property(e => e.deliveryPriority).HasPrecision(2);
            entity.Property(e => e.distributionChannel)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.district)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.division)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.faxExtension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.faxNumber)
                .HasMaxLength(31)
                .IsUnicode(false);
            entity.Property(e => e.fiscalYearVariant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.floor)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.goodsReceivingHoursId)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.homeCity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.houseNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.identificationNumber15)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.incotermas1)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.incotermas2)
                .HasMaxLength(28)
                .IsUnicode(false);
            entity.Property(e => e.languageKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.maximumDeliveriesAllowed).HasPrecision(1);
            entity.Property(e => e.orderCombinationIndicator)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.overDeliveryTolerance)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partialDeliveryAtItemLevel)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partnerFunction)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.poBox)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.postalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.pricingProcedureAssigned)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("0");
            entity.Property(e => e.recordKey)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.regionCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.roomNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.salesOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.searchName1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.shippingConditions)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.smtpAddr)
                .HasMaxLength(241)
                .IsUnicode(false);
            entity.Property(e => e.street)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.street2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.street3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.taxJurisdiction)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.taxnumKr1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumKr2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumSg1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumTw1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumTw2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeKr1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeKr2)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeSg1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeTw1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeTw2)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.telExtension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.telNumber)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.telNumber2)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.teletexNumber)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.telexNumber)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.termsOfPaymentKey)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.textId1)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId2)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId3)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId4)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId5)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.timeZone)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.title)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.transportationZone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.unloadingPoint)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ")
                .IsFixedLength();
            entity.Property(e => e.vatNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OUT_CUS_END_CUSTOMER>(entity =>
        {
            entity.HasKey(e => e.accountNumCustomerOID).HasName("OUT_CUS_END_CUSTOMER_PK");

            entity.ToTable("OUT_CUS_END_CUSTOMER");

            entity.Property(e => e.accountNumCustomerOID)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.btAddress1)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.btAddress2)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.btAddress3)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.btAddress4)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.btAddress5)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.btCity)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.btCountry)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.btState)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.btZip)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.category)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.childId)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.currencyName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.customerLevel)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.customerType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("'N'")
                .IsFixedLength();
            entity.Property(e => e.focus)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.geography)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.hiRelAllowed)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.isTyt)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.legalName)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.location)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.parentCustomerAccount)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.parentCustomerLocation)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.parentCustomerName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.recordKey)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.sapChangePoint)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.soldToOrigin)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.status)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ")
                .IsFixedLength();
            entity.Property(e => e.webSite)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OUT_CUS_SHIP_TO>(entity =>
        {
            entity.HasKey(e => e.customerCode).HasName("OUT_CUS_SHIP_TO_PK");

            entity.ToTable("OUT_CUS_SHIP_TO");

            entity.Property(e => e.customerCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.accountAssignmentGroup)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.accountAtCustomer)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.attribute1)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute10)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute2)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute3)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute4)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute5)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute6)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute7)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute8)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute9)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.bpRole)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.buGroup)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.building)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.businessPartnerCategory)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.centralDeletionFlag)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.characteristicName1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.characteristicValue1)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.cityCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyIdTradingPartner)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.completeDeliveryDefined)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.countryCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.creditControlArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.currency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.customerClassification)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup1)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup2)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup3)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup4)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup5)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerName1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerName2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerName3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerName4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerOrderBlock)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.customersFactoryCalendar)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.defaultUnloadingPoint)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("'N'")
                .IsFixedLength();
            entity.Property(e => e.deliveryPriority).HasPrecision(2);
            entity.Property(e => e.distributionChannel)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.district)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.division)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.faxExtension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.faxNumber)
                .HasMaxLength(31)
                .IsUnicode(false);
            entity.Property(e => e.fiscalYearVariant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.floor)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.goodsReceivingHoursId)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.homeCity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.houseNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.identificationNumber15)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.incotermas1)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.incotermas2)
                .HasMaxLength(28)
                .IsUnicode(false);
            entity.Property(e => e.languageKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.maximumDeliveriesAllowed).HasPrecision(1);
            entity.Property(e => e.orderCombinationIndicator)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.overDeliveryTolerance)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partialDeliveryAtItemLevel)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partnerFunction)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.poBox)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.postalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.pricingProcedureAssigned)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("0");
            entity.Property(e => e.recordKey)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.regionCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.roomNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.salesOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.searchName1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.shippingConditions)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.smtpAddr)
                .HasMaxLength(241)
                .IsUnicode(false);
            entity.Property(e => e.street)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.street2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.street3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.taxJurisdiction)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.taxnumKr1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumKr2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumSg1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumTw1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumTw2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeKr1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeKr2)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeSg1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeTw1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeTw2)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.telExtension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.telNumber)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.telNumber2)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.teletexNumber)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.telexNumber)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.termsOfPaymentKey)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.textId1)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId2)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId3)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId4)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId5)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.timeZone)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.title)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.transportationZone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.unloadingPoint)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.vatNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OUT_CUS_SOLD_TO>(entity =>
        {
            entity.HasKey(e => e.customerCode).HasName("OUT_CUS_SOLD_TO_PK");

            entity.ToTable("OUT_CUS_SOLD_TO");

            entity.Property(e => e.customerCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.accountAssignmentGroup)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.accountAtCustomer)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.attribute1)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute10)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute2)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute3)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute4)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute5)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute6)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute7)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute8)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute9)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.bpRole)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.buGroup)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.building)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.businessPartnerCategory)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.centralDeletionFlag)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.characteristicName1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.characteristicValue1)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.cityCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyIdTradingPartner)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.completeDeliveryDefined)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.countryCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.creditControlArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.currency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.customerClassification)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup1)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup2)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup3)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup4)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup5)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerName1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerName2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerName3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerName4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerOrderBlock)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.customersFactoryCalendar)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.defaultUnloadingPoint)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("'N'")
                .IsFixedLength();
            entity.Property(e => e.deliveryPriority).HasPrecision(2);
            entity.Property(e => e.distributionChannel)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.district)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.division)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.faxExtension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.faxNumber)
                .HasMaxLength(31)
                .IsUnicode(false);
            entity.Property(e => e.fiscalYearVariant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.floor)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.goodsReceivingHoursId)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.homeCity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.houseNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.identificationNumber15)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.incotermas1)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.incotermas2)
                .HasMaxLength(28)
                .IsUnicode(false);
            entity.Property(e => e.languageKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.maximumDeliveriesAllowed).HasPrecision(1);
            entity.Property(e => e.orderCombinationIndicator)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.overDeliveryTolerance)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.parentCustomerAccount)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.partialDeliveryAtItemLevel)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partnerFunction)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.poBox)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.postalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.pricingProcedureAssigned)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.regionCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.roomNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.salesOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.searchName1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.shippingConditions)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.smtpAddr)
                .HasMaxLength(241)
                .IsUnicode(false);
            entity.Property(e => e.street)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.street2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.street3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.taxJurisdiction)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.taxnumKr1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumKr2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumSg1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumTw1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumTw2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeKr1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeKr2)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeSg1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeTw1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeTw2)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.telExtension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.telNumber)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.telNumber2)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.teletexNumber)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.telexNumber)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.termsOfPaymentKey)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.textId1)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId2)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId3)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId4)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId5)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.timeZone)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.title)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.transportationZone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.unloadingPoint)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.vatNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OUT_FIN_COST_CENTER>(entity =>
        {
            entity.HasKey(e => new { e.coArea, e.costCenter, e.paymentCardsValidTo }).HasName("OUT_FIN_COST_CENTER_PK");
            entity.ToTable("OUT_FIN_COST_CENTER");
            entity.Property(e => e.coArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.costCenter)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.paymentCardsValidTo).HasColumnType("DATE");
            entity.Property(e => e.businessArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.completionFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.costCenterCategory)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.costCenterShortText)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.country)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createOn).HasColumnType("DATE");
            entity.Property(e => e.currency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ")
                .IsFixedLength();
            entity.Property(e => e.description)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.effectiveDate).HasColumnType("DATE");
            entity.Property(e => e.functionalArea)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.indicatorForAllowedAllocationMethods)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.indicatorForRecordingConsumptionQuantities)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lockIndicatorForActualPrimaryPostings)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lockIndicatorForActualRevenuePostings)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lockIndicatorForActualSecondaryCosts)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lockIndicatorForCommitmentUpdate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lockIndicatorForPlanPrimaryCosts)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lockIndicatorForPlanSecondaryCosts)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lockIndicatorForPlanningRevenues)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.objectNumber)
                .HasMaxLength(22)
                .IsUnicode(false);
            entity.Property(e => e.personResponsible)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.profitCenter)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.profitCenterArea)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.userName)
                .HasMaxLength(12)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OUT_FIN_IP_CUSTOMER>(entity =>
        {
            entity.HasKey(e => new { e.ipLicenseNumber, e.customerCode, e.validityFromDate }).HasName("OUT_FIN_IP_CUSTOMER_PK");

            entity.ToTable("OUT_FIN_IP_CUSTOMER");

            entity.Property(e => e.ipLicenseNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.customerCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.validityFromDate).HasColumnType("DATE");
            entity.Property(e => e.createDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createdBy)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.createdOn).HasColumnType("DATE");
            entity.Property(e => e.customerName)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("'N'")
                .IsFixedLength();
            entity.Property(e => e.lastChangedBy)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.lastChangedOn).HasColumnType("DATE");
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("0");
            entity.Property(e => e.recordKey)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.status)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.validityToDate).HasColumnType("DATE");
        });

        modelBuilder.Entity<OUT_FIN_IP_OPN>(entity =>
        {
            entity.HasKey(e => new { e.partNumberKey, e.ipLicenseCode }).HasName("OUT_FIN_IP_OPN_PK");

            entity.ToTable("OUT_FIN_IP_OPN");

            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.ipLicenseCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("'N'")
                .IsFixedLength();
            entity.Property(e => e.ipVendorName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("0");
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.techName)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<OUT_PRODUCT_STANDARD_COST>(entity =>
        {
            entity.HasKey(e => new { e.companyCode, e.postingDate, e.plant, e.partNumberKey }).HasName("OUT_PRODUCT_STD_COST_PK");

            entity.ToTable("OUT_PRODUCT_STANDARD_COST");

            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.postingDate).HasColumnType("DATE");
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.companyCodeCurrency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.companyCodeCurrencyLegalValuation).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.createDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("'N'")
                .IsFixedLength();
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.priceUnit).HasPrecision(5);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("0");
            entity.Property(e => e.recordKey)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<OUT_VEN_VENDOR>(entity =>
        {
            entity.HasKey(e => e.vendorNumber).HasName("OUT_VENDOR_PK");

            entity.ToTable("OUT_VEN_VENDOR");

            entity.Property(e => e.vendorNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.abcIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.accountNumberAtVendor)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.acknowledgementReqd)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.autoEvalGRSetmtDel)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.autoevalgrsetmtRet)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.automaticPurchaseOrder)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.bankFeeCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.buildingCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.coName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.companyIDTradingPartner)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.companyPostalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.confirmationControl)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.country)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.creationDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.customerNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.dataLine)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("'N'")
                .IsFixedLength();
            entity.Property(e => e.deletionIndicatorCommon)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.differentCity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.district)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.email)
                .HasMaxLength(241)
                .IsUnicode(false);
            entity.Property(e => e.fax)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.faxExtension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.floor)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.generalTelephone)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.grBasedInvVeri)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.houseNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.houseNumberSupplement)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.inco2)
                .HasMaxLength(28)
                .IsUnicode(false);
            entity.Property(e => e.incoterms)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.languageKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.minimumOrderValue)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.modeOfTransprtBorder)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.name2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.name3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.name4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.officeOfEntry)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.orderCurrency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.otherCity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partnerFunction1)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.partnerNumber1)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.plannedDelivTime)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.poBox)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.postalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.postalCode2)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.pricingDateControl)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("0");
            entity.Property(e => e.purchasingGroup)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.purchasingOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.purchasingTelephone)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.region)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.relevantForPriceDetVendorHierarchy)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.returnsVendor)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.room)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.salesperson)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.schemaGroupVendor)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.searchTerm12)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.searchTerm2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.sortCriterion)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.standardCommMethod)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.street2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.street3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.street4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.street5)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.streetHouseNumber)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.subsequentSettlement)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.taxJurisdictn)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.taxNumber)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.taxNumber1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.taxNumber2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.taxNumber3)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.taxOffice)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.telebox)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.telephoneExtension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.termsOfPayment)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.timeZone)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.title)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.transportationZone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<OUT_VEN_VENDOR_COMPANY>(entity =>
        {
            entity.HasKey(e => new { e.vendorNumber, e.companyCode }).HasName("OUT_VEN_VENDOR_COMP_PK");

            entity.ToTable("OUT_VEN_VENDOR_COMPANY");

            entity.Property(e => e.vendorNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.accountMemo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.accountNumberAtVendor)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.accountWithVendor)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.accountingClerk)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.accountingClerkFax)
                .HasMaxLength(31)
                .IsUnicode(false);
            entity.Property(e => e.acctStatement)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.acctingClerkTelephone)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.alternativePayee)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.authorizationGroup)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.autoEvalGRSetmtDel)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.autoevalgrsetmtRet)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.automaticPurchaseOrder)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.bankFeeCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.checkCashingTime)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.checkDoubleInvoice)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.clearingWithCust)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.clerkAtVendor)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.clerkInternetAddress)
                .HasMaxLength(130)
                .IsUnicode(false);
            entity.Property(e => e.companyIDTradingPartner)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.confirmationControl)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.country)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.creationDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.creditMemoPytTerm)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.customerNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.dateOfLastInterestRun).HasColumnType("DATE");
            entity.Property(e => e.deleteDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("'N'")
                .IsFixedLength();
            entity.Property(e => e.deletionFlag)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.deletionIndicatorCommon)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.district)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.dunningProcedure)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.fax)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.generalTelephone)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.grBasedInvVeri)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.groupingKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.headOffice)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.houseBank)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.inco2)
                .HasMaxLength(28)
                .IsUnicode(false);
            entity.Property(e => e.incoterms)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.individualPayment)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.interestCalcFrequency)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.interestIndicator)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.keyDateOfLastIntCalc).HasColumnType("DATE");
            entity.Property(e => e.minorityIndicator)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.name2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.name3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.name4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.orderCurrency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.paymentAdviceByEdi)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.paymentBlock)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.paymentGroupKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.paymentMethSupplement)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.paymentMethods)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.personnelNumber)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.planningGroup)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.poBox)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.postalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.postalCode2)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.postingBlock)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.previousAccountNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("0");
            entity.Property(e => e.purchasingOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.purchasingTelephone)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.reconciliationAcct)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.region)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.salesperson)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.schemaGroupVendor)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.searchTerm12)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.searchTerm2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.sortKey)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.street2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.street3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.street4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.street5)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.streetHouseNumber)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.termsOfPayment)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.toleranceGroup)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ")
                .IsFixedLength();
        });

        modelBuilder.Entity<OUT_VEN_VENDOR_PURCHASE_INFO_REC>(entity =>
        {
            entity.HasKey(e => new { e.number, e.purchasingOrganization, e.plant, e.category, e.partNumberKey, e.vendorAccountNumber, e.validFromDate }).HasName("OUT_VEN_VENDOR_PURCHASE_INFO_REC_PK");
            entity.ToTable("OUT_VEN_VENDOR_PURCHASE_INFO_REC");
            entity.Property(e => e.number)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.purchasingOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.category)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.vendorAccountNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.validFromDate).HasColumnType("DATE");
            entity.Property(e => e.actualUnitPriceInThePreviousPeriod).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.additionalPlantAndStorageLocationExtension)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.availableDeliverableFrom).HasColumnType("DATE");
            entity.Property(e => e.availableDeliverableUntil).HasColumnType("DATE");
            entity.Property(e => e.baseUnitOfMeasure)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.baseUnitOfMeasureQuantity).HasPrecision(13);
            entity.Property(e => e.conditionType1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.conditionType1Amount).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.conditionType2)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.conditionType2Amount).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.conditionType3)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.conditionType3Amount).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.conditionType4)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.conditionType4Amount).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.conditionType5)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.conditionType5Amount).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.countryOfOrigin)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.currency)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.currencyCode)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasDefaultValueSql("0")
                .HasPrecision(1);
            entity.Property(e => e.denominatorForConvOfOrderPriceUnitIntoOrderUnit).HasPrecision(5);
            entity.Property(e => e.denominatorForConversionOfOrderPriceUnitIntoOrderUnit).HasPrecision(5);
            entity.Property(e => e.documentNumber)
                .HasMaxLength(22)
                .IsUnicode(false);
            entity.Property(e => e.documentVersion)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.effectivePrice).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.environmentallyRelevant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.indicatorForFieldSequence)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.indicatorForGRBasedInvoiceVerification)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lineNoOfShelfLifeExpirationDate)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.materialFreightGroup)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.materialGroup)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.materialGroupDescription)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.materialNumberUsedByVendor)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.materialPOTextDrawingNumber)
                .HasMaxLength(28)
                .IsUnicode(false);
            entity.Property(e => e.materialPOTextSecondaryNumber)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.minimumPurchaseOrderQuantity).HasPrecision(15);
            entity.Property(e => e.netPrice).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.numeratorForConvOfOrderPriceUnitIntoOrderUnit).HasPrecision(5);
            entity.Property(e => e.numeratorForConversionOfOrderPriceUnitIntoOrderUnit).HasPrecision(5);
            entity.Property(e => e.orderPriceUnitPurchasing)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.overdeliveryToleranceLimit).HasPrecision(3);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.plannedDeliveryTimeInDays).HasPrecision(3);
            entity.Property(e => e.priceDetermination)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.priceUnit).HasPrecision(5);
            entity.Property(e => e.priorVendor)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("0");
            entity.Property(e => e.purchaseOrderUnitOfMeasure)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.purchasingGroup)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.purchasingGroupCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.recordRegisteredDate).HasColumnType("DATE");
            entity.Property(e => e.returnAgreement)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.shippingInstructions)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.shortText)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.standardText)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.underdeliveryToleranceLimit).HasPrecision(3);
            entity.Property(e => e.updateDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.validToDate).HasColumnType("DATE");
            entity.Property(e => e.validityFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.vatCode)
                .HasMaxLength(2)
                .IsUnicode(false);
        });;;;;;

        modelBuilder.Entity<CFG_APP_APPLICATION1>(entity =>
        {
            entity.HasKey(e => e.applicationLevel1Code).HasName("CFG_APP_APPLICATION1_PK");
            entity.ToTable("CFG_APP_APPLICATION1");
            entity.Property(e => e.applicationLevel1Code)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel1Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        }); ;

        modelBuilder.Entity<CFG_APP_APPLICATION2>(entity =>
        {
            entity.HasKey(e => e.applicationLevel2Code).HasName("CFG_APP_APPLICATION2_PK");
            entity.ToTable("CFG_APP_APPLICATION2");
            entity.Property(e => e.applicationLevel2Code)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel1Code)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel2Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        }); ;

        modelBuilder.Entity<CFG_APP_APPLICATION3>(entity =>
        {
            entity.HasKey(e => e.applicationLevel3Code).HasName("CFG_APP_APPLICATION3_PK");
            entity.ToTable("CFG_APP_APPLICATION3");
            entity.Property(e => e.applicationLevel3Code)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel2Code)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel3Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        }); ;

        modelBuilder.Entity<V_CFG_APP_APPLICATION1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_APP_APPLICATION1");
            entity.Property(e => e.applicationLevel1Code)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel1Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        }); ; ; ; ;

        modelBuilder.Entity<V_CFG_APP_APPLICATION1_HI>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_APP_APPLICATION1_HIS");
            entity.Property(e => e.CFG_APP_APPLICATION1_HIS_DATE).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.CFG_APP_APPLICATION1_HIS_DELEGATE)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CFG_APP_APPLICATION1_HIS_ID)
                .HasColumnType("NUMBER");
            entity.Property(e => e.CFG_APP_APPLICATION1_HIS_USERID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel1Code)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel1Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
        }); ;

        modelBuilder.Entity<V_CFG_APP_APPLICATION2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_APP_APPLICATION2");
            entity.Property(e => e.applicationLevel1Code)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel2Code)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel2Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        }); ; ; ; ;

        modelBuilder.Entity<V_CFG_APP_APPLICATION2_HI>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_APP_APPLICATION2_HIS");
            entity.Property(e => e.CFG_APP_APPLICATION2_HIS_DATE).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.CFG_APP_APPLICATION2_HIS_DELEGATE)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CFG_APP_APPLICATION2_HIS_ID)
                .HasColumnType("NUMBER");
            entity.Property(e => e.CFG_APP_APPLICATION2_HIS_USERID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel1Code)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel2Code)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel2Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
        }); ;

        modelBuilder.Entity<V_CFG_APP_APPLICATION3>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_APP_APPLICATION3");
            entity.Property(e => e.applicationLevel2Code)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel3Code)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel3Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        }); ; ; ; ;

        modelBuilder.Entity<V_CFG_APP_APPLICATION3_HI>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_APP_APPLICATION3_HIS");
            entity.Property(e => e.CFG_APP_APPLICATION3_HIS_DATE).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.CFG_APP_APPLICATION3_HIS_DELEGATE)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CFG_APP_APPLICATION3_HIS_ID)
                .HasColumnType("NUMBER");
            entity.Property(e => e.CFG_APP_APPLICATION3_HIS_USERID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel2Code)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel3Code)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel3Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
        }); ;



        modelBuilder.Entity<RAW_CFG_APP_APPLICATION1>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RAW_CFG_APP_APPLICATION1");
            entity.Property(e => e.applicationLevel1Code)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel1Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createdBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.createdDate)
                .HasDefaultValueSql("SYSTIMESTAMP")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.errorMessage).IsUnicode(false);
            entity.Property(e => e.haveDifference).HasPrecision(1);
            entity.Property(e => e.haveError).HasPrecision(1);
            entity.Property(e => e.insertOrUpdate)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
        }); ; ;

        modelBuilder.Entity<RAW_CFG_APP_APPLICATION2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RAW_CFG_APP_APPLICATION2");
            entity.Property(e => e.applicationLevel1Code)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel2Code)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel2Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createdBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.createdDate)
                .HasDefaultValueSql("SYSTIMESTAMP")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.errorMessage).IsUnicode(false);
            entity.Property(e => e.haveDifference).HasPrecision(1);
            entity.Property(e => e.haveError).HasPrecision(1);
            entity.Property(e => e.insertOrUpdate)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
        }); ;

        modelBuilder.Entity<RAW_CFG_APP_APPLICATION3>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RAW_CFG_APP_APPLICATION3");
            entity.Property(e => e.applicationLevel2Code)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel3Code)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel3Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createdBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.createdDate)
                .HasDefaultValueSql("SYSTIMESTAMP")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.errorMessage).IsUnicode(false);
            entity.Property(e => e.haveDifference).HasPrecision(1);
            entity.Property(e => e.haveError).HasPrecision(1);
            entity.Property(e => e.insertOrUpdate)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
        }); ;

        modelBuilder.Entity<CFG_COMPANY_CODE>(entity =>
        {
            entity.HasKey(e => e.companyCode).HasName("CFG_COMPANY_CODE_PK");
            entity.ToTable("CFG_COMPANY_CODE");
            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.acctsRecblePledActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activateAADerivation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'1' ");
            entity.Property(e => e.address)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.alternativeCOA)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.baVariant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.businessAreaFinStatements)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.cashManagementActivated)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.cashManagementCompanyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.chartOfAccounts)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.coArea)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.company)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.companyCodeIsProductive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.companyName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.contract)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.controlAreaCanBeInput)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.copyingControlGoodsReceipt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.costOfSalesAccountingActv)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.countryRegionKey)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.creditControlArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.cshBdgtMgtActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.currency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.deferredTaxRule)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.defineDefaultValueDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.discountBaseIsNetValue)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.documentEntryScreenVariant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.documentTypeForJVAmountCorrection)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.documentTypeForJVTaxCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.documentTypeForProvisionsForTaxes)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.enableAmountSplit)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.extendedWithholdingTaxActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.externalCoCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.fdsCtrActiveInHR)
                .HasColumnType("DATE");
            entity.Property(e => e.fieldStatusVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.financialAssetsMgmtActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.fiscalYearVariant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.fmArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.fundsReservationFieldStatusVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.globalCoCde)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.hedgeRequestActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.hideEntryInInputHelp)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.importDataGoodsReceipt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.importDataInPurchaseOrder)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.inflationMethod)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.inputTaxCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.inventoryManagement)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.jurisdictionCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.jvAccountingActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.languageKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.managePostingPeriodForCoCodeLedger)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.maxExchangeRateDeviation)
                .HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.methodOffsttngAcct)
                .HasColumnType("NUMBER(15,1)");
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.negativePostingsPermitted)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.noExchRateDiffWhenClearingInLC)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.originalKey)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.outputTaxCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.poSchedulingAgmt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.postTranslation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.postingDateForParking)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.projectCashMgmtActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.proposeFiscalYear)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pstngPeriodVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.purchaseAccountProcessing)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.purchaseRequisition)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.remittanceChallanDocumentType)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.reviewBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.sampleAcctRulesVar)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.shoppingCart)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.surchargeMethod)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxBaseIsNetValue)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxCrcyTranslation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxDetermwithDocDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxReportingDateActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxesOnSlsPurc)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.template)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.transitPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateFM)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateMMInCMF)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateSDInCMF)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.vatRegistrationNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.workflowVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CFG_PLANT>(entity =>
        {
            entity.HasKey(e => e.plant).HasName("CFG_PLANTS_PK");
            entity.ToTable("CFG_PLANTS");
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.activateVariantGrouping)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'1' ");
            entity.Property(e => e.actualActivitiesUpdated)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.actualCosting)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.address)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.afSrceDetViaATP)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.archivingMarker)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.assignBatchesInARun)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchManagementNotActiveByDefault)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchRecDMSType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchStatusMgmt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchStatusMgmtOld)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.businessPlace)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.cityCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.company)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.condsAtPlantLevel)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.controlDataForBOM)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.controlOfCreditOfCostCenters)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.costObjControlling)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.countryRegionKey)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.countyCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.credIPI)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.customerNumberOfPlant)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.distribProfileOfPlant)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.distribchannel)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.exchangeValuation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.factoryCalendar)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.firstReminderExped)
                .HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.intCOBillingDiv)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.languageKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.mixedCosting)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.name1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.name2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.namingStructure)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.nodeTypesupplyChain)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.ownership)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.planningPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plantCat)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.poBox)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.poTolerance)
                .HasColumnType("NUMBER(15,3)");
            entity.Property(e => e.postalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.purchOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.region)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.regularSupplier)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.reqmtsPlanning)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.reviewBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.salesAreaDetrm)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.salesDistrict)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.salesOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.seasonActiveInInventoryManagement)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.secondReminderExped)
                .HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.shippingPointReceivingPt)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.sopPlant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.sourceList)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.storeCat)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.streetAndHouseNumber)
                .HasMaxLength(31)
                .IsUnicode(false);
            entity.Property(e => e.superiorDeptStore)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.supplierNumberOfPlant)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.supplyAssignmentARun)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.supplyRegion)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.taxIndicatorPlant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxJurisdiction)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.text1stDunning)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.text2ndDunning)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.text3rdDunning)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.thirdReminderExped)
                .HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.updateDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.valuationArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.varianceKey)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.vendorType)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CFG_PRODUCTION_GROUP_STAGE>(entity =>
        {
            entity.HasKey(e => e.groupStage).HasName("CFG_PRODUCTION_GROUP_STAGE_PK");
            entity.ToTable("CFG_PRODUCTION_GROUP_STAGE");
            entity.Property(e => e.groupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'1' ");
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.groupStageExplanation)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.groupStageName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.groupStageRecordID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.groupStageSequence)
                .HasColumnType("NUMBER(15,10)");
            entity.Property(e => e.groupStageType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.inputUoM)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.outputUoM)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        });

        modelBuilder.Entity<CFG_PRODUCTION_GROUP_STAGE_CONVERSION>(entity =>
        {
            entity.HasKey(e => new { e.groupStage, e.legacyType, e.legacyGroupStage }).HasName("CFG_PRODUCTION_GROUP_STAGE_CONVERSION_PK");
            entity.ToTable("CFG_PRODUCTION_GROUP_STAGE_CONVERSION");
            entity.Property(e => e.groupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.legacyType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.legacyGroupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'1' ");
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.groupStageVSLegacyGroupStageRecordID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        });

        modelBuilder.Entity<CFG_PRODUCTION_PLANT_CONVERSION>(entity =>
        {
            entity.HasKey(e => new { e.company, e.plant, e.storageLocation, e.legacyType, e.legacyLine, e.groupStage, e.massProductionFlag }).HasName("CFG_PRODUCTION_PLANT_CONVERSION_PK");
            entity.ToTable("CFG_PRODUCTION_PLANT_CONVERSION");
            entity.Property(e => e.company)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.legacyType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.legacyLine)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.groupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.massProductionFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'1' ");
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.hmeType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.plantAndSlocVsLegacyLineRecordID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        });

        modelBuilder.Entity<CFG_STORAGE_LOCATION>(entity =>
        {
            entity.HasKey(e => new { e.plant, e.storageLocation }).HasName("CFG_STORAGE_LOCATION_PK");
            entity.ToTable("CFG_STORAGE_LOCATION");
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'1' ");
            entity.Property(e => e.authorizationCheck)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.businessSystemOfMES)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.countryCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customer)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.descrOfStorageLoc)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.distributionChannel)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.division)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.freezeBookInvSLoc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.glmPlantCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.huReqmnt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.inTransitAssignment)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.inventoryManagementType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.licenseNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.negStocksInSLoc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partnerStorLoc)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.region)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.reviewBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.sLocMRPIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.salesOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.shippingPointReceivingPt)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageLocationType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.storageResource)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.supplier)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.tankAssgn)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.timeZone)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.validity)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RAW_CFG_COMPANY_CODE>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RAW_CFG_COMPANY_CODE");
            entity.Property(e => e.acctsRecblePledActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activateAADerivation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'1' ");
            entity.Property(e => e.address)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.alternativeCOA)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.baVariant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.businessAreaFinStatements)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.cashManagementActivated)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.cashManagementCompanyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.chartOfAccounts)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.coArea)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.company)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyCodeIsProductive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.companyName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.contract)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.controlAreaCanBeInput)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.copyingControlGoodsReceipt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.costOfSalesAccountingActv)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.countryRegionKey)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createdDate)
                .HasDefaultValueSql("SYSTIMESTAMP")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.creditControlArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.cshBdgtMgtActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.currency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.deferredTaxRule)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.defineDefaultValueDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.discountBaseIsNetValue)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.documentEntryScreenVariant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.documentTypeForJVAmountCorrection)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.documentTypeForJVTaxCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.documentTypeForProvisionsForTaxes)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.enableAmountSplit)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.errorMessage).IsUnicode(false);
            entity.Property(e => e.extendedWithholdingTaxActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.externalCoCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.fdsCtrActiveInHR).HasColumnType("DATE");
            entity.Property(e => e.fieldStatusVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.financialAssetsMgmtActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.fiscalYearVariant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.fmArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.fundsReservationFieldStatusVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.globalCoCde)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.haveDifference).HasPrecision(1);
            entity.Property(e => e.haveError).HasPrecision(1);
            entity.Property(e => e.hedgeRequestActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.hideEntryInInputHelp)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.importDataGoodsReceipt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.importDataInPurchaseOrder)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.inflationMethod)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.inputTaxCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.insertOrUpdate)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.inventoryManagement)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.jurisdictionCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.jvAccountingActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.languageKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.managePostingPeriodForCoCodeLedger)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.maxExchangeRateDeviation).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.methodOffsttngAcct).HasColumnType("NUMBER(15,1)");
            entity.Property(e => e.negativePostingsPermitted)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.noExchRateDiffWhenClearingInLC)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.originalKey)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.outputTaxCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.poSchedulingAgmt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.postTranslation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.postingDateForParking)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.projectCashMgmtActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.proposeFiscalYear)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pstngPeriodVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.purchaseAccountProcessing)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.purchaseRequisition)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.remittanceChallanDocumentType)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.sampleAcctRulesVar)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.shoppingCart)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.surchargeMethod)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxBaseIsNetValue)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxCrcyTranslation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxDetermwithDocDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxReportingDateActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxesOnSlsPurc)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.template)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.transitPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.updateFM)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateMMInCMF)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateSDInCMF)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.vatRegistrationNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.workflowVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
        }); ; ;

        modelBuilder.Entity<RAW_CFG_PLANT>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RAW_CFG_PLANTS");
            entity.Property(e => e.activateVariantGrouping)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'1' ");
            entity.Property(e => e.actualActivitiesUpdated)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.actualCosting)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.address)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.afSrceDetViaATP)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.archivingMarker)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.assignBatchesInARun)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchManagementNotActiveByDefault)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchRecDMSType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchStatusMgmt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchStatusMgmtOld)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.businessPlace)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.cityCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.company)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.condsAtPlantLevel)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.controlDataForBOM)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.controlOfCreditOfCostCenters)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.costObjControlling)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.countryRegionKey)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.countyCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createdDate)
                .HasDefaultValueSql("SYSTIMESTAMP")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.credIPI)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.customerNumberOfPlant)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.distribProfileOfPlant)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.distribchannel)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.errorMessage).IsUnicode(false);
            entity.Property(e => e.exchangeValuation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.factoryCalendar)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.firstReminderExped).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.haveDifference).HasPrecision(1);
            entity.Property(e => e.haveError).HasPrecision(1);
            entity.Property(e => e.insertOrUpdate)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.intCOBillingDiv)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.languageKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.mixedCosting)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.name1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.name2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.namingStructure)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.nodeTypesupplyChain)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.ownership)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.planningPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plantCat)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.poBox)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.poTolerance).HasColumnType("NUMBER(15,3)");
            entity.Property(e => e.postalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.purchOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.region)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.regularSupplier)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.reqmtsPlanning)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.salesAreaDetrm)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.salesDistrict)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.salesOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.seasonActiveInInventoryManagement)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.secondReminderExped).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.shippingPointReceivingPt)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.sopPlant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.sourceList)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.storeCat)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.streetAndHouseNumber)
                .HasMaxLength(31)
                .IsUnicode(false);
            entity.Property(e => e.superiorDeptStore)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.supplierNumberOfPlant)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.supplyAssignmentARun)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.supplyRegion)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.taxIndicatorPlant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxJurisdiction)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.text1stDunning)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.text2ndDunning)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.text3rdDunning)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.thirdReminderExped).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.valuationArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.varianceKey)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.vendorType)
                .HasMaxLength(1)
                .IsUnicode(false);
        }); ; ;

        modelBuilder.Entity<RAW_CFG_PRODUCTION_GROUP_STAGE>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RAW_CFG_PRODUCTION_GROUP_STAGE");
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'1' ");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createdDate)
                .HasDefaultValueSql("SYSTIMESTAMP")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.errorMessage).IsUnicode(false);
            entity.Property(e => e.groupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.groupStageExplanation)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.groupStageName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.groupStageRecordID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.groupStageSequence).HasColumnType("NUMBER(15,10)");
            entity.Property(e => e.groupStageType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.haveDifference).HasPrecision(1);
            entity.Property(e => e.haveError).HasPrecision(1);
            entity.Property(e => e.inputUoM)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.insertOrUpdate)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.outputUoM)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
        }); ; ;

        modelBuilder.Entity<RAW_CFG_PRODUCTION_GROUP_STAGE_CONVERSION>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RAW_CFG_PRODUCTION_GROUP_STAGE_CONVERSION");
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'1' ");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createdDate)
                .HasDefaultValueSql("SYSTIMESTAMP")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.errorMessage).IsUnicode(false);
            entity.Property(e => e.groupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.groupStageVSLegacyGroupStageRecordID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.haveDifference).HasPrecision(1);
            entity.Property(e => e.haveError).HasPrecision(1);
            entity.Property(e => e.insertOrUpdate)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.legacyGroupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.legacyType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
        }); ; ;

        modelBuilder.Entity<RAW_CFG_PRODUCTION_PLANT_CONVERSION>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RAW_CFG_PRODUCTION_PLANT_CONVERSION");
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'1' ");
            entity.Property(e => e.company)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createdDate)
                .HasDefaultValueSql("SYSTIMESTAMP")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.errorMessage).IsUnicode(false);
            entity.Property(e => e.groupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.haveDifference).HasPrecision(1);
            entity.Property(e => e.haveError).HasPrecision(1);
            entity.Property(e => e.hmeType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.insertOrUpdate)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.legacyLine)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.legacyType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.massProductionFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plantAndSlocVsLegacyLineRecordID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
        }); ; ;

        modelBuilder.Entity<RAW_CFG_STORAGE_LOCATION>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RAW_CFG_STORAGE_LOCATION");
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'1' ");
            entity.Property(e => e.authorizationCheck)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.businessSystemOfMES)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.countryCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createdDate)
                .HasDefaultValueSql("SYSTIMESTAMP")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.customer)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.descrOfStorageLoc)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.distributionChannel)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.division)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.errorMessage).IsUnicode(false);
            entity.Property(e => e.freezeBookInvSLoc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.glmPlantCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.haveDifference).HasPrecision(1);
            entity.Property(e => e.haveError).HasPrecision(1);
            entity.Property(e => e.huReqmnt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.inTransitAssignment)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.insertOrUpdate)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.inventoryManagementType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.licenseNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.negStocksInSLoc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partnerStorLoc)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.region)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.sLocMRPIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.salesOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.shippingPointReceivingPt)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageLocationType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.storageResource)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.supplier)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.tankAssgn)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.timeZone)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.validity)
                .HasMaxLength(1)
                .IsUnicode(false);
        }); ; ;

        modelBuilder.Entity<V_CFG_COMPANY_CODE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_COMPANY_CODE");
            entity.Property(e => e.acctsRecblePledActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activateAADerivation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.address)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.alternativeCOA)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.baVariant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.businessAreaFinStatements)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.cashManagementActivated)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.cashManagementCompanyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.chartOfAccounts)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.coArea)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.company)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyCodeIsProductive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.companyName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.contract)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.controlAreaCanBeInput)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.copyingControlGoodsReceipt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.costOfSalesAccountingActv)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.countryRegionKey)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.creditControlArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.cshBdgtMgtActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.currency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.deferredTaxRule)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.defineDefaultValueDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.discountBaseIsNetValue)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.documentEntryScreenVariant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.documentTypeForJVAmountCorrection)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.documentTypeForJVTaxCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.documentTypeForProvisionsForTaxes)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.enableAmountSplit)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.extendedWithholdingTaxActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.externalCoCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.fdsCtrActiveInHR).HasColumnType("DATE");
            entity.Property(e => e.fieldStatusVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.financialAssetsMgmtActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.fiscalYearVariant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.fmArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.fundsReservationFieldStatusVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.globalCoCde)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.hedgeRequestActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.hideEntryInInputHelp)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.importDataGoodsReceipt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.importDataInPurchaseOrder)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.inflationMethod)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.inputTaxCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.inventoryManagement)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.jurisdictionCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.jvAccountingActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.languageKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.managePostingPeriodForCoCodeLedger)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.maxExchangeRateDeviation).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.methodOffsttngAcct).HasColumnType("NUMBER(15,1)");
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.negativePostingsPermitted)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.noExchRateDiffWhenClearingInLC)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.originalKey)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.outputTaxCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.poSchedulingAgmt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.postTranslation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.postingDateForParking)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.projectCashMgmtActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.proposeFiscalYear)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pstngPeriodVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.purchaseAccountProcessing)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.purchaseRequisition)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.remittanceChallanDocumentType)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.sampleAcctRulesVar)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.shoppingCart)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.surchargeMethod)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxBaseIsNetValue)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxCrcyTranslation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxDetermwithDocDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxReportingDateActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxesOnSlsPurc)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.template)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.transitPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateFM)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateMMInCMF)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateSDInCMF)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.vatRegistrationNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.workflowVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
        }); ; ;

        modelBuilder.Entity<V_CFG_COMPANY_CODE_HI>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_COMPANY_CODE_HIS");
            entity.Property(e => e.CFG_COMPANY_CODE_HIS_DATE).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.CFG_COMPANY_CODE_HIS_DELEGATE)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CFG_COMPANY_CODE_HIS_ID)
                .HasColumnType("NUMBER");
            entity.Property(e => e.CFG_COMPANY_CODE_HIS_USERID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.acctsRecblePledActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activateAADerivation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.address)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.alternativeCOA)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.baVariant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.businessAreaFinStatements)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.cashManagementActivated)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.cashManagementCompanyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.chartOfAccounts)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.coArea)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.company)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyCodeIsProductive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.companyName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.contract)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.controlAreaCanBeInput)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.copyingControlGoodsReceipt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.costOfSalesAccountingActv)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.countryRegionKey)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.creditControlArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.cshBdgtMgtActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.currency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.deferredTaxRule)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.defineDefaultValueDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.discountBaseIsNetValue)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.documentEntryScreenVariant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.documentTypeForJVAmountCorrection)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.documentTypeForJVTaxCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.documentTypeForProvisionsForTaxes)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.enableAmountSplit)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.extendedWithholdingTaxActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.externalCoCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.fdsCtrActiveInHR).HasColumnType("DATE");
            entity.Property(e => e.fieldStatusVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.financialAssetsMgmtActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.fiscalYearVariant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.fmArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.fundsReservationFieldStatusVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.globalCoCde)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.hedgeRequestActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.hideEntryInInputHelp)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.importDataGoodsReceipt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.importDataInPurchaseOrder)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.inflationMethod)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.inputTaxCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.inventoryManagement)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.jurisdictionCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.jvAccountingActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.languageKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.managePostingPeriodForCoCodeLedger)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.maxExchangeRateDeviation).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.methodOffsttngAcct).HasColumnType("NUMBER(15,1)");
            entity.Property(e => e.negativePostingsPermitted)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.noExchRateDiffWhenClearingInLC)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.originalKey)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.outputTaxCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.poSchedulingAgmt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.postTranslation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.postingDateForParking)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.projectCashMgmtActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.proposeFiscalYear)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pstngPeriodVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.purchaseAccountProcessing)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.purchaseRequisition)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.remittanceChallanDocumentType)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.sampleAcctRulesVar)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.shoppingCart)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.surchargeMethod)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxBaseIsNetValue)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxCrcyTranslation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxDetermwithDocDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxReportingDateActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxesOnSlsPurc)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.template)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.transitPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.updateFM)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateMMInCMF)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateSDInCMF)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.vatRegistrationNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.workflowVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_CFG_PLANT>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PLANTS");
            entity.Property(e => e.activateVariantGrouping)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.actualActivitiesUpdated)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.actualCosting)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.address)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.afSrceDetViaATP)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.archivingMarker)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.assignBatchesInARun)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchManagementNotActiveByDefault)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchRecDMSType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchStatusMgmt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchStatusMgmtOld)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.businessPlace)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.cityCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.company)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.condsAtPlantLevel)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.controlDataForBOM)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.controlOfCreditOfCostCenters)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.costObjControlling)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.countryRegionKey)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.countyCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.credIPI)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.customerNumberOfPlant)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.distribProfileOfPlant)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.distribchannel)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.exchangeValuation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.factoryCalendar)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.firstReminderExped).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.intCOBillingDiv)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.languageKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.mixedCosting)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.name1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.name2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.namingStructure)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.nodeTypesupplyChain)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.ownership)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.planningPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plantCat)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.poBox)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.poTolerance).HasColumnType("NUMBER(15,3)");
            entity.Property(e => e.postalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.purchOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.region)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.regularSupplier)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.reqmtsPlanning)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.salesAreaDetrm)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.salesDistrict)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.salesOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.seasonActiveInInventoryManagement)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.secondReminderExped).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.shippingPointReceivingPt)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.sopPlant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.sourceList)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.storeCat)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.streetAndHouseNumber)
                .HasMaxLength(31)
                .IsUnicode(false);
            entity.Property(e => e.superiorDeptStore)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.supplierNumberOfPlant)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.supplyAssignmentARun)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.supplyRegion)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.taxIndicatorPlant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxJurisdiction)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.text1stDunning)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.text2ndDunning)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.text3rdDunning)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.thirdReminderExped).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.valuationArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.varianceKey)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.vendorType)
                .HasMaxLength(1)
                .IsUnicode(false);
        }); ; ;

        modelBuilder.Entity<V_CFG_PLANTS_HI>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PLANTS_HIS");
            entity.Property(e => e.CFG_PLANTS_HIS_DATE).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.CFG_PLANTS_HIS_DELEGATE)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CFG_PLANTS_HIS_ID)
                .HasColumnType("NUMBER");
            entity.Property(e => e.CFG_PLANTS_HIS_USERID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.activateVariantGrouping)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.actualActivitiesUpdated)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.actualCosting)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.address)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.afSrceDetViaATP)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.archivingMarker)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.assignBatchesInARun)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchManagementNotActiveByDefault)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchRecDMSType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchStatusMgmt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchStatusMgmtOld)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.businessPlace)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.cityCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.company)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.condsAtPlantLevel)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.controlDataForBOM)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.controlOfCreditOfCostCenters)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.costObjControlling)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.countryRegionKey)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.countyCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.credIPI)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.customerNumberOfPlant)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.distribProfileOfPlant)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.distribchannel)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.exchangeValuation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.factoryCalendar)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.firstReminderExped).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.intCOBillingDiv)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.languageKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.mixedCosting)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.name1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.name2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.namingStructure)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.nodeTypesupplyChain)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.ownership)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.planningPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plantCat)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.poBox)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.poTolerance).HasColumnType("NUMBER(15,3)");
            entity.Property(e => e.postalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.purchOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.region)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.regularSupplier)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.reqmtsPlanning)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.salesAreaDetrm)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.salesDistrict)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.salesOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.seasonActiveInInventoryManagement)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.secondReminderExped).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.shippingPointReceivingPt)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.sopPlant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.sourceList)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.storeCat)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.streetAndHouseNumber)
                .HasMaxLength(31)
                .IsUnicode(false);
            entity.Property(e => e.superiorDeptStore)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.supplierNumberOfPlant)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.supplyAssignmentARun)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.supplyRegion)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.taxIndicatorPlant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxJurisdiction)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.text1stDunning)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.text2ndDunning)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.text3rdDunning)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.thirdReminderExped).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.valuationArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.varianceKey)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.vendorType)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_CFG_PRODUCTION_GROUP_STAGE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PRODUCTION_GROUP_STAGE");
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.groupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.groupStageExplanation)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.groupStageName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.groupStageRecordID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.groupStageSequence).HasColumnType("NUMBER(15,10)");
            entity.Property(e => e.groupStageType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.inputUoM)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.outputUoM)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        }); ; ;

        modelBuilder.Entity<V_CFG_PRODUCTION_GROUP_STAGE_CONVERSION>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PRODUCTION_GROUP_STAGE_CONVERSION");
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.groupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.groupStageVSLegacyGroupStageRecordID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.legacyGroupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.legacyType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        }); ; ;

        modelBuilder.Entity<V_CFG_PRODUCTION_GROUP_STAGE_CONVERSION_HI>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PRODUCTION_GROUP_STAGE_CONVERSION_HIS");
            entity.Property(e => e.CFG_PRODUCTION_GROUP_STAGE_CONVERSION_HIS_DATE).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.CFG_PRODUCTION_GROUP_STAGE_CONVERSION_HIS_DELEGATE)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CFG_PRODUCTION_GROUP_STAGE_CONVERSION_HIS_ID)
                .HasColumnType("NUMBER");
            entity.Property(e => e.CFG_PRODUCTION_GROUP_STAGE_CONVERSION_HIS_USERID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.groupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.groupStageVSLegacyGroupStageRecordID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.legacyGroupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.legacyType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_CFG_PRODUCTION_GROUP_STAGE_HI>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PRODUCTION_GROUP_STAGE_HIS");
            entity.Property(e => e.CFG_PRODUCTION_GROUP_STAGE_HIS_DATE).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.CFG_PRODUCTION_GROUP_STAGE_HIS_DELEGATE)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CFG_PRODUCTION_GROUP_STAGE_HIS_ID)
                .HasColumnType("NUMBER");
            entity.Property(e => e.CFG_PRODUCTION_GROUP_STAGE_HIS_USERID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.groupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.groupStageExplanation)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.groupStageName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.groupStageRecordID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.groupStageSequence).HasColumnType("NUMBER(15,10)");
            entity.Property(e => e.groupStageType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.inputUoM)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.outputUoM)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_CFG_PRODUCTION_PLANT_CONVERSION>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PRODUCTION_PLANT_CONVERSION");
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.company)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.groupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.hmeType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.legacyLine)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.legacyType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.massProductionFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plantAndSlocVsLegacyLineRecordID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        }); ; ;

        modelBuilder.Entity<V_CFG_PRODUCTION_PLANT_CONVERSION_HI>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PRODUCTION_PLANT_CONVERSION_HIS");
            entity.Property(e => e.CFG_PRODUCTION_PLANT_CONVERSION_HIS_DATE).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.CFG_PRODUCTION_PLANT_CONVERSION_HIS_DELEGATE)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CFG_PRODUCTION_PLANT_CONVERSION_HIS_ID)
                .HasColumnType("NUMBER");
            entity.Property(e => e.CFG_PRODUCTION_PLANT_CONVERSION_HIS_USERID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.company)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.groupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.hmeType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.legacyLine)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.legacyType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.massProductionFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plantAndSlocVsLegacyLineRecordID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_CFG_STORAGE_LOCATION>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_STORAGE_LOCATION");
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.authorizationCheck)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.businessSystemOfMES)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.countryCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.customer)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.descrOfStorageLoc)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.distributionChannel)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.division)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.freezeBookInvSLoc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.glmPlantCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.huReqmnt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.inTransitAssignment)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.inventoryManagementType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.licenseNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.negStocksInSLoc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partnerStorLoc)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.region)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.sLocMRPIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.salesOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.shippingPointReceivingPt)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageLocationType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.storageResource)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.supplier)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.tankAssgn)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.timeZone)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.validity)
                .HasMaxLength(1)
                .IsUnicode(false);
        }); ; ;

        modelBuilder.Entity<V_CFG_STORAGE_LOCATION_HI>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_STORAGE_LOCATION_HIS");
            entity.Property(e => e.CFG_STORAGE_LOCATION_HIS_DATE).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.CFG_STORAGE_LOCATION_HIS_DELEGATE)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CFG_STORAGE_LOCATION_HIS_ID)
                .HasColumnType("NUMBER");
            entity.Property(e => e.CFG_STORAGE_LOCATION_HIS_USERID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.authorizationCheck)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.businessSystemOfMES)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.countryCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customer)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.descrOfStorageLoc)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.distributionChannel)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.division)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.freezeBookInvSLoc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.glmPlantCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.huReqmnt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.inTransitAssignment)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.inventoryManagementType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.licenseNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.negStocksInSLoc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partnerStorLoc)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.region)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.sLocMRPIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.salesOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.shippingPointReceivingPt)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageLocationType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.storageResource)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.supplier)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.tankAssgn)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.timeZone)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.validity)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CFG_PRODUCT_ECCN_CONVERSION>(entity =>
        {
            entity.HasKey(e => new { e.countryCode, e.legalRegulation, e.partNumberKey, e.foreignTradeOrganization }).HasName("CFG_PRODUCT_ECCN_CONVERSION_PK");
            entity.ToTable("CFG_PRODUCT_ECCN_CONVERSION");
            entity.Property(e => e.countryCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.legalRegulation)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.foreignTradeOrganization)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ccat)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.controlGroup)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.eccn)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.indiMaintenance)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.noControl)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        });

        modelBuilder.Entity<CFG_PRODUCT_HISTORICAL>(entity =>
        {
            entity.HasKey(e => e.partNumberKey).HasName("CFG_PRODUCT_HISTORICAL_PK");
            entity.ToTable("CFG_PRODUCT_HISTORICAL");
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.activeDate)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.applicationCode3Default)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.assemblyOutPackagingQty)
                .HasPrecision(15);
            entity.Property(e => e.assemblyOutPackagingType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoShipping)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.basePartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.baseUnitOfMeasure)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.bomItemText)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.bumpType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.businessDivision)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.businessPlannerCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.businessUnit)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canFlagMasterComments)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canKit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRotate)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.carrierTapePocketPitch)
                .HasPrecision(15);
            entity.Property(e => e.carrierTapeWidth)
                .HasPrecision(15);
            entity.Property(e => e.chipVersion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.classCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.classCodeDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.companyOfOrigin)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deactivateDateP7)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.defaultSalesOrderCreationPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.diePositionForMultiDie)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.eccn)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.eccn_my)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.expiryDatePrintingFlag)
                .HasPrecision(1);
            entity.Property(e => e.extendedSupportDate)
                .HasColumnType("DATE");
            entity.Property(e => e.fiestaRules)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.finalTerminalFinish)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.finalTerminalFinishDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.finalTestTestProgramRevision)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.foundryPartNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.frequencyOrderIncrement)
                .HasPrecision(15);
            entity.Property(e => e.goldenAll)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.goldenRecord)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.gradeCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.gradeCodeDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.grossDiePerWafer)
                .HasPrecision(15);
            entity.Property(e => e.grossWeight)
                .HasColumnType("NUMBER(15,5)");
            entity.Property(e => e.groupStage)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.groupStageName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.halogenFreePrintingFlag)
                .HasPrecision(1);
            entity.Property(e => e.htsus)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.htsus_my)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.isPartASIC)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartAutomotive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartDolbyCapable)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartITAR)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartMultipleComponent)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartNonCancelableNonReschedule)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartNotRecommendNewDesign)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartPublish)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartRegisterable)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartSoleSource)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isSalesRoot)
                .HasColumnType("NUMBER");
            entity.Property(e => e.jedecReferenceID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.legacyMPN)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.legacyOrganization)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.lotSequenceCode)
                .HasPrecision(15);
            entity.Property(e => e.manufacturerPart)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.manufacturerPartDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketFamily)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketFamilyDetail)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketGroup)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketSegment)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.marketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.materialGroup)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.materialType)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.materialTypeDetail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.matrixWafer)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.minimumOrderQuantity)
                .HasPrecision(15);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.moistureExposureTime)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.moistureSensitiveLevel)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.mrpType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.netDieBypass)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.netWeight)
                .HasColumnType("NUMBER(15,5)");
            entity.Property(e => e.numberOfDie)
                .HasPrecision(15);
            entity.Property(e => e.obsoleteDateP6)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.orderUntilDate)
                .HasColumnType("DATE");
            entity.Property(e => e.originalPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.originalSourceSystem)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.packageBodySize)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageBodyThickness)
                .HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packageCategory)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageCodeDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packageGroup)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.packageLayer)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageLength)
                .HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packagePinCount)
                .HasPrecision(15);
            entity.Property(e => e.packagePitch)
                .HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packageType)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.packageWidth)
                .HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packagingBox)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.packagingCarrier)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packagingCarrierQuantity)
                .HasPrecision(15);
            entity.Property(e => e.packagingPackage)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packagingSpec)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.partAxis)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.partDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.pbFreeIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowPeakTemperature)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowRebakeCondition)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowStorageCondition)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pdnIssueDate)
                .HasColumnType("DATE");
            entity.Property(e => e.pdnLastBuyDate)
                .HasColumnType("DATE");
            entity.Property(e => e.pdnLastShipDate)
                .HasColumnType("DATE");
            entity.Property(e => e.plasticReelSize)
                .HasPrecision(15);
            entity.Property(e => e.plmStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.priority1OPN)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processSpecialTechnology)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.processTechnology)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.productDiscontinueNotification)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.productGeneralType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy5)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productLine)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productionDateP4)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.profitCenter)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.publishedLeadTimeInWeeks)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reachPrintingFlag)
                .HasPrecision(1);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reelHubSize)
                .HasPrecision(15);
            entity.Property(e => e.referencePackageType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.retisSeqNo)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.reviewBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.roHSChinaExemptPrintingFlag)
                .HasPrecision(1);
            entity.Property(e => e.roHSCompliant)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.roHSCompliantChina)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.roHSExemptPrintingFlag)
                .HasPrecision(1);
            entity.Property(e => e.roughWaferProcess)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.salesRootPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.salesRootPartNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprQtyThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprTotalValThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sealDateFlag)
                .HasPrecision(1);
            entity.Property(e => e.singulationProcess)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.specNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.specNoGreenOrYellow)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.standardPackingQuantity)
                .HasPrecision(15);
            entity.Property(e => e.tacticalMarketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.thickness)
                .HasPrecision(15);
            entity.Property(e => e.totalNumberOfAllWires)
                .HasPrecision(15);
            entity.Property(e => e.totalShelfLife)
                .HasPrecision(15);
            entity.Property(e => e.tsFlag)
                .HasPrecision(1);
            entity.Property(e => e.ulRatingsText)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ulRegistrationFlag)
                .HasPrecision(1);
            entity.Property(e => e.unitLoadingOrientationQuadrant)
                .HasPrecision(15);
            entity.Property(e => e.updateDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.waferOrInStockClass)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.waferSize)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.waferTechnology)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.whitePartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.wireDiameter)
                .HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.wireType)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CFG_PRODUCT_HS_CONVERSION>(entity =>
        {
            entity.HasKey(e => new { e.hsType, e.countryCode, e.partNumberKey }).HasName("CFG_PRODUCT_HS_CONVERSION_PK");
            entity.ToTable("CFG_PRODUCT_HS_CONVERSION");
            entity.Property(e => e.hsType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.countryCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.hsCode)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.hsDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.hsDescriptionDE)
                .HasMaxLength(240)
                .IsUnicode(false);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.validFrom)
                .HasColumnType("DATE");
            entity.Property(e => e.validTo)
                .HasColumnType("DATE");
        });

        modelBuilder.Entity<CFG_PRODUCT_LINE>(entity =>
        {
            entity.HasKey(e => new { e.productHierarchy1, e.productHierarchy2, e.productHierarchy3 }).HasName("CFG_PRODUCT_LINE_PK");
            entity.ToTable("CFG_PRODUCT_LINE");
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.productLine)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        });

        modelBuilder.Entity<CFG_PRODUCT_SALES_ROOT_PARTNUMBER>(entity =>
        {
            entity.HasKey(e => e.partNumberKey).HasName("CFG_PRODUCT_SALES_ROOT_PARTNUMBER_PK");
            entity.ToTable("CFG_PRODUCT_SALES_ROOT_PARTNUMBER");
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.applicationCode3Default)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canFlagMasterComments)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canKit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRotate)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.companyOfOrigin)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.frequencyOrderIncrement)
                .HasPrecision(15);
            entity.Property(e => e.goldenRecord)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartNonCancelableNonReschedule)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartNotRecommendNewDesign)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartPublish)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartRegisterable)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartSoleSource)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isSalesRoot)
                .HasPrecision(1);
            entity.Property(e => e.marketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.materialType)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.minimumOrderQuantity)
                .HasPrecision(15);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.publishedLeadTimeInWeeks)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprQtyThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprTotalValThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.tacticalMarketingMgr)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        });

        modelBuilder.Entity<CFG_PRODUCT_TYPE>(entity =>
        {
            entity.HasKey(e => new { e.productHierarchy1, e.productHierarchy2, e.productHierarchy3 }).HasName("CFG_PRODUCT_TYPE_PK");
            entity.ToTable("CFG_PRODUCT_TYPE");
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.productType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        });

        modelBuilder.Entity<RAW_CFG_PRODUCT_ECCN_CONVERSION>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RAW_CFG_PRODUCT_ECCN_CONVERSION");
            entity.Property(e => e.ccat)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.controlGroup)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.countryCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createdDate)
                .HasDefaultValueSql("SYSTIMESTAMP")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.eccn)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.errorMessage).IsUnicode(false);
            entity.Property(e => e.foreignTradeOrganization)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.haveDifference).HasPrecision(1);
            entity.Property(e => e.haveError).HasPrecision(1);
            entity.Property(e => e.indiMaintenance)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.insertOrUpdate)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.legalRegulation)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.noControl)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
        });

        modelBuilder.Entity<RAW_CFG_PRODUCT_HISTORICAL>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RAW_CFG_PRODUCT_HISTORICAL");
            entity.Property(e => e.activeDate).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.applicationCode3Default)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.assemblyOutPackagingQty).HasPrecision(15);
            entity.Property(e => e.assemblyOutPackagingType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoShipping)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.basePartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.baseUnitOfMeasure)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.bomItemText)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.bumpType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.businessDivision)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.businessPlannerCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.businessUnit)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canFlagMasterComments)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canKit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRotate)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.carrierTapePocketPitch).HasPrecision(15);
            entity.Property(e => e.carrierTapeWidth).HasPrecision(15);
            entity.Property(e => e.chipVersion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.classCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.classCodeDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.companyOfOrigin)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createdDate)
                .HasDefaultValueSql("SYSTIMESTAMP")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.customerPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deactivateDateP7).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.defaultSalesOrderCreationPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.diePositionForMultiDie)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.eccn)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.eccn_my)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.errorMessage).IsUnicode(false);
            entity.Property(e => e.expiryDatePrintingFlag).HasPrecision(1);
            entity.Property(e => e.extendedSupportDate).HasColumnType("DATE");
            entity.Property(e => e.fiestaRules)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.finalTerminalFinish)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.finalTerminalFinishDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.finalTestTestProgramRevision)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.foundryPartNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.frequencyOrderIncrement).HasPrecision(15);
            entity.Property(e => e.goldenAll)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.goldenRecord)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.gradeCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.gradeCodeDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.grossDiePerWafer).HasPrecision(15);
            entity.Property(e => e.grossWeight).HasColumnType("NUMBER(15,5)");
            entity.Property(e => e.groupStage)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.groupStageName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.halogenFreePrintingFlag).HasPrecision(1);
            entity.Property(e => e.haveDifference).HasPrecision(1);
            entity.Property(e => e.haveError).HasPrecision(1);
            entity.Property(e => e.htsus)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.htsus_my)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.insertOrUpdate)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.isPartASIC)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartAutomotive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartDolbyCapable)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartITAR)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartMultipleComponent)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartNonCancelableNonReschedule)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartNotRecommendNewDesign)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartPublish)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartRegisterable)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartSoleSource)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isSalesRoot).HasColumnType("NUMBER");
            entity.Property(e => e.jedecReferenceID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.legacyMPN)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.legacyOrganization)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.lotSequenceCode).HasPrecision(15);
            entity.Property(e => e.manufacturerPart)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.manufacturerPartDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketFamily)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketFamilyDetail)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketGroup)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketSegment)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.marketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.materialGroup)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.materialType)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.materialTypeDetail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.matrixWafer)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.minimumOrderQuantity).HasPrecision(15);
            entity.Property(e => e.moistureExposureTime)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.moistureSensitiveLevel)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.mrpType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.netDieBypass)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.netWeight).HasColumnType("NUMBER(15,5)");
            entity.Property(e => e.numberOfDie).HasPrecision(15);
            entity.Property(e => e.obsoleteDateP6).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.orderUntilDate).HasColumnType("DATE");
            entity.Property(e => e.originalPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.originalSourceSystem)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.packageBodySize)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageBodyThickness).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packageCategory)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageCodeDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packageGroup)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.packageLayer)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageLength).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packagePinCount).HasPrecision(15);
            entity.Property(e => e.packagePitch).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packageType)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.packageWidth).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packagingBox)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.packagingCarrier)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packagingCarrierQuantity).HasPrecision(15);
            entity.Property(e => e.packagingPackage)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packagingSpec)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.partAxis)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.partDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.pbFreeIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowPeakTemperature)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowRebakeCondition)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowStorageCondition)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pdnIssueDate).HasColumnType("DATE");
            entity.Property(e => e.pdnLastBuyDate).HasColumnType("DATE");
            entity.Property(e => e.pdnLastShipDate).HasColumnType("DATE");
            entity.Property(e => e.plasticReelSize).HasPrecision(15);
            entity.Property(e => e.plmStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.priority1OPN)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processSpecialTechnology)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processTechnology)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.productDiscontinueNotification)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.productGeneralType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy5)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productLine)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productionDateP4).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.profitCenter)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.publishedLeadTimeInWeeks)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reachPrintingFlag).HasPrecision(1);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reelHubSize).HasPrecision(15);
            entity.Property(e => e.referencePackageType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.retisSeqNo)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.roHSChinaExemptPrintingFlag).HasPrecision(1);
            entity.Property(e => e.roHSCompliant)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.roHSCompliantChina)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.roHSExemptPrintingFlag).HasPrecision(1);
            entity.Property(e => e.roughWaferProcess)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.salesRootPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.salesRootPartNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprQtyThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprTotalValThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sealDateFlag).HasPrecision(1);
            entity.Property(e => e.singulationProcess)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.specNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.specNoGreenOrYellow)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.standardPackingQuantity).HasPrecision(15);
            entity.Property(e => e.tacticalMarketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.thickness).HasPrecision(15);
            entity.Property(e => e.totalNumberOfAllWires).HasPrecision(15);
            entity.Property(e => e.totalShelfLife).HasPrecision(15);
            entity.Property(e => e.tsFlag).HasPrecision(1);
            entity.Property(e => e.ulRatingsText)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ulRegistrationFlag).HasPrecision(1);
            entity.Property(e => e.unitLoadingOrientationQuadrant).HasPrecision(15);
            entity.Property(e => e.waferOrInStockClass)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.waferSize)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.waferTechnology)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.whitePartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.wireDiameter).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.wireType)
                .HasMaxLength(20)
                .IsUnicode(false);
        }); ;

        modelBuilder.Entity<RAW_CFG_PRODUCT_HS_CONVERSION>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RAW_CFG_PRODUCT_HS_CONVERSION");
            entity.Property(e => e.countryCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createdDate)
                .HasDefaultValueSql("SYSTIMESTAMP")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.errorMessage).IsUnicode(false);
            entity.Property(e => e.haveDifference).HasPrecision(1);
            entity.Property(e => e.haveError).HasPrecision(1);
            entity.Property(e => e.hsCode)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.hsDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.hsDescriptionDE)
                .HasMaxLength(240)
                .IsUnicode(false);
            entity.Property(e => e.hsType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.insertOrUpdate)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.validFrom).HasColumnType("DATE");
            entity.Property(e => e.validTo).HasColumnType("DATE");
        });

        modelBuilder.Entity<RAW_CFG_PRODUCT_LINE>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RAW_CFG_PRODUCT_LINE");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createdDate)
                .HasDefaultValueSql("SYSTIMESTAMP")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.errorMessage).IsUnicode(false);
            entity.Property(e => e.haveDifference).HasPrecision(1);
            entity.Property(e => e.haveError).HasPrecision(1);
            entity.Property(e => e.insertOrUpdate)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productLine)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
        });

        modelBuilder.Entity<RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RAW_CFG_PRODUCT_SALES_ROOT_PARTNUMBER");
            entity.Property(e => e.applicationCode3Default)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canFlagMasterComments)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canKit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRotate)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.companyOfOrigin)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createdDate)
                .HasDefaultValueSql("SYSTIMESTAMP")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.errorMessage).IsUnicode(false);
            entity.Property(e => e.frequencyOrderIncrement).HasPrecision(15);
            entity.Property(e => e.goldenRecord)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.haveDifference).HasPrecision(1);
            entity.Property(e => e.haveError).HasPrecision(1);
            entity.Property(e => e.insertOrUpdate)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.isPartNonCancelableNonReschedule)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartNotRecommendNewDesign)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartPublish)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartRegisterable)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartSoleSource)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isSalesRoot).HasPrecision(1);
            entity.Property(e => e.marketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.materialType)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.minimumOrderQuantity).HasPrecision(15);
            entity.Property(e => e.partDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.publishedLeadTimeInWeeks)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.sampleAutoApprQtyThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprTotalValThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.tacticalMarketingMgr)
                .HasMaxLength(100)
                .IsUnicode(false);
        }); ; ;

        modelBuilder.Entity<RAW_CFG_PRODUCT_TYPE>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RAW_CFG_PRODUCT_TYPE");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createdDate)
                .HasDefaultValueSql("SYSTIMESTAMP")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.errorMessage).IsUnicode(false);
            entity.Property(e => e.haveDifference).HasPrecision(1);
            entity.Property(e => e.haveError).HasPrecision(1);
            entity.Property(e => e.insertOrUpdate)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
        });

        modelBuilder.Entity<V_CFG_PRODUCT_ECCN_CONVERSION>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PRODUCT_ECCN_CONVERSION");
            entity.Property(e => e.ccat)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.controlGroup)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.countryCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.eccn)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.foreignTradeOrganization)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.indiMaintenance)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.legalRegulation)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.noControl)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        }); ; ;

        modelBuilder.Entity<V_CFG_PRODUCT_ECCN_CONVERSION_HI>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PRODUCT_ECCN_CONVERSION_HIS");
            entity.Property(e => e.CFG_PRODUCT_ECCN_CONVERSION_HIS_DATE).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.CFG_PRODUCT_ECCN_CONVERSION_HIS_DELEGATE)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CFG_PRODUCT_ECCN_CONVERSION_HIS_ID)
                .HasColumnType("NUMBER");
            entity.Property(e => e.CFG_PRODUCT_ECCN_CONVERSION_HIS_USERID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ccat)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.controlGroup)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.countryCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.eccn)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.foreignTradeOrganization)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.indiMaintenance)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.legalRegulation)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.noControl)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_CFG_PRODUCT_HISTORICAL>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PRODUCT_HISTORICAL");
            entity.Property(e => e.activeDate).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.applicationCode3Default)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.assemblyOutPackagingQty).HasPrecision(15);
            entity.Property(e => e.assemblyOutPackagingType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoShipping)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.basePartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.baseUnitOfMeasure)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.bomItemText)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.bumpType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.businessDivision)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.businessPlannerCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.businessUnit)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canFlagMasterComments)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canKit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRotate)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.carrierTapePocketPitch).HasPrecision(15);
            entity.Property(e => e.carrierTapeWidth).HasPrecision(15);
            entity.Property(e => e.chipVersion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.classCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.classCodeDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.companyOfOrigin)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.customerPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deactivateDateP7).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.defaultSalesOrderCreationPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.diePositionForMultiDie)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.eccn)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.eccn_my)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.expiryDatePrintingFlag).HasPrecision(1);
            entity.Property(e => e.extendedSupportDate).HasColumnType("DATE");
            entity.Property(e => e.fiestaRules)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.finalTerminalFinish)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.finalTerminalFinishDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.finalTestTestProgramRevision)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.foundryPartNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.frequencyOrderIncrement).HasPrecision(15);
            entity.Property(e => e.goldenAll)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.goldenRecord)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.gradeCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.gradeCodeDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.grossDiePerWafer).HasPrecision(15);
            entity.Property(e => e.grossWeight).HasColumnType("NUMBER(15,5)");
            entity.Property(e => e.groupStage)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.groupStageName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.halogenFreePrintingFlag).HasPrecision(1);
            entity.Property(e => e.htsus)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.htsus_my)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.isPartASIC)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartAutomotive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartDolbyCapable)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartITAR)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartMultipleComponent)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartNonCancelableNonReschedule)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartNotRecommendNewDesign)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartPublish)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartRegisterable)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartSoleSource)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isSalesRoot).HasColumnType("NUMBER");
            entity.Property(e => e.jedecReferenceID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.legacyMPN)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.legacyOrganization)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.lotSequenceCode).HasPrecision(15);
            entity.Property(e => e.manufacturerPart)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.manufacturerPartDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketFamily)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketFamilyDetail)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketGroup)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketSegment)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.marketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.materialGroup)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.materialType)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.materialTypeDetail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.matrixWafer)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.minimumOrderQuantity).HasPrecision(15);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.moistureExposureTime)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.moistureSensitiveLevel)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.mrpType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.netDieBypass)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.netWeight).HasColumnType("NUMBER(15,5)");
            entity.Property(e => e.numberOfDie).HasPrecision(15);
            entity.Property(e => e.obsoleteDateP6).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.orderUntilDate).HasColumnType("DATE");
            entity.Property(e => e.originalPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.originalSourceSystem)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.packageBodySize)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageBodyThickness).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packageCategory)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageCodeDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packageGroup)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.packageLayer)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageLength).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packagePinCount).HasPrecision(15);
            entity.Property(e => e.packagePitch).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packageType)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.packageWidth).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packagingBox)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.packagingCarrier)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packagingCarrierQuantity).HasPrecision(15);
            entity.Property(e => e.packagingPackage)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packagingSpec)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.partAxis)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.partDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.pbFreeIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowPeakTemperature)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowRebakeCondition)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowStorageCondition)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pdnIssueDate).HasColumnType("DATE");
            entity.Property(e => e.pdnLastBuyDate).HasColumnType("DATE");
            entity.Property(e => e.pdnLastShipDate).HasColumnType("DATE");
            entity.Property(e => e.plasticReelSize).HasPrecision(15);
            entity.Property(e => e.plmStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.priority1OPN)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processSpecialTechnology)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processTechnology)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.productDiscontinueNotification)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.productGeneralType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy5)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productLine)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productionDateP4).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.profitCenter)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.publishedLeadTimeInWeeks)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reachPrintingFlag).HasPrecision(1);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reelHubSize).HasPrecision(15);
            entity.Property(e => e.referencePackageType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.retisSeqNo)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.roHSChinaExemptPrintingFlag).HasPrecision(1);
            entity.Property(e => e.roHSCompliant)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.roHSCompliantChina)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.roHSExemptPrintingFlag).HasPrecision(1);
            entity.Property(e => e.roughWaferProcess)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.salesRootPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.salesRootPartNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprQtyThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprTotalValThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sealDateFlag).HasPrecision(1);
            entity.Property(e => e.singulationProcess)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.specNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.specNoGreenOrYellow)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.standardPackingQuantity).HasPrecision(15);
            entity.Property(e => e.tacticalMarketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.thickness).HasPrecision(15);
            entity.Property(e => e.totalNumberOfAllWires).HasPrecision(15);
            entity.Property(e => e.totalShelfLife).HasPrecision(15);
            entity.Property(e => e.tsFlag).HasPrecision(1);
            entity.Property(e => e.ulRatingsText)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ulRegistrationFlag).HasPrecision(1);
            entity.Property(e => e.unitLoadingOrientationQuadrant).HasPrecision(15);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.waferOrInStockClass)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.waferSize)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.waferTechnology)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.whitePartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.wireDiameter).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.wireType)
                .HasMaxLength(20)
                .IsUnicode(false);
        }); ; ;

        modelBuilder.Entity<V_CFG_PRODUCT_HISTORICAL_HI>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PRODUCT_HISTORICAL_HIS");
            entity.Property(e => e.CFG_PRODUCT_HISTORICAL_HIS_DATE).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.CFG_PRODUCT_HISTORICAL_HIS_DELEGATE)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CFG_PRODUCT_HISTORICAL_HIS_ID)
                .HasColumnType("NUMBER");
            entity.Property(e => e.CFG_PRODUCT_HISTORICAL_HIS_USERID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.activeDate).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.applicationCode3Default)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.assemblyOutPackagingQty).HasPrecision(15);
            entity.Property(e => e.assemblyOutPackagingType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoShipping)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.basePartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.baseUnitOfMeasure)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.bomItemText)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.bumpType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.businessDivision)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.businessPlannerCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.businessUnit)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canFlagMasterComments)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canKit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRotate)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.carrierTapePocketPitch).HasPrecision(15);
            entity.Property(e => e.carrierTapeWidth).HasPrecision(15);
            entity.Property(e => e.chipVersion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.classCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.classCodeDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.companyOfOrigin)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.customerPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deactivateDateP7).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.defaultSalesOrderCreationPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.diePositionForMultiDie)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.eccn)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.eccn_my)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.expiryDatePrintingFlag).HasPrecision(1);
            entity.Property(e => e.extendedSupportDate).HasColumnType("DATE");
            entity.Property(e => e.fiestaRules)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.finalTerminalFinish)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.finalTerminalFinishDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.finalTestTestProgramRevision)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.foundryPartNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.frequencyOrderIncrement).HasPrecision(15);
            entity.Property(e => e.goldenAll)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.goldenRecord)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.gradeCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.gradeCodeDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.grossDiePerWafer).HasPrecision(15);
            entity.Property(e => e.grossWeight).HasColumnType("NUMBER(15,5)");
            entity.Property(e => e.groupStage)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.groupStageName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.halogenFreePrintingFlag).HasPrecision(1);
            entity.Property(e => e.htsus)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.htsus_my)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.isPartASIC)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartAutomotive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartDolbyCapable)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartITAR)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartMultipleComponent)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartNonCancelableNonReschedule)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartNotRecommendNewDesign)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartPublish)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartRegisterable)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartSoleSource)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isSalesRoot).HasColumnType("NUMBER");
            entity.Property(e => e.jedecReferenceID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.legacyMPN)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.legacyOrganization)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.lotSequenceCode).HasPrecision(15);
            entity.Property(e => e.manufacturerPart)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.manufacturerPartDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketFamily)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketFamilyDetail)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketGroup)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketSegment)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.marketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.materialGroup)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.materialType)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.materialTypeDetail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.matrixWafer)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.minimumOrderQuantity).HasPrecision(15);
            entity.Property(e => e.moistureExposureTime)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.moistureSensitiveLevel)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.mrpType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.netDieBypass)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.netWeight).HasColumnType("NUMBER(15,5)");
            entity.Property(e => e.numberOfDie).HasPrecision(15);
            entity.Property(e => e.obsoleteDateP6).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.orderUntilDate).HasColumnType("DATE");
            entity.Property(e => e.originalPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.originalSourceSystem)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.packageBodySize)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageBodyThickness).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packageCategory)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageCodeDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packageGroup)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.packageLayer)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageLength).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packagePinCount).HasPrecision(15);
            entity.Property(e => e.packagePitch).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packageType)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.packageWidth).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packagingBox)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.packagingCarrier)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packagingCarrierQuantity).HasPrecision(15);
            entity.Property(e => e.packagingPackage)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packagingSpec)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.partAxis)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.partDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.pbFreeIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowPeakTemperature)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowRebakeCondition)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowStorageCondition)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pdnIssueDate).HasColumnType("DATE");
            entity.Property(e => e.pdnLastBuyDate).HasColumnType("DATE");
            entity.Property(e => e.pdnLastShipDate).HasColumnType("DATE");
            entity.Property(e => e.plasticReelSize).HasPrecision(15);
            entity.Property(e => e.plmStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.priority1OPN)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processSpecialTechnology)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processTechnology)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.productDiscontinueNotification)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.productGeneralType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy5)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productLine)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productionDateP4).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.profitCenter)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.publishedLeadTimeInWeeks)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reachPrintingFlag).HasPrecision(1);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.reelHubSize).HasPrecision(15);
            entity.Property(e => e.referencePackageType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.retisSeqNo)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.roHSChinaExemptPrintingFlag).HasPrecision(1);
            entity.Property(e => e.roHSCompliant)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.roHSCompliantChina)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.roHSExemptPrintingFlag).HasPrecision(1);
            entity.Property(e => e.roughWaferProcess)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.salesRootPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.salesRootPartNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprQtyThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprTotalValThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sealDateFlag).HasPrecision(1);
            entity.Property(e => e.singulationProcess)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.specNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.specNoGreenOrYellow)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.standardPackingQuantity).HasPrecision(15);
            entity.Property(e => e.tacticalMarketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.thickness).HasPrecision(15);
            entity.Property(e => e.totalNumberOfAllWires).HasPrecision(15);
            entity.Property(e => e.totalShelfLife).HasPrecision(15);
            entity.Property(e => e.tsFlag).HasPrecision(1);
            entity.Property(e => e.ulRatingsText)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ulRegistrationFlag).HasPrecision(1);
            entity.Property(e => e.unitLoadingOrientationQuadrant).HasPrecision(15);
            entity.Property(e => e.waferOrInStockClass)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.waferSize)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.waferTechnology)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.whitePartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.wireDiameter).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.wireType)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_CFG_PRODUCT_HS_CONVERSION>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PRODUCT_HS_CONVERSION");
            entity.Property(e => e.countryCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.hsCode)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.hsDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.hsDescriptionDE)
                .HasMaxLength(240)
                .IsUnicode(false);
            entity.Property(e => e.hsType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.validFrom).HasColumnType("DATE");
            entity.Property(e => e.validTo).HasColumnType("DATE");
        }); ; ;

        modelBuilder.Entity<V_CFG_PRODUCT_HS_CONVERSION_HI>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PRODUCT_HS_CONVERSION_HIS");
            entity.Property(e => e.CFG_PRODUCT_HS_CONVERSION_HIS_DATE).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.CFG_PRODUCT_HS_CONVERSION_HIS_DELEGATE)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CFG_PRODUCT_HS_CONVERSION_HIS_ID)
                .HasColumnType("NUMBER");
            entity.Property(e => e.CFG_PRODUCT_HS_CONVERSION_HIS_USERID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.countryCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.hsCode)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.hsDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.hsDescriptionDE)
                .HasMaxLength(240)
                .IsUnicode(false);
            entity.Property(e => e.hsType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.validFrom).HasColumnType("DATE");
            entity.Property(e => e.validTo).HasColumnType("DATE");
        });

        modelBuilder.Entity<V_CFG_PRODUCT_LINE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PRODUCT_LINE");
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productLine)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        }); ; ;

        modelBuilder.Entity<V_CFG_PRODUCT_LINE_HI>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PRODUCT_LINE_HIS");
            entity.Property(e => e.CFG_PRODUCT_LINE_HIS_DATE).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.CFG_PRODUCT_LINE_HIS_DELEGATE)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CFG_PRODUCT_LINE_HIS_ID)
                .HasColumnType("NUMBER");
            entity.Property(e => e.CFG_PRODUCT_LINE_HIS_USERID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productLine)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_CFG_PRODUCT_SALES_ROOT_PARTNUMBER>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PRODUCT_SALES_ROOT_PARTNUMBER");
            entity.Property(e => e.applicationCode3Default)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canFlagMasterComments)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canKit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRotate)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.companyOfOrigin)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.frequencyOrderIncrement).HasPrecision(15);
            entity.Property(e => e.goldenRecord)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartNonCancelableNonReschedule)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartNotRecommendNewDesign)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartPublish)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartRegisterable)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartSoleSource)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isSalesRoot).HasPrecision(1);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.marketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.materialType)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.minimumOrderQuantity).HasPrecision(15);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.publishedLeadTimeInWeeks)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprQtyThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprTotalValThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.tacticalMarketingMgr)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        }); ; ;

        modelBuilder.Entity<V_CFG_PRODUCT_SALES_ROOT_PARTNUMBER_HI>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PRODUCT_SALES_ROOT_PARTNUMBER_HIS");
            entity.Property(e => e.CFG_PRODUCT_SALES_ROOT_PARTNUMBER_HIS_DATE).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.CFG_PRODUCT_SALES_ROOT_PARTNUMBER_HIS_DELEGATE)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CFG_PRODUCT_SALES_ROOT_PARTNUMBER_HIS_ID)
                .HasColumnType("NUMBER");
            entity.Property(e => e.CFG_PRODUCT_SALES_ROOT_PARTNUMBER_HIS_USERID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.applicationCode3Default)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canFlagMasterComments)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canKit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRotate)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.companyOfOrigin)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.frequencyOrderIncrement).HasPrecision(15);
            entity.Property(e => e.goldenRecord)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartNonCancelableNonReschedule)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartNotRecommendNewDesign)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartPublish)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartRegisterable)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartSoleSource)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isSalesRoot).HasPrecision(1);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.marketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.materialType)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.minimumOrderQuantity).HasPrecision(15);
            entity.Property(e => e.partDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.publishedLeadTimeInWeeks)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprQtyThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprTotalValThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.tacticalMarketingMgr)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_CFG_PRODUCT_TYPE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PRODUCT_TYPE");
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        }); ; ;

        modelBuilder.Entity<V_CFG_PRODUCT_TYPE_HI>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PRODUCT_TYPE_HIS");
            entity.Property(e => e.CFG_PRODUCT_TYPE_HIS_DATE).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.CFG_PRODUCT_TYPE_HIS_DELEGATE)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CFG_PRODUCT_TYPE_HIS_ID)
                .HasColumnType("NUMBER");
            entity.Property(e => e.CFG_PRODUCT_TYPE_HIS_USERID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_OUT_APP_APPLICATION1>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_APP_APPLICATION1");
            entity.Property(e => e.applicationLevel1Code)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel1Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        }); ;

        modelBuilder.Entity<V_OUT_APP_APPLICATION2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_APP_APPLICATION2");
            entity.Property(e => e.applicationLevel1Code)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel2Code)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel2Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        }); ;

        modelBuilder.Entity<V_OUT_APP_APPLICATION3>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_APP_APPLICATION3");
            entity.Property(e => e.applicationLevel2Code)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel3Code)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel3Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        }); ;

        modelBuilder.Entity<V_OUT_PRODUCT_ECCN_CONVERSION>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_PRODUCT_ECCN_CONVERSION");
            entity.Property(e => e.ccat)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.controlGroup)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.countryCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.eccn)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.foreignTradeOrganization)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.indiMaintenance)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.legalRegulation)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.noControl)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        });

        modelBuilder.Entity<V_OUT_PRODUCT_HISTORICAL>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_PRODUCT_HISTORICAL");
            entity.Property(e => e.activeDate).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.assemblyOutPackagingType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.basePartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.baseUnitOfMeasure)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.businessDivision)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.businessUnit)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.chipVersion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.classCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.companyOfOrigin)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.customerPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deactivateDateP7).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.defaultSalesOrderCreationPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.eccn)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.expiryDatePrintingFlag).HasPrecision(1);
            entity.Property(e => e.extendedSupportDate).HasColumnType("DATE");
            entity.Property(e => e.frequencyOrderIncrement).HasPrecision(15);
            entity.Property(e => e.goldenRecord)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.gradeCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.grossWeight).HasColumnType("NUMBER(15,5)");
            entity.Property(e => e.halogenFreePrintingFlag).HasPrecision(1);
            entity.Property(e => e.htsus)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.isPartASIC)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartAutomotive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartITAR)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartNonCancelableNonReschedule)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartPublish)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartRegisterable)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartSoleSource)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isSalesRoot).HasColumnType("NUMBER");
            entity.Property(e => e.legacyMPN)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketFamily)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketGroup)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketSegment)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.materialGroup)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.materialType)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.minimumOrderQuantity).HasPrecision(15);
            entity.Property(e => e.moistureSensitiveLevel)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.netWeight).HasColumnType("NUMBER(15,5)");
            entity.Property(e => e.obsoleteDateP6).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.orderUntilDate).HasColumnType("DATE");
            entity.Property(e => e.packageBodySize)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageBodyThickness).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packageCategory)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageGroup)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.packageLength).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packagePinCount).HasPrecision(15);
            entity.Property(e => e.packagePitch).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packageType)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.packageWidth).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.partAxis)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.partDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.pdnIssueDate).HasColumnType("DATE");
            entity.Property(e => e.pdnLastBuyDate).HasColumnType("DATE");
            entity.Property(e => e.pdnLastShipDate).HasColumnType("DATE");
            entity.Property(e => e.plmStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.priority1OPN)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processTechnology)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.productGeneralType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.profitCenter)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.publishedLeadTimeInWeeks)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reachPrintingFlag).HasPrecision(1);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.roHSCompliant)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.roHSCompliantChina)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.salesRootPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.salesRootPartNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sealDateFlag).HasPrecision(1);
            entity.Property(e => e.singulationProcess)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.standardPackingQuantity).HasPrecision(15);
            entity.Property(e => e.thickness).HasPrecision(15);
            entity.Property(e => e.tsFlag).HasPrecision(1);
            entity.Property(e => e.ulRegistrationFlag).HasPrecision(1);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.waferSize)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.waferTechnology)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.whitePartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_OUT_PRODUCT_HS_CONVERSION>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_PRODUCT_HS_CONVERSION");
            entity.Property(e => e.countryCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.hsCode)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.hsDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.hsDescriptionDE)
                .HasMaxLength(240)
                .IsUnicode(false);
            entity.Property(e => e.hsType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.validFrom).HasColumnType("DATE");
            entity.Property(e => e.validTo).HasColumnType("DATE");
        });

        modelBuilder.Entity<V_OUT_PRODUCT_LINE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_PRODUCT_LINE");
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productLine)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        });

        modelBuilder.Entity<V_OUT_PRODUCT_SALES_ROOT_PARTNUMBER>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_PRODUCT_SALES_ROOT_PARTNUMBER");
            entity.Property(e => e.applicationCode3Default)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canFlagMasterComments)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canKit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRotate)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.companyOfOrigin)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.frequencyOrderIncrement).HasPrecision(15);
            entity.Property(e => e.goldenRecord)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartNonCancelableNonReschedule)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartNotRecommendNewDesign)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartPublish)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartRegisterable)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartSoleSource)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isSalesRoot).HasPrecision(1);
            entity.Property(e => e.marketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.materialType)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.minimumOrderQuantity).HasPrecision(15);
            entity.Property(e => e.partDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.publishedLeadTimeInWeeks)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.sampleAutoApprQtyThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprTotalValThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.tacticalMarketingMgr)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        });

        modelBuilder.Entity<V_OUT_PRODUCT_TYPE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_PRODUCT_TYPE");
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        });

        modelBuilder.Entity<V_MDM_COMPANY_CODE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_MDM_COMPANY_CODE");
            entity.Property(e => e.acctsRecblePledActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activateAADerivation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.address)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.alternativeCOA)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.baVariant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.businessAreaFinStatements)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.cashManagementActivated)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.cashManagementCompanyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.chartOfAccounts)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.coArea)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.company)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyCodeIsProductive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.companyName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.contract)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.controlAreaCanBeInput)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.copyingControlGoodsReceipt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.costOfSalesAccountingActv)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.countryRegionKey)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.creditControlArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.cshBdgtMgtActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.currency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.deferredTaxRule)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.defineDefaultValueDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.discountBaseIsNetValue)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.documentEntryScreenVariant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.documentTypeForJVAmountCorrection)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.documentTypeForJVTaxCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.documentTypeForProvisionsForTaxes)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.enableAmountSplit)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.extendedWithholdingTaxActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.externalCoCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.fdsCtrActiveInHR).HasColumnType("DATE");
            entity.Property(e => e.fieldStatusVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.financialAssetsMgmtActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.fiscalYearVariant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.fmArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.fundsReservationFieldStatusVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.globalCoCde)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.hedgeRequestActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.hideEntryInInputHelp)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.importDataGoodsReceipt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.importDataInPurchaseOrder)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.inflationMethod)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.inputTaxCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.inventoryManagement)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.jurisdictionCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.jvAccountingActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.languageKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.managePostingPeriodForCoCodeLedger)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.maxExchangeRateDeviation).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.methodOffsttngAcct).HasColumnType("NUMBER(15,1)");
            entity.Property(e => e.negativePostingsPermitted)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.noExchRateDiffWhenClearingInLC)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.originalKey)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.outputTaxCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.poSchedulingAgmt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.postTranslation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.postingDateForParking)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.projectCashMgmtActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.proposeFiscalYear)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pstngPeriodVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.purchaseAccountProcessing)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.purchaseRequisition)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.remittanceChallanDocumentType)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.sampleAcctRulesVar)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.shoppingCart)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.surchargeMethod)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxBaseIsNetValue)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxCrcyTranslation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxDetermwithDocDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxReportingDateActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxesOnSlsPurc)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.template)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.transitPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateFM)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateMMInCMF)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateSDInCMF)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.vatRegistrationNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.workflowVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_MDM_PLANT>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_MDM_PLANTS");
            entity.Property(e => e.activateVariantGrouping)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.actualActivitiesUpdated)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.actualCosting)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.address)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.afSrceDetViaATP)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.archivingMarker)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.assignBatchesInARun)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchManagementNotActiveByDefault)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchRecDMSType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchStatusMgmt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchStatusMgmtOld)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.businessPlace)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.cityCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.company)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.condsAtPlantLevel)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.controlDataForBOM)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.controlOfCreditOfCostCenters)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.costObjControlling)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.countryRegionKey)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.countyCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.credIPI)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.customerNumberOfPlant)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.distribProfileOfPlant)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.distribchannel)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.exchangeValuation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.factoryCalendar)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.firstReminderExped).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.intCOBillingDiv)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.languageKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.mixedCosting)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.name1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.name2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.namingStructure)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.nodeTypesupplyChain)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.ownership)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.planningPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plantCat)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.poBox)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.poTolerance).HasColumnType("NUMBER(15,3)");
            entity.Property(e => e.postalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.purchOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.region)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.regularSupplier)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.reqmtsPlanning)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.salesAreaDetrm)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.salesDistrict)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.salesOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.seasonActiveInInventoryManagement)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.secondReminderExped).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.shippingPointReceivingPt)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.sopPlant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.sourceList)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.storeCat)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.streetAndHouseNumber)
                .HasMaxLength(31)
                .IsUnicode(false);
            entity.Property(e => e.superiorDeptStore)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.supplierNumberOfPlant)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.supplyAssignmentARun)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.supplyRegion)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.taxIndicatorPlant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxJurisdiction)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.text1stDunning)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.text2ndDunning)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.text3rdDunning)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.thirdReminderExped).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.valuationArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.varianceKey)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.vendorType)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_MDM_PRODUCTION_GROUP_STAGE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_MDM_PRODUCTION_GROUP_STAGE");
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.groupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.groupStageExplanation)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.groupStageName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.groupStageRecordID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.groupStageSequence).HasColumnType("NUMBER(15,10)");
            entity.Property(e => e.groupStageType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.inputUoM)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.outputUoM)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
        }); ;

        modelBuilder.Entity<V_MDM_PRODUCTION_GROUP_STAGE_CONVERSION>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_MDM_PRODUCTION_GROUP_STAGE_CONVERSION");
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.groupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.groupStageVSLegacyGroupStageRecordID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.legacyGroupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.legacyType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_MDM_PRODUCTION_PLANT_CONVERSION>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_MDM_PRODUCTION_PLANT_CONVERSION");
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.company)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.groupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.hmeType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.legacyLine)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.legacyType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.massProductionFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plantAndSlocVsLegacyLineRecordID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_MDM_STORAGE_LOCATION>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_MDM_STORAGE_LOCATION");
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.authorizationCheck)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.businessSystemOfMES)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.countryCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.customer)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.descrOfStorageLoc)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.distributionChannel)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.division)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.freezeBookInvSLoc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.glmPlantCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.huReqmnt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.inTransitAssignment)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.inventoryManagementType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.licenseNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.negStocksInSLoc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partnerStorLoc)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.region)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.sLocMRPIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.salesOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.shippingPointReceivingPt)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageLocationType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.storageResource)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.supplier)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.tankAssgn)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.timeZone)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.validity)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_OUT_CUS_BILL_TO>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_CUS_BILL_TO");
            entity.Property(e => e.accountAssignmentGroup)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.accountAtCustomer)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.attribute1)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute10)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute2)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute3)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute4)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute5)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute6)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute7)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute8)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute9)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.bpRole)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.buGroup)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.building)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.businessPartnerCategory)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.centralDeletionFlag)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.characteristicName1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.characteristicValue1)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.cityCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyIdTradingPartner)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.completeDeliveryDefined)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.countryCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.creditControlArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.currency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.customerClassification)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.customerCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup1)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup2)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup3)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup4)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup5)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerName1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerName2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerName3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerName4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerOrderBlock)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.customersFactoryCalendar)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.defaultUnloadingPoint)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.deliveryPriority).HasPrecision(2);
            entity.Property(e => e.distributionChannel)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.district)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.division)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.faxExtension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.faxNumber)
                .HasMaxLength(31)
                .IsUnicode(false);
            entity.Property(e => e.fiscalYearVariant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.floor)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.goodsReceivingHoursId)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.homeCity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.houseNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.identificationNumber15)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.incotermas1)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.incotermas2)
                .HasMaxLength(28)
                .IsUnicode(false);
            entity.Property(e => e.languageKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.maximumDeliveriesAllowed).HasPrecision(1);
            entity.Property(e => e.orderCombinationIndicator)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.overDeliveryTolerance)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partialDeliveryAtItemLevel)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partnerFunction)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.poBox)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.postalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.pricingProcedureAssigned)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.regionCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.roomNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.salesOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.searchName1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.shippingConditions)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.smtpAddr)
                .HasMaxLength(241)
                .IsUnicode(false);
            entity.Property(e => e.street)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.street2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.street3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.taxJurisdiction)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.taxnumKr1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumKr2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumSg1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumTw1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumTw2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeKr1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeKr2)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeSg1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeTw1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeTw2)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.telExtension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.telNumber)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.telNumber2)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.teletexNumber)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.telexNumber)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.termsOfPaymentKey)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.textId1)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId2)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId3)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId4)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId5)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.timeZone)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.title)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.transportationZone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.unloadingPoint)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.vatNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_OUT_CUS_END_CUSTOMER>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_CUS_END_CUSTOMER");
            entity.Property(e => e.accountNumCustomerOID)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.btAddress1)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.btAddress2)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.btAddress3)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.btAddress4)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.btAddress5)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.btCity)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.btCountry)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.btState)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.btZip)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.category)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.childId)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.currencyName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.customerLevel)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.customerType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.focus)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.geography)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.hiRelAllowed)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.isTyt)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.legalName)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.location)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.parentCustomerAccount)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.parentCustomerLocation)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.parentCustomerName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.sapChangePoint)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.soldToOrigin)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.status)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.webSite)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_OUT_CUS_PARTNER_FUNCTION>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_CUS_PARTNER_FUNCTION");
            entity.Property(e => e.businessPartnerNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.customerNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.defaultPartner)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.distributionChannel)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.division)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.effectiveDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.partnerCounter)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.partnerFunction)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.salesOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        });

        modelBuilder.Entity<V_OUT_CUS_SHIP_TO>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_CUS_SHIP_TO");
            entity.Property(e => e.accountAssignmentGroup)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.accountAtCustomer)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.attribute1)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute10)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute2)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute3)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute4)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute5)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute6)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute7)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute8)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute9)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.bpRole)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.buGroup)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.building)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.businessPartnerCategory)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.centralDeletionFlag)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.characteristicName1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.characteristicValue1)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.cityCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyIdTradingPartner)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.completeDeliveryDefined)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.countryCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.creditControlArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.currency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.customerClassification)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.customerCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup1)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup2)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup3)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup4)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup5)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerName1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerName2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerName3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerName4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerOrderBlock)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.customersFactoryCalendar)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.defaultUnloadingPoint)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.deliveryPriority).HasPrecision(2);
            entity.Property(e => e.distributionChannel)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.district)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.division)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.faxExtension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.faxNumber)
                .HasMaxLength(31)
                .IsUnicode(false);
            entity.Property(e => e.fiscalYearVariant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.floor)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.goodsReceivingHoursId)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.homeCity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.houseNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.identificationNumber15)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.incotermas1)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.incotermas2)
                .HasMaxLength(28)
                .IsUnicode(false);
            entity.Property(e => e.languageKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.maximumDeliveriesAllowed).HasPrecision(1);
            entity.Property(e => e.orderCombinationIndicator)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.overDeliveryTolerance)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partialDeliveryAtItemLevel)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partnerFunction)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.poBox)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.postalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.pricingProcedureAssigned)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.regionCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.roomNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.salesOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.searchName1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.shippingConditions)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.smtpAddr)
                .HasMaxLength(241)
                .IsUnicode(false);
            entity.Property(e => e.street)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.street2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.street3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.taxJurisdiction)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.taxnumKr1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumKr2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumSg1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumTw1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumTw2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeKr1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeKr2)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeSg1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeTw1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeTw2)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.telExtension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.telNumber)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.telNumber2)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.teletexNumber)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.telexNumber)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.termsOfPaymentKey)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.textId1)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId2)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId3)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId4)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId5)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.timeZone)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.title)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.transportationZone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.unloadingPoint)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.vatNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_OUT_CUS_SOLD_TO>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_CUS_SOLD_TO");
            entity.Property(e => e.accountAssignmentGroup)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.accountAtCustomer)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.attribute1)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute10)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute2)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute3)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute4)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.attribute5)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute6)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute7)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute8)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.attribute9)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.bpRole)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.buGroup)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.building)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.businessPartnerCategory)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.centralDeletionFlag)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.characteristicName1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.characteristicValue1)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.cityCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyIdTradingPartner)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.completeDeliveryDefined)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.countryCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.creditControlArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.currency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.customerClassification)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.customerCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup1)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup2)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup3)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup4)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerGroup5)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.customerName1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerName2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerName3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerName4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.customerOrderBlock)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.customersFactoryCalendar)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.defaultUnloadingPoint)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.deliveryPriority).HasPrecision(2);
            entity.Property(e => e.distributionChannel)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.district)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.division)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.faxExtension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.faxNumber)
                .HasMaxLength(31)
                .IsUnicode(false);
            entity.Property(e => e.fiscalYearVariant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.floor)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.goodsReceivingHoursId)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.homeCity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.houseNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.identificationNumber15)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.incotermas1)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.incotermas2)
                .HasMaxLength(28)
                .IsUnicode(false);
            entity.Property(e => e.languageKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.maximumDeliveriesAllowed).HasPrecision(1);
            entity.Property(e => e.orderCombinationIndicator)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.overDeliveryTolerance)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.parentCustomerAccount)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.partialDeliveryAtItemLevel)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partnerFunction)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.poBox)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.postalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.pricingProcedureAssigned)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.regionCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.roomNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.salesOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.searchName1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.shippingConditions)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.smtpAddr)
                .HasMaxLength(241)
                .IsUnicode(false);
            entity.Property(e => e.street)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.street2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.street3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.taxJurisdiction)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.taxnumKr1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumKr2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumSg1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumTw1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxnumTw2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeKr1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeKr2)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeSg1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeTw1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taxtypeTw2)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.telExtension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.telNumber)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.telNumber2)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.teletexNumber)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.telexNumber)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.termsOfPaymentKey)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.textId1)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId2)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId3)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId4)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.textId5)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.timeZone)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.title)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.transportationZone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.unloadingPoint)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.vatNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_OUT_FIN_COST_CENTER>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_FIN_COST_CENTER");
            entity.Property(e => e.businessArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.coArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.completionFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.costCenter)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.costCenterCategory)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.costCenterShortText)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.country)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createOn).HasColumnType("DATE");
            entity.Property(e => e.currency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.description)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.effectiveDate).HasColumnType("DATE");
            entity.Property(e => e.functionalArea)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.indicatorForAllowedAllocationMethods)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.indicatorForRecordingConsumptionQuantities)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lockIndicatorForActualPrimaryPostings)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lockIndicatorForActualRevenuePostings)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lockIndicatorForActualSecondaryCosts)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lockIndicatorForCommitmentUpdate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lockIndicatorForPlanPrimaryCosts)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lockIndicatorForPlanSecondaryCosts)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lockIndicatorForPlanningRevenues)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.objectNumber)
                .HasMaxLength(22)
                .IsUnicode(false);
            entity.Property(e => e.paymentCardsValidTo).HasColumnType("DATE");
            entity.Property(e => e.personResponsible)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.profitCenter)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.profitCenterArea)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.userName)
                .HasMaxLength(12)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_OUT_FIN_IP_CUSTOMER>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_FIN_IP_CUSTOMER");
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.customerCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.customerName)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ipLicenseNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.status)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.validityFromDate).HasColumnType("DATE");
            entity.Property(e => e.validityToDate).HasColumnType("DATE");
        }); ;

        modelBuilder.Entity<V_OUT_FIN_IP_OPN>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_FIN_IP_OPN");
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ipLicenseCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ipVendorName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.techName)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        });

        modelBuilder.Entity<V_OUT_PRODUCT_STANDARD_COST>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_PRODUCT_STANDARD_COST");
            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyCodeCurrency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.companyCodeCurrencyLegalValuation).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.postingDate).HasColumnType("DATE");
            entity.Property(e => e.priceUnit).HasPrecision(5);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        });

        modelBuilder.Entity<V_OUT_PRODUCT_WIP_SELL_PRICE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_PRODUCT_WIP_SELL_PRICE");
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.currency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.price).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.sellingPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.validFromDate).HasColumnType("DATE");
            entity.Property(e => e.validToDate).HasColumnType("DATE");
        });

        modelBuilder.Entity<V_OUT_VEN_VENDOR>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_VEN_VENDOR");
            entity.Property(e => e.abcIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.accountNumberAtVendor)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.acknowledgementReqd)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.autoEvalGRSetmtDel)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.autoevalgrsetmtRet)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.automaticPurchaseOrder)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.bankFeeCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.buildingCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.coName)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.companyIDTradingPartner)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.companyPostalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.confirmationControl)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.country)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.creationDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.customerNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.dataLine)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.deletionIndicatorCommon)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.differentCity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.district)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.email)
                .HasMaxLength(241)
                .IsUnicode(false);
            entity.Property(e => e.fax)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.faxExtension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.floor)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.generalTelephone)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.grBasedInvVeri)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.houseNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.houseNumberSupplement)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.inco2)
                .HasMaxLength(28)
                .IsUnicode(false);
            entity.Property(e => e.incoterms)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.languageKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.minimumOrderValue)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.modeOfTransprtBorder)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.name2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.name3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.name4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.officeOfEntry)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.orderCurrency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.otherCity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partnerFunction1)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.partnerNumber1)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.plannedDelivTime)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.poBox)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.postalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.postalCode2)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.pricingDateControl)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.purchasingGroup)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.purchasingOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.purchasingTelephone)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.region)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.relevantForPriceDetVendorHierarchy)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.returnsVendor)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.room)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.salesperson)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.schemaGroupVendor)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.searchTerm12)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.searchTerm2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.sortCriterion)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.standardCommMethod)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.street2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.street3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.street4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.street5)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.streetHouseNumber)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.subsequentSettlement)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.taxJurisdictn)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.taxNumber)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.taxNumber1)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.taxNumber2)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.taxNumber3)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.taxOffice)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.telebox)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.telephoneExtension)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.termsOfPayment)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.timeZone)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.title)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.transportationZone)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.vendorNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_OUT_VEN_VENDOR_COMPANY>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_VEN_VENDOR_COMPANY");
            entity.Property(e => e.accountMemo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.accountNumberAtVendor)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.accountWithVendor)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.accountingClerk)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.accountingClerkFax)
                .HasMaxLength(31)
                .IsUnicode(false);
            entity.Property(e => e.acctStatement)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.acctingClerkTelephone)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.alternativePayee)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.authorizationGroup)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.autoEvalGRSetmtDel)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.autoevalgrsetmtRet)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.automaticPurchaseOrder)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.bankFeeCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.checkCashingTime)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.checkDoubleInvoice)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.clearingWithCust)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.clerkAtVendor)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.clerkInternetAddress)
                .HasMaxLength(130)
                .IsUnicode(false);
            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyIDTradingPartner)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.confirmationControl)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.country)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.creationDate)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.creditMemoPytTerm)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.customerNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.dateOfLastInterestRun).HasColumnType("DATE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.deletionFlag)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.deletionIndicatorCommon)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.district)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.dunningProcedure)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.fax)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.generalTelephone)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.grBasedInvVeri)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.groupingKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.headOffice)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.houseBank)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.inco2)
                .HasMaxLength(28)
                .IsUnicode(false);
            entity.Property(e => e.incoterms)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.individualPayment)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.interestCalcFrequency)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.interestIndicator)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.keyDateOfLastIntCalc).HasColumnType("DATE");
            entity.Property(e => e.minorityIndicator)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.name2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.name3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.name4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.orderCurrency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.paymentAdviceByEdi)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.paymentBlock)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.paymentGroupKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.paymentMethSupplement)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.paymentMethods)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.personnelNumber)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.planningGroup)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.poBox)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.postalCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.postalCode2)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.postingBlock)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.previousAccountNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.purchasingOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.purchasingTelephone)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.reconciliationAcct)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.region)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.salesperson)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.schemaGroupVendor)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.searchTerm12)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.searchTerm2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.sortKey)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.street2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.street3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.street4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.street5)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.streetHouseNumber)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.termsOfPayment)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.toleranceGroup)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.vendorNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_OUT_VEN_VENDOR_PURCHASE_INFO_REC>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_VEN_VENDOR_PURCHASE_INFO_REC");
            entity.Property(e => e.actualUnitPriceInThePreviousPeriod).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.additionalPlantAndStorageLocationExtension)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.availableDeliverableFrom).HasColumnType("DATE");
            entity.Property(e => e.availableDeliverableUntil).HasColumnType("DATE");
            entity.Property(e => e.baseUnitOfMeasure)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.baseUnitOfMeasureQuantity).HasPrecision(13);
            entity.Property(e => e.category)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.conditionType1)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.conditionType1Amount).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.conditionType2)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.conditionType2Amount).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.conditionType3)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.conditionType3Amount).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.conditionType4)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.conditionType4Amount).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.conditionType5)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.conditionType5Amount).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.countryOfOrigin)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.currency)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.currencyCode)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.denominatorForConvOfOrderPriceUnitIntoOrderUnit).HasPrecision(5);
            entity.Property(e => e.denominatorForConversionOfOrderPriceUnitIntoOrderUnit).HasPrecision(5);
            entity.Property(e => e.documentNumber)
                .HasMaxLength(22)
                .IsUnicode(false);
            entity.Property(e => e.documentVersion)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.effectivePrice).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.environmentallyRelevant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.indicatorForFieldSequence)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.indicatorForGRBasedInvoiceVerification)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.lineNoOfShelfLifeExpirationDate)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.materialFreightGroup)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.materialGroup)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.materialGroupDescription)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.materialNumberUsedByVendor)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.materialPOTextDrawingNumber)
                .HasMaxLength(28)
                .IsUnicode(false);
            entity.Property(e => e.materialPOTextSecondaryNumber)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.minimumPurchaseOrderQuantity).HasPrecision(15);
            entity.Property(e => e.netPrice).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.number)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.numeratorForConvOfOrderPriceUnitIntoOrderUnit).HasPrecision(5);
            entity.Property(e => e.numeratorForConversionOfOrderPriceUnitIntoOrderUnit).HasPrecision(5);
            entity.Property(e => e.orderPriceUnitPurchasing)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.overdeliveryToleranceLimit).HasPrecision(3);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.plannedDeliveryTimeInDays).HasPrecision(3);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.priceDetermination)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.priceUnit).HasPrecision(5);
            entity.Property(e => e.priorVendor)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.purchaseOrderUnitOfMeasure)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.purchasingGroup)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.purchasingGroupCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.purchasingOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.recordRegisteredDate).HasColumnType("DATE");
            entity.Property(e => e.returnAgreement)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.shippingInstructions)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.shortText)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.standardText)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.underdeliveryToleranceLimit).HasPrecision(3);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.validFromDate).HasColumnType("DATE");
            entity.Property(e => e.validToDate).HasColumnType("DATE");
            entity.Property(e => e.validityFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.vatCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.vendorAccountNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
        });;;

        modelBuilder.Entity<V_MDM_PRODUCT_HIERARCHY>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_MDM_PRODUCT_HIERARCHY");
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.level)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.phCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.phDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.upperKey)
                .HasMaxLength(8)
                .IsUnicode(false);
        }); ; ;

        modelBuilder.Entity<V_MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_MDM_PRODUCT_HIERARCHY_PROFITCENTER_CONVERSION");
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.profitCenter)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.profitCenterCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        }); ; ; ;

        modelBuilder.Entity<V_MDM_PROFIT_CENTER>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_MDM_PROFIT_CENTER");
            entity.Property(e => e.DATBI).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.KHINR)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.KTEXT)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.PRCTR)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        }); ; ;

        modelBuilder.Entity<V_MDM_PROFIT_CENTER_HIERARCHY>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_MDM_PROFIT_CENTER_HIERARCHY");
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.description)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.lineID).HasPrecision(10);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.setName)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.subSetName)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        }); ; ;

        modelBuilder.Entity<V_OUT_NONPRODUCTION_PRODUCT>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_NONPRODUCTION_PRODUCT");
            entity.Property(e => e.MTSPNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.MTSPRevision)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.MTSPdescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.P3ExpirationDate).HasColumnType("DATE");
            entity.Property(e => e.P3QuantityLimit).HasPrecision(15);
            entity.Property(e => e.ResponsibleProductEngineer)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.activeDate).HasPrecision(6);
            entity.Property(e => e.assemblyOutPackagingQty).HasPrecision(15);
            entity.Property(e => e.assemblyOutPackagingType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoShipping)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.basePartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.baseUnitOfMeasure)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.bomItemText)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.bumpType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.businessDivision)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.businessPlannerCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.businessUnit)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.carrierTapePocketPitch).HasPrecision(15);
            entity.Property(e => e.carrierTapeWidth).HasPrecision(15);
            entity.Property(e => e.chipVersion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.classCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.classCodeDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyOfOrigin)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.customerPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deactivateDateP7).HasPrecision(6);
            entity.Property(e => e.defaultSalesOrderCreationPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.diePositionForMultiDie)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.expiryDatePrintingFlag).HasPrecision(1);
            entity.Property(e => e.extendedSupportDate).HasColumnType("DATE");
            entity.Property(e => e.finalTerminalFinish)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.finalTerminalFinishDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.finalTestTestProgramRevision)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.foundryPartNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.frequencyOrderIncrement).HasPrecision(15);
            entity.Property(e => e.gradeCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.gradeCodeDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.grossDiePerWafer).HasPrecision(15);
            entity.Property(e => e.grossWeight).HasColumnType("NUMBER(15,5)");
            entity.Property(e => e.groupStage)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.halogenFreePrintingFlag).HasPrecision(1);
            entity.Property(e => e.hasMultipleMPNcomponents)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartASIC)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartAutomotive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartDolbyCapable)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartITAR)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartMultipleComponent)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.jedecReferenceID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.legacyMPN)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.legacyOrganization)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.lotSequenceCode).HasPrecision(15);
            entity.Property(e => e.manufacturerPart)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.manufacturerPartDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketFamily)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketFamilyDetail)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketGroup)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketSegment)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.materialGroup)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.materialType)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.materialTypeDetail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.matrixWafer)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.maximumLeadtimeByOPN).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.minimumOrderQuantity).HasPrecision(15);
            entity.Property(e => e.moistureExposureTime)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.moistureSensitiveLevel)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.mrpType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.netDieBypass)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.netWeight).HasColumnType("NUMBER(15,5)");
            entity.Property(e => e.numberOfDie).HasPrecision(15);
            entity.Property(e => e.obsoleteDateP6).HasPrecision(6);
            entity.Property(e => e.orderUntilDate).HasColumnType("DATE");
            entity.Property(e => e.originalPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.originalSourceSystem)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.packageBodySize)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageBodyThickness).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packageCategory)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageCodeDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packageGroup)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.packageLayer)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageLength).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packagePinCount).HasPrecision(15);
            entity.Property(e => e.packagePitch).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packageType)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.packageWidth).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packagingBox)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.packagingCarrier)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packagingCarrierQuantity).HasPrecision(15);
            entity.Property(e => e.packagingPackage)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packagingSpec)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.partAxis)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.partDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.pbFreeIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowPeakTemperature)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowRebakeCondition)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowStorageCondition)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pdnIssueDate).HasColumnType("DATE");
            entity.Property(e => e.pdnLastBuyDate).HasColumnType("DATE");
            entity.Property(e => e.pdnLastShipDate).HasColumnType("DATE");
            entity.Property(e => e.plasticReelSize).HasPrecision(15);
            entity.Property(e => e.plmStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.priority1OPN)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processSpecialTechnology)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processTechnology)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.productDiscontinueNotification)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy5)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productionDateP4).HasPrecision(6);
            entity.Property(e => e.profitCenter)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.reachPrintingFlag).HasPrecision(1);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reelHubSize).HasPrecision(15);
            entity.Property(e => e.referencePackageType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.retisSeqNo)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.roHSChinaExemptPrintingFlag).HasPrecision(1);
            entity.Property(e => e.roHSCompliant)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.roHSCompliantChina)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.roHSExemptPrintingFlag).HasPrecision(1);
            entity.Property(e => e.roughWaferProcess)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.sealDateFlag).HasPrecision(1);
            entity.Property(e => e.sentFromSystem)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.singulationProcess)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.specNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.specNoGreenOrYellow)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.standardPackingQuantity).HasPrecision(15);
            entity.Property(e => e.thickness).HasPrecision(15);
            entity.Property(e => e.totalNumberOfAllWires).HasPrecision(15);
            entity.Property(e => e.totalShelfLife).HasPrecision(15);
            entity.Property(e => e.tsFlag).HasPrecision(1);
            entity.Property(e => e.ulRatingsText)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ulRegistrationFlag).HasPrecision(1);
            entity.Property(e => e.unitLoadingOrientationQuadrant).HasPrecision(15);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.waferOrInStockClass)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.waferSize)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.waferTechnology)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.whitePartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.wireDiameter).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.wireType)
                .HasMaxLength(20)
                .IsUnicode(false);
        });; ;

        modelBuilder.Entity<V_OUT_NONPRODUCTION_PRODUCT_PLANT>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_NONPRODUCTION_PRODUCT_PLANT");
            entity.Property(e => e.businessDivision)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.businessPlannerCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.factoryFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.goldenRecord)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.inhouseProductionTime).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.legacyLine)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.lotSizingProcedure)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.materialType)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.minimumLotSize).HasPrecision(15);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.planningYield).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.profitCenter)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.sentFromSystem)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.specialOriginalPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        }); ;

        modelBuilder.Entity<V_OUT_NONPRODUCTION_PRODUCT_SALE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_NONPRODUCTION_PRODUCT_SALES");
            entity.Property(e => e.applicationCode3Default)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.defaultSalesOrderCreationPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.distributionChannel)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.frequencyOrderIncrement).HasPrecision(15);
            entity.Property(e => e.goldenRecord)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.materialType)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.minimumOrderQuantity).HasPrecision(15);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.salesOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.sentFromSystem)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.standardPackingQuantity).HasPrecision(15);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        }); ;

        modelBuilder.Entity<V_OUT_PRODUCT_CAN_FLAGS4>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_PRODUCT_CAN_FLAGS4");
            entity.Property(e => e.applicationCode3Default)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canFlagMasterComments)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canKit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRotate)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.isPartNonCancelableNonReschedule)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartNotRecommendNewDesign)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartPublish)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartRegisterable)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartSoleSource)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.publishedLeadTimeInWeeks)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.sampleAutoApprQtyThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprTotalValThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.tacticalMarketingMgr)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        });

        modelBuilder.Entity<CFG_FIN_IP_OPN>(entity =>
        {
            entity.HasKey(e => new { e.partNumber, e.ipLicenseCode }).HasName("CFG_FIN_IP_OPN_PK");
            entity.ToTable("CFG_FIN_IP_OPN");
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.ipLicenseCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.ipVendorName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.techName)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
        });

        modelBuilder.Entity<RAW_CFG_FIN_IP_OPN>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RAW_CFG_FIN_IP_OPN");
            entity.Property(e => e.createdBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.createdDate)
                .HasDefaultValueSql("SYSTIMESTAMP")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.errorMessage).IsUnicode(false);
            entity.Property(e => e.haveDifference).HasPrecision(1);
            entity.Property(e => e.haveError).HasPrecision(1);
            entity.Property(e => e.insertOrUpdate)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.ipLicenseCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ipVendorName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.techName)
                .HasMaxLength(256)
                .IsUnicode(false);
        }); ;

        modelBuilder.Entity<V_CFG_FIN_IP_OPN>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_FIN_IP_OPN");
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ipLicenseCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ipVendorName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.techName)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
        }); ; ;

        modelBuilder.Entity<V_CFG_FIN_IP_OPN_HI>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_FIN_IP_OPN_HIS");
            entity.Property(e => e.CFG_FIN_IP_OPN_HIS_DATE).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.CFG_FIN_IP_OPN_HIS_DELEGATE)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CFG_FIN_IP_OPN_HIS_ID)
                .HasColumnType("NUMBER");
            entity.Property(e => e.CFG_FIN_IP_OPN_HIS_USERID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.ipLicenseCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ipVendorName)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.techName)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
        }); ; ;

        modelBuilder.Entity<MV_OUT_PRODUCT_PLANT_CONSOLIDATE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("MV_OUT_PRODUCT_PLANT_CONSOLIDATE");
            entity.Property(e => e.businessDivision)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.businessPlannerCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.factoryFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.goldenRecord)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.inhouseProductionTime).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.legacyLine)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.lotSizingProcedure)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.materialType)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.minimumLotSize).HasPrecision(15);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.planningYield).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.profitCenter)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.sentFromSystem)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.specialOriginalPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
        }); ; ; ;

        modelBuilder.Entity<MV_OUT_PRODUCT_SALES_CONSOLIDATE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("MV_OUT_PRODUCT_SALES_CONSOLIDATE");
            entity.Property(e => e.applicationCode3Default)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.defaultSalesOrderCreationPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.distributionChannel)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.frequencyOrderIncrement).HasPrecision(15);
            entity.Property(e => e.goldenRecord)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.materialType)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.minimumOrderQuantity).HasPrecision(15);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.salesOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.sentFromSystem)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.standardPackingQuantity).HasPrecision(15);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
        }); ; ; ;

        modelBuilder.Entity<OUT_PRODUCT_CONSOLIDATE>(entity =>
        {
            entity.HasKey(e => e.partNumber).HasName("OUT_PRODUCT_CONSOLIDATE_PK");
            entity.ToTable("OUT_PRODUCT_CONSOLIDATE");
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.MTSPNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.MTSPRevision)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.MTSPdescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.P3ExpirationDate).HasColumnType("DATE");
            entity.Property(e => e.P3QuantityLimit).HasPrecision(15);
            entity.Property(e => e.ResponsibleProductEngineer)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.activeDate).HasPrecision(6);
            entity.Property(e => e.applicationCode3Default)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.assemblyOutPackagingQty).HasPrecision(15);
            entity.Property(e => e.assemblyOutPackagingType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoShipping)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.basePartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.baseUnitOfMeasure)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.bomItemText)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.bumpType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.businessDivision)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.businessPlannerCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.businessUnit)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.buyOffFlag)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canFlagMasterComments)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canKit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRotate)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.carrierTapePocketPitch).HasPrecision(15);
            entity.Property(e => e.carrierTapeWidth).HasPrecision(15);
            entity.Property(e => e.chipVersion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.classCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.classCodeDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.companyOfOrigin)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.customerPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deactivateDateP7).HasPrecision(6);
            entity.Property(e => e.defaultSalesOrderCreationPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.diePositionForMultiDie)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.eccn)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.eccn_my)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.expiryDatePrintingFlag).HasPrecision(1);
            entity.Property(e => e.extendedSupportDate).HasColumnType("DATE");
            entity.Property(e => e.fiestaRules)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.finalTerminalFinish)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.finalTerminalFinishDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.finalTestTestProgramRevision)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.foundryPartNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.frequencyOrderIncrement).HasPrecision(15);
            entity.Property(e => e.goldenAll)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.goldenRecord)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.gradeCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.gradeCodeDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.grossDiePerWafer).HasPrecision(15);
            entity.Property(e => e.grossWeight).HasColumnType("NUMBER(15,5)");
            entity.Property(e => e.groupStage)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.groupStageName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.halogenFreePrintingFlag).HasPrecision(1);
            entity.Property(e => e.hasMultipleMPNcomponents)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.htsus)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.htsus_my)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.isPartASIC)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartAutomotive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartDolbyCapable)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartITAR)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartMultipleComponent)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartNonCancelableNonReschedule)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartNotRecommendNewDesign)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartPublish)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartRegisterable)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartSoleSource)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isSalesRoot)
                .HasDefaultValueSql("0")
                .HasPrecision(1);
            entity.Property(e => e.jedecReferenceID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.legacyMPN)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.legacyOrganization)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.lotSequenceCode).HasPrecision(15);
            entity.Property(e => e.manufacturerPart)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.manufacturerPartDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketFamily)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketFamilyDetail)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketGroup)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketSegment)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.marketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.materialGroup)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.materialType)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.materialTypeDetail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.matrixWafer)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.maximumLeadtimeByOPN).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.minimumOrderQuantity).HasPrecision(15);
            entity.Property(e => e.moistureExposureTime)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.moistureSensitiveLevel)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.mrpType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.netDieBypass)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.netWeight).HasColumnType("NUMBER(15,5)");
            entity.Property(e => e.numberOfDie).HasPrecision(15);
            entity.Property(e => e.obsoleteDateP6).HasPrecision(6);
            entity.Property(e => e.orderUntilDate).HasColumnType("DATE");
            entity.Property(e => e.originalPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.originalSourceSystem)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.packageBodySize)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageBodyThickness).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packageCategory)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageCodeDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packageGroup)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.packageLayer)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageLength).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packagePinCount).HasPrecision(15);
            entity.Property(e => e.packagePitch).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packageType)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.packageWidth).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packagingBox)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.packagingCarrier)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packagingCarrierQuantity).HasPrecision(15);
            entity.Property(e => e.packagingPackage)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packagingSpec)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.partAxis)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.partDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.pbFreeIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowPeakTemperature)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowRebakeCondition)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowStorageCondition)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pdnIssueDate).HasColumnType("DATE");
            entity.Property(e => e.pdnLastBuyDate).HasColumnType("DATE");
            entity.Property(e => e.pdnLastShipDate).HasColumnType("DATE");
            entity.Property(e => e.plasticReelSize).HasPrecision(15);
            entity.Property(e => e.plmStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.priority1OPN)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processSpecialTechnology)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("0 ");
            entity.Property(e => e.processTechnology)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.productDiscontinueNotification)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.productGeneralType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy5)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productLine)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productionDateP4).HasPrecision(6);
            entity.Property(e => e.profitCenter)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.publishedLeadTimeInWeeks)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reachPrintingFlag).HasPrecision(1);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reelHubSize).HasPrecision(15);
            entity.Property(e => e.referencePackageType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.retisSeqNo)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.roHSChinaExemptPrintingFlag).HasPrecision(1);
            entity.Property(e => e.roHSCompliant)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.roHSCompliantChina)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.roHSExemptPrintingFlag).HasPrecision(1);
            entity.Property(e => e.roughWaferProcess)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.salesRootPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.salesRootPartNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprQtyThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprTotalValThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sealDateFlag).HasPrecision(1);
            entity.Property(e => e.sentFromSystem)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.singulationProcess)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.specNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.specNoGreenOrYellow)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.standardPackingQuantity).HasPrecision(15);
            entity.Property(e => e.tacticalMarketingMgr)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.thickness).HasPrecision(15);
            entity.Property(e => e.totalNumberOfAllWires).HasPrecision(15);
            entity.Property(e => e.totalShelfLife).HasPrecision(15);
            entity.Property(e => e.tsFlag).HasPrecision(1);
            entity.Property(e => e.ulRatingsText)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ulRegistrationFlag).HasPrecision(1);
            entity.Property(e => e.unitLoadingOrientationQuadrant).HasPrecision(15);
            entity.Property(e => e.updateDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.waferOrInStockClass)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.waferSize)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.waferTechnology)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.whitePartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.wireDiameter).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.wireType)
                .HasMaxLength(20)
                .IsUnicode(false);
        });;; ;

        modelBuilder.Entity<CFG_SYSTEM_PARAM>(entity =>
        {
            entity.HasKey(e => e.CFG_SYSTEM_PARAM_ID).HasName("CFG_SYSTEM_PARAM_PK2");
            entity.ToTable("CFG_SYSTEM_PARAM");
            entity.Property(e => e.CFG_SYSTEM_PARAM_ID)
                .HasColumnType("NUMBER");
            entity.Property(e => e.PARAM_CATEGORY)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PARAM_KEY)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PARAM_VALUE).IsUnicode(false);
        });

        modelBuilder.Entity<CFG_PRODUCT>(entity =>
        {
            entity.HasKey(e => e.recordKey).HasName("CFG_PRODUCT_PK");
            entity.ToTable("CFG_PRODUCT");
            entity.HasIndex(e => e.partNumber, "CFG_PRODUCT_UK").IsUnique();
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.businessPlannerCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ")
                .IsFixedLength();
            entity.Property(e => e.minimumOrderQuantity)
                .HasPrecision(15)
                .HasDefaultValueSql("0");
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partDescApprovedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partDescApprovedDateTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.partDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.plmStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.proposePartDesc)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reviewBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.salesRootPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sentFromSystem)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.standardPackingQuantity)
                .HasPrecision(15)
                .HasDefaultValueSql("0");
            entity.Property(e => e.updateDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        });

        modelBuilder.Entity<RAW_CFG_PRODUCT_V2>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RAW_CFG_PRODUCT_V2");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createdDate)
                .HasDefaultValueSql("SYSTIMESTAMP")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.errorMessage).IsUnicode(false);
            entity.Property(e => e.haveDifference).HasPrecision(1);
            entity.Property(e => e.haveError).HasPrecision(1);
            entity.Property(e => e.insertOrUpdate)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.salesRootPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
        }); ; ; ; ;

        modelBuilder.Entity<V_CFG_PRODUCT_HIS_V2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PRODUCT_HIS_V2");
            entity.Property(e => e.CFG_PRODUCT_HIS_DATE).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.CFG_PRODUCT_HIS_DELEGATE)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CFG_PRODUCT_HIS_ID)
                .HasColumnType("NUMBER");
            entity.Property(e => e.CFG_PRODUCT_HIS_USERID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.businessDivision)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.businessPlannerCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.businessUnit)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canKit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRotate)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.isPartNotRecommendNewDesign)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isSalesRoot).HasPrecision(1);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.marketFamily)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketFamilyDetail)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketGroup)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketSegment)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.minimumOrderQuantity).HasPrecision(15);
            entity.Property(e => e.partDescApprovedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partDescApprovedDateTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.partDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.plmStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy5)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.profitCenter)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.proposePartDesc)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.salesRootPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sentFromSystem)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.standardPackingQuantity).HasPrecision(15);
        }); ;

        modelBuilder.Entity<V_CFG_PRODUCT_V2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PRODUCT_V2");
            entity.Property(e => e.businessDivision)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.businessPlannerCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.businessUnit)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canKit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRotate)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.isPartNotRecommendNewDesign)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isSalesRoot).HasPrecision(1);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.marketFamily)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketFamilyDetail)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketGroup)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketSegment)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.minimumOrderQuantity).HasPrecision(15);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partDescApprovedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partDescApprovedDateTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.partDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.plmStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy5)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.profitCenter)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.proposePartDesc)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reviewBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.reviewDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.reviewStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.salesRootPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sentFromSystem)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.standardPackingQuantity).HasPrecision(15);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        }); ;

        modelBuilder.Entity<OUT_PRODUCT_SALES_ROOT_PARTNUMBER>(entity =>
        {
            entity.HasKey(e => e.partNumber).HasName("OUT_PRODUCT_SALES_ROOT_PARTNUMBER_PK");
            entity.ToTable("OUT_PRODUCT_SALES_ROOT_PARTNUMBER");
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.applicationCode3Default)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canFlagMasterComments)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canKit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRotate)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.companyOfOrigin)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.frequencyOrderIncrement).HasPrecision(15);
            entity.Property(e => e.goldenRecord)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartNonCancelableNonReschedule)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartNotRecommendNewDesign)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartPublish)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartRegisterable)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartSoleSource)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isSalesRoot).HasPrecision(1);
            entity.Property(e => e.marketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.materialType)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.minimumOrderQuantity).HasPrecision(15);
            entity.Property(e => e.partDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.publishedLeadTimeInWeeks)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.sampleAutoApprQtyThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprTotalValThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.tacticalMarketingMgr)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
        }); ;

        modelBuilder.Entity<V_GLM_SLOC_PLANT_COMPANY>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_GLM_SLOC_PLANT_COMPANY");
            entity.Property(e => e.acctsRecblePledActive_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activateAADerivation_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activateVariantGrouping_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag_sloc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.actualActivitiesUpdated_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.actualCosting_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.address_co)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.address_plant)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.afSrceDetViaATP_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.alternativeCOA_co)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.archivingMarker_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.assignBatchesInARun_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.authorizationCheck_sloc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.baVariant_co)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.batchManagementNotActiveByDefault_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchRecDMSType_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchStatusMgmtOld_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.batchStatusMgmt_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.businessAreaFinStatements_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.businessPlace_plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.businessSystemOfMES_sloc)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.cashManagementActivated_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.cashManagementCompanyCode_co)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.chartOfAccounts_co)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.cityCode_plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.city_co)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.city_plant)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.coArea_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.companyCodeIsProductive_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.companyCode_co)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyName_co)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.company_co)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.company_plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.condsAtPlantLevel_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.contract_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.controlAreaCanBeInput_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.controlDataForBOM_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.controlOfCreditOfCostCenters_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.copyingControlGoodsReceipt_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.costObjControlling_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.costOfSalesAccountingActv_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.countryCode_sloc)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.countryRegionKey_co)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.countryRegionKey_plant)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.countyCode_plant)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime_co).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createDateAndTime_plant).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createDateAndTime_sloc).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.credIPI_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.creditControlArea_co)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.cshBdgtMgtActive_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.currency_co)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.customerNumberOfPlant_plant)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.customer_sloc)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.deferredTaxRule_co)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.defineDefaultValueDate_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime_co).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime_plant).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime_sloc).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag_sloc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.descrOfStorageLoc_sloc)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.discountBaseIsNetValue_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.distribProfileOfPlant_plant)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.distribchannel_plant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.distributionChannel_sloc)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.division_sloc)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.documentEntryScreenVariant_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.documentTypeForJVAmountCorrection_co)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.documentTypeForJVTaxCode_co)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.documentTypeForProvisionsForTaxes_co)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.enableAmountSplit_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.exchangeValuation_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.extendedWithholdingTaxActive_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.externalCoCode_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.factoryCalendar_plant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.fdsCtrActiveInHR_co).HasColumnType("DATE");
            entity.Property(e => e.fieldStatusVariant_co)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.financialAssetsMgmtActive_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.firstReminderExped_plant).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.fiscalYearVariant_co)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.fmArea_co)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.freezeBookInvSLoc_sloc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.fundsReservationFieldStatusVariant_co)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.glmPlantCode_sloc)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.globalCoCde_co)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.hedgeRequestActive_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.hideEntryInInputHelp_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.huReqmnt_sloc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.importDataGoodsReceipt_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.importDataInPurchaseOrder_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.inTransitAssignment_sloc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.inflationMethod_co)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.inputTaxCode_co)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.intCOBillingDiv_plant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.inventoryManagementType_sloc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.inventoryManagement_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.jurisdictionCode_co)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.jvAccountingActive_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.languageKey_co)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.languageKey_plant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.licenseNumber_sloc)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.managePostingPeriodForCoCodeLedger_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.maxExchangeRateDeviation_co).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.methodOffsttngAcct_co).HasColumnType("NUMBER(15,1)");
            entity.Property(e => e.mixedCosting_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.name1_plant)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.name2_plant)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.namingStructure_plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.negStocksInSLoc_sloc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.negativePostingsPermitted_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.noExchRateDiffWhenClearingInLC_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.nodeTypesupplyChain_plant)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.originalKey_co)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.outputTaxCode_co)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.ownership_plant)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.partnerStorLoc_sloc)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.planningPlant_plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plantCat_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.plant_plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plant_sloc)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.poBox_plant)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.poSchedulingAgmt_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.poTolerance_plant).HasColumnType("NUMBER(15,3)");
            entity.Property(e => e.postTranslation_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.postalCode_plant)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.postingDateForParking_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processStatus_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processStatus_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processStatus_sloc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.projectCashMgmtActive_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.proposeFiscalYear_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pstngPeriodVariant_co)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.purchOrganization_plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.purchaseAccountProcessing_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.purchaseRequisition_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.recordKey_co)
                .HasColumnType("NUMBER");
            entity.Property(e => e.recordKey_plant)
                .HasColumnType("NUMBER");
            entity.Property(e => e.region_plant)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.region_sloc)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.regularSupplier_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.remittanceChallanDocumentType_co)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.reqmtsPlanning_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.sLocMRPIndicator_sloc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.salesAreaDetrm_plant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.salesDistrict_plant)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.salesOrganization_plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.salesOrganization_sloc)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.sampleAcctRulesVar_co)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.seasonActiveInInventoryManagement_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.secondReminderExped_plant).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.shippingPointReceivingPt_plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.shippingPointReceivingPt_sloc)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.shoppingCart_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.sopPlant_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.sourceList_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.storageLocationType_sloc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.storageLocation_sloc)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageResource_sloc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.storeCat_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.streetAndHouseNumber_plant)
                .HasMaxLength(31)
                .IsUnicode(false);
            entity.Property(e => e.superiorDeptStore_plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.supplierNumberOfPlant_plant)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.supplier_sloc)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.supplyAssignmentARun_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.supplyRegion_plant)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.surchargeMethod_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.tankAssgn_sloc)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.taxBaseIsNetValue_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxCrcyTranslation_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxDetermwithDocDate_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxIndicatorPlant_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxJurisdiction_plant)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.taxReportingDateActive_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxesOnSlsPurc_co)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.template_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.text1stDunning_plant)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.text2ndDunning_plant)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.text3rdDunning_plant)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.thirdReminderExped_plant).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.timeZone_sloc)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.transitPlant_co)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime_co).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateDateAndTime_max).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateDateAndTime_plant).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateDateAndTime_sloc).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateFM_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateMMInCMF_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateSDInCMF_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateType_co)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateType_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateType_sloc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.validity_sloc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.valuationArea_plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.varianceKey_plant)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.vatRegistrationNo_co)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.vendorType_plant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.workflowVariant_co)
                .HasMaxLength(4)
                .IsUnicode(false);
        }); ; ;

        modelBuilder.Entity<OUT_APP_APPLICATION1>(entity =>
        {
            entity.HasKey(e => e.applicationLevel1Code).HasName("OUT_APP_APPLICATION1_PK");

            entity.ToTable("OUT_APP_APPLICATION1");

            entity.Property(e => e.applicationLevel1Code)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel1Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.recordKey)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
        });

        modelBuilder.Entity<OUT_APP_APPLICATION2>(entity =>
        {
            entity.HasKey(e => e.applicationLevel2Code).HasName("OUT_APP_APPLICATION2_PK");

            entity.ToTable("OUT_APP_APPLICATION2");

            entity.Property(e => e.applicationLevel2Code)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel1Code)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel2Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.recordKey)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("'N' ");
        });

        modelBuilder.Entity<OUT_APP_APPLICATION3>(entity =>
        {
            entity.HasKey(e => e.applicationLevel3Code).HasName("OUT_APP_APPLICATION3_PK");

            entity.ToTable("OUT_APP_APPLICATION3");

            entity.Property(e => e.applicationLevel3Code)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel2Code)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.applicationLevel3Name)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.recordKey)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("'N' ");
        });

        modelBuilder.Entity<OUT_PRODUCT_STANDARD_COST>(entity =>
        {
            entity.HasKey(e => new { e.companyCode, e.postingDate, e.plant, e.partNumberKey }).HasName("OUT_PRODUCT_STD_COST_PK");

            entity.ToTable("OUT_PRODUCT_STANDARD_COST");

            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.postingDate).HasColumnType("DATE");
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.companyCodeCurrency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.companyCodeCurrencyLegalValuation).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.createDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("'N'")
                .IsFixedLength();
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.priceUnit).HasColumnType("NUMBER");
            entity.Property(e => e.processStatus)
                .IsRequired()
                .HasDefaultValueSql("0")
                .HasPrecision(1);
            entity.Property(e => e.recordKey)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<V_MODELN_CUS_SHIP_TO>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_MODELN_CUS_SHIP_TO");

            entity.Property(e => e.ACCOUNT_NUM)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ADDRESS1)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.ADDRESS2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.ADDRESS3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.ADDR_CODE)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ADDR_DISPLAY)
                .HasMaxLength(31)
                .IsUnicode(false);
            entity.Property(e => e.CITY)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.COUNTRY)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.STATE)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.STATUS)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.ZIP)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.customerCode)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<V_MODELN_CUS_BILL_TO>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_MODELN_CUS_BILL_TO");

            entity.Property(e => e.ACCOUNT_NUM)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ADDRESS1)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.ADDRESS2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.ADDRESS3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.ADDR_CODE)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ADDR_DISPLAY)
                .HasMaxLength(31)
                .IsUnicode(false);
            entity.Property(e => e.CITY)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.COUNTRY)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.STATE)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.ZIP)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.customerCode)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OUT_PRODUCT_CONSOLIDATE>(entity =>
        {
            entity.HasKey(e => e.partNumber).HasName("OUT_PRODUCT_CONSOLIDATE_PK");
            entity.ToTable("OUT_PRODUCT_CONSOLIDATE");
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.MTSPNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.MTSPRevision)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.MTSPdescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.P3ExpirationDate).HasColumnType("DATE");
            entity.Property(e => e.P3QuantityLimit).HasPrecision(15);
            entity.Property(e => e.ResponsibleProductEngineer)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.activeDate).HasPrecision(6);
            entity.Property(e => e.applicationCode3Default)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.assemblyOutPackagingQty).HasPrecision(15);
            entity.Property(e => e.assemblyOutPackagingType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoShipping)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.basePartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.baseUnitOfMeasure)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.bomItemText)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.bumpType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.businessDivision)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.businessPlannerCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.businessUnit)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.buyOffFlag)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canFlagMasterComments)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canKit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRotate)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.carrierTapePocketPitch).HasPrecision(15);
            entity.Property(e => e.carrierTapeWidth).HasPrecision(15);
            entity.Property(e => e.chipVersion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.classCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.classCodeDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.companyOfOrigin)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.customerPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deactivateDateP7).HasPrecision(6);
            entity.Property(e => e.defaultSalesOrderCreationPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.diePositionForMultiDie)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.eccn)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.eccn_my)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.expiryDatePrintingFlag).HasPrecision(1);
            entity.Property(e => e.extendedSupportDate).HasColumnType("DATE");
            entity.Property(e => e.fiestaRules)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.finalTerminalFinish)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.finalTerminalFinishDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.finalTestTestProgramRevision)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.foundryPartNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.frequencyOrderIncrement).HasPrecision(15);
            entity.Property(e => e.goldenAll)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.goldenRecord)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.gradeCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.gradeCodeDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.grossDiePerWafer).HasPrecision(15);
            entity.Property(e => e.grossWeight).HasColumnType("NUMBER(15,5)");
            entity.Property(e => e.groupStage)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.groupStageName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.halogenFreePrintingFlag).HasPrecision(1);
            entity.Property(e => e.hasMultipleMPNcomponents)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.htsus)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.htsus_my)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.isPartASIC)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartAutomotive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartDolbyCapable)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartITAR)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartMultipleComponent)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartNonCancelableNonReschedule)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartNotRecommendNewDesign)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartPublish)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartRegisterable)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartSoleSource)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isSalesRoot)
                .HasDefaultValueSql("0")
                .HasPrecision(1);
            entity.Property(e => e.jedecReferenceID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.legacyMPN)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.legacyOrganization)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.lotSequenceCode).HasPrecision(15);
            entity.Property(e => e.manufacturerPart)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.manufacturerPartDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketFamily)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketFamilyDetail)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketGroup)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketSegment)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.marketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.materialGroup)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.materialType)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.materialTypeDetail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.matrixWafer)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.maximumLeadtimeByOPN).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.minimumOrderQuantity).HasPrecision(15);
            entity.Property(e => e.moistureExposureTime)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.moistureSensitiveLevel)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.mrpType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.netDieBypass)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.netWeight).HasColumnType("NUMBER(15,5)");
            entity.Property(e => e.numberOfDie).HasPrecision(15);
            entity.Property(e => e.obsoleteDateP6).HasPrecision(6);
            entity.Property(e => e.orderUntilDate).HasColumnType("DATE");
            entity.Property(e => e.originalPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.originalSourceSystem)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.packageBodySize)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageBodyThickness).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packageCategory)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageCodeDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packageGroup)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.packageLayer)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageLength).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packagePinCount).HasPrecision(15);
            entity.Property(e => e.packagePitch).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packageType)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.packageWidth).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packagingBox)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.packagingCarrier)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packagingCarrierQuantity).HasPrecision(15);
            entity.Property(e => e.packagingPackage)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packagingSpec)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.partAxis)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.partDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.pbFreeIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowPeakTemperature)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowRebakeCondition)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowStorageCondition)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pdnIssueDate).HasColumnType("DATE");
            entity.Property(e => e.pdnLastBuyDate).HasColumnType("DATE");
            entity.Property(e => e.pdnLastShipDate).HasColumnType("DATE");
            entity.Property(e => e.plasticReelSize).HasPrecision(15);
            entity.Property(e => e.plmStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.priority1OPN)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processSpecialTechnology)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("0 ");
            entity.Property(e => e.processTechnology)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.productDiscontinueNotification)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.productGeneralType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy5)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productLine)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productionDateP4).HasPrecision(6);
            entity.Property(e => e.profitCenter)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.publishedLeadTimeInWeeks)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reachPrintingFlag).HasPrecision(1);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reelHubSize).HasPrecision(15);
            entity.Property(e => e.referencePackageType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.retisSeqNo)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.roHSChinaExemptPrintingFlag).HasPrecision(1);
            entity.Property(e => e.roHSCompliant)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.roHSCompliantChina)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.roHSExemptPrintingFlag).HasPrecision(1);
            entity.Property(e => e.roughWaferProcess)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.salesRootPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.salesRootPartNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprQtyThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprTotalValThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sealDateFlag).HasPrecision(1);
            entity.Property(e => e.sentFromSystem)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.singulationProcess)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.specNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.specNoGreenOrYellow)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.standardPackingQuantity).HasPrecision(15);
            entity.Property(e => e.tacticalMarketingMgr)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.thickness).HasPrecision(15);
            entity.Property(e => e.totalNumberOfAllWires).HasPrecision(15);
            entity.Property(e => e.totalShelfLife).HasPrecision(15);
            entity.Property(e => e.tsFlag).HasPrecision(1);
            entity.Property(e => e.ulRatingsText)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ulRegistrationFlag).HasPrecision(1);
            entity.Property(e => e.unitLoadingOrientationQuadrant).HasPrecision(15);
            entity.Property(e => e.updateDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.waferOrInStockClass)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.waferSize)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.waferTechnology)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.whitePartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.wireDiameter).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.wireType)
                .HasMaxLength(20)
                .IsUnicode(false);
        });;; ;

        modelBuilder.Entity<OUT_PRODUCT_HISTORICAL>(entity =>
        {
            entity.HasKey(e => e.partNumber).HasName("OUT_PRODUCT_HISTORICAL_PK");

            entity.ToTable("OUT_PRODUCT_HISTORICAL");

            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.activeDate).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.applicationCode3Default)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.assemblyOutPackagingQty).HasPrecision(15);
            entity.Property(e => e.assemblyOutPackagingType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoShipping)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.basePartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.baseUnitOfMeasure)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.bomItemText)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.bumpType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.businessDivision)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.businessPlannerCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.businessUnit)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canFlagMasterComments)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canKit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRotate)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.carrierTapePocketPitch).HasPrecision(15);
            entity.Property(e => e.carrierTapeWidth).HasPrecision(15);
            entity.Property(e => e.chipVersion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.classCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.classCodeDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.companyOfOrigin)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.customerPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deactivateDateP7).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.defaultSalesOrderCreationPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.diePositionForMultiDie)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.eccn)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.eccn_my)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.expiryDatePrintingFlag).HasPrecision(1);
            entity.Property(e => e.extendedSupportDate).HasColumnType("DATE");
            entity.Property(e => e.fiestaRules)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.finalTerminalFinish)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.finalTerminalFinishDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.finalTestTestProgramRevision)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.foundryPartNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.frequencyOrderIncrement).HasPrecision(15);
            entity.Property(e => e.goldenAll)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.goldenRecord)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.gradeCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.gradeCodeDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.grossDiePerWafer).HasPrecision(15);
            entity.Property(e => e.grossWeight).HasColumnType("NUMBER(15,5)");
            entity.Property(e => e.groupStage)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.groupStageName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.halogenFreePrintingFlag).HasPrecision(1);
            entity.Property(e => e.htsus)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.htsus_my)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.isPartASIC)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartAutomotive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartDolbyCapable)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartITAR)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartMultipleComponent)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartNonCancelableNonReschedule)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartNotRecommendNewDesign)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartPublish)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartRegisterable)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartSoleSource)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isSalesRoot).HasColumnType("NUMBER");
            entity.Property(e => e.jedecReferenceID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.legacyMPN)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.legacyOrganization)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.lotSequenceCode).HasPrecision(15);
            entity.Property(e => e.manufacturerPart)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.manufacturerPartDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketFamily)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketFamilyDetail)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketGroup)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketSegment)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.marketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.materialGroup)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.materialType)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.materialTypeDetail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.matrixWafer)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.minimumOrderQuantity).HasPrecision(15);
            entity.Property(e => e.moistureExposureTime)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.moistureSensitiveLevel)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.mrpType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.netDieBypass)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.netWeight).HasColumnType("NUMBER(15,5)");
            entity.Property(e => e.numberOfDie).HasPrecision(15);
            entity.Property(e => e.obsoleteDateP6).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.orderUntilDate).HasColumnType("DATE");
            entity.Property(e => e.originalPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.originalSourceSystem)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.packageBodySize)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageBodyThickness).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packageCategory)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageCodeDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packageGroup)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.packageLayer)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageLength).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packagePinCount).HasPrecision(15);
            entity.Property(e => e.packagePitch).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packageType)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.packageWidth).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packagingBox)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.packagingCarrier)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packagingCarrierQuantity).HasPrecision(15);
            entity.Property(e => e.packagingPackage)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packagingSpec)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.partAxis)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.partDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.pbFreeIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowPeakTemperature)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowRebakeCondition)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowStorageCondition)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pdnIssueDate).HasColumnType("DATE");
            entity.Property(e => e.pdnLastBuyDate).HasColumnType("DATE");
            entity.Property(e => e.pdnLastShipDate).HasColumnType("DATE");
            entity.Property(e => e.plasticReelSize).HasPrecision(15);
            entity.Property(e => e.plmStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.priority1OPN)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processSpecialTechnology)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.processTechnology)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.productDiscontinueNotification)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.productGeneralType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy5)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productLine)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productionDateP4).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.profitCenter)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.publishedLeadTimeInWeeks)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reachPrintingFlag).HasPrecision(1);
            entity.Property(e => e.recordKey)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.reelHubSize).HasPrecision(15);
            entity.Property(e => e.referencePackageType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.retisSeqNo)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.roHSChinaExemptPrintingFlag).HasPrecision(1);
            entity.Property(e => e.roHSCompliant)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.roHSCompliantChina)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.roHSExemptPrintingFlag).HasPrecision(1);
            entity.Property(e => e.roughWaferProcess)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.salesRootPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.salesRootPartNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprQtyThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprTotalValThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sealDateFlag).HasPrecision(1);
            entity.Property(e => e.singulationProcess)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.specNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.specNoGreenOrYellow)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.standardPackingQuantity).HasPrecision(15);
            entity.Property(e => e.tacticalMarketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.thickness).HasPrecision(15);
            entity.Property(e => e.totalNumberOfAllWires).HasPrecision(15);
            entity.Property(e => e.totalShelfLife).HasPrecision(15);
            entity.Property(e => e.tsFlag).HasPrecision(1);
            entity.Property(e => e.ulRatingsText)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ulRegistrationFlag).HasPrecision(1);
            entity.Property(e => e.unitLoadingOrientationQuadrant).HasPrecision(15);
            entity.Property(e => e.updateDateAndTime)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.waferOrInStockClass)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.waferSize)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.waferTechnology)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.whitePartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.wireDiameter).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.wireType)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OUT_PRODUCT_SALES_ROOT_PARTNUMBER>(entity =>
        {
            entity.HasKey(e => e.partNumber).HasName("OUT_PRODUCT_SALES_ROOT_PARTNUMBER_PK");

            entity.ToTable("OUT_PRODUCT_SALES_ROOT_PARTNUMBER");

            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.applicationCode3Default)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canFlagMasterComments)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canKit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRotate)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.companyOfOrigin)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.frequencyOrderIncrement).HasPrecision(15);
            entity.Property(e => e.goldenRecord)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartNonCancelableNonReschedule)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartNotRecommendNewDesign)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartPublish)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartRegisterable)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartSoleSource)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isSalesRoot).HasPrecision(1);
            entity.Property(e => e.marketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.materialType)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.minimumOrderQuantity).HasPrecision(15);
            entity.Property(e => e.partDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3Code)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.publishedLeadTimeInWeeks)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.sampleAutoApprQtyThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprTotalValThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.tacticalMarketingMgr)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
        });

        modelBuilder.Entity<OUT_PRODUCT_ECCN_CONVERSION>(entity =>
        {
            entity.HasKey(e => new { e.countryCode, e.legalRegulation, e.partNumber, e.foreignTradeOrganization }).HasName("OUT_PRODUCT_ECCN_CONVERSION_PK");

            entity.ToTable("OUT_PRODUCT_ECCN_CONVERSION");

            entity.Property(e => e.countryCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.legalRegulation)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.foreignTradeOrganization)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.ccat)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.controlGroup)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.eccn)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.indiMaintenance)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.noControl)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.recordKey)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
        });

        modelBuilder.Entity<OUT_PRODUCT_HS_CONVERSION>(entity =>
        {
            entity.HasKey(e => new { e.hsType, e.countryCode, e.partNumber }).HasName("OUT_PRODUCT_HS_CONVERSION_PK");

            entity.ToTable("OUT_PRODUCT_HS_CONVERSION");

            entity.Property(e => e.hsType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.countryCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.hsCode)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.hsDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.hsDescriptionDE)
                .HasMaxLength(240)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.recordKey)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.validFrom).HasColumnType("DATE");
            entity.Property(e => e.validTo).HasColumnType("DATE");
        });

        modelBuilder.Entity<MDM_COMPANY_CODE>(entity =>
        {
            entity.HasKey(e => e.companyCode).HasName("MDM_COMPANY_CODE_PK");
            entity.ToTable("MDM_COMPANY_CODE");
            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.acctsRecblePledActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activateAADerivation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'1' ");
            entity.Property(e => e.address)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.alternativeCOA)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.baVariant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.businessAreaFinStatements)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.cashManagementActivated)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.cashManagementCompanyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.chartOfAccounts)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.city)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.coArea)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.company)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.companyCodeIsProductive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.companyName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.contract)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.controlAreaCanBeInput)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.copyingControlGoodsReceipt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.costOfSalesAccountingActv)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.countryRegionKey)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.creditControlArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.cshBdgtMgtActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.currency)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.deferredTaxRule)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.defineDefaultValueDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.discountBaseIsNetValue)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.documentEntryScreenVariant)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.documentTypeForJVAmountCorrection)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.documentTypeForJVTaxCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.documentTypeForProvisionsForTaxes)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.enableAmountSplit)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.extendedWithholdingTaxActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.externalCoCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.fdsCtrActiveInHR).HasColumnType("DATE");
            entity.Property(e => e.fieldStatusVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.financialAssetsMgmtActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.fiscalYearVariant)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.fmArea)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.fundsReservationFieldStatusVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.globalCoCde)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.hedgeRequestActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.hideEntryInInputHelp)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.importDataGoodsReceipt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.importDataInPurchaseOrder)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.inflationMethod)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.inputTaxCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.inventoryManagement)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.jurisdictionCode)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.jvAccountingActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.languageKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.managePostingPeriodForCoCodeLedger)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.maxExchangeRateDeviation).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.methodOffsttngAcct).HasColumnType("NUMBER(15,1)");
            entity.Property(e => e.negativePostingsPermitted)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.noExchRateDiffWhenClearingInLC)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.originalKey)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.outputTaxCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.poSchedulingAgmt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.postTranslation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.postingDateForParking)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.projectCashMgmtActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.proposeFiscalYear)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pstngPeriodVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.purchaseAccountProcessing)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.purchaseRequisition)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.remittanceChallanDocumentType)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.sampleAcctRulesVar)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.shoppingCart)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.surchargeMethod)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxBaseIsNetValue)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxCrcyTranslation)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxDetermwithDocDate)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxReportingDateActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taxesOnSlsPurc)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.template)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.transitPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateFM)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateMMInCMF)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateSDInCMF)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.vatRegistrationNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.workflowVariant)
                .HasMaxLength(4)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MDM_PRODUCTION_GROUP_STAGE>(entity =>
        {
            entity.HasKey(e => e.groupStage).HasName("MDM_PRODUCTION_GROUP_STAGE_PK");
            entity.ToTable("MDM_PRODUCTION_GROUP_STAGE");
            entity.Property(e => e.groupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'1' ");
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.groupStageExplanation)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.groupStageName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.groupStageRecordID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.groupStageSequence).HasColumnType("NUMBER(15,10)");
            entity.Property(e => e.groupStageType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.inputUoM)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.outputUoM)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
        });

        modelBuilder.Entity<MDM_PRODUCTION_GROUP_STAGE_CONVERSION>(entity =>
        {
            entity.HasKey(e => new { e.groupStage, e.legacyType, e.legacyGroupStage }).HasName("MDM_PRODUCTION_GROUP_STAGE_CONVERSION_PK");
            entity.ToTable("MDM_PRODUCTION_GROUP_STAGE_CONVERSION");
            entity.Property(e => e.groupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.legacyType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.legacyGroupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'1' ");
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.groupStageVSLegacyGroupStageRecordID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
        });

        modelBuilder.Entity<MDM_PRODUCTION_PLANT_CONVERSION>(entity =>
        {
            entity.HasKey(e => new { e.company, e.plant, e.storageLocation, e.legacyType, e.legacyLine, e.groupStage, e.massProductionFlag }).HasName("MDM_PRODUCTION_PLANT_CONVERSION_PK");
            entity.ToTable("MDM_PRODUCTION_PLANT_CONVERSION");
            entity.Property(e => e.company)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.legacyType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.legacyLine)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.groupStage)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.massProductionFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'1' ");
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.hmeType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.plantAndSlocVsLegacyLineRecordID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
        });

        modelBuilder.Entity<MDM_PRODUCT_HIERARCHY>(entity =>
        {
            entity.HasKey(e => e.phCode).HasName("MDM_PRODUCT_HIERARCHY_PK");
            entity.ToTable("MDM_PRODUCT_HIERARCHY");
            entity.Property(e => e.phCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N'")
                .IsFixedLength();
            entity.Property(e => e.level)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.phDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.upperKey)
                .HasMaxLength(8)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MDM_PROFIT_CENTER>(entity =>
        {
            entity.HasKey(e => e.PRCTR).HasName("MDM_PROFIT_CENTER_PK");
            entity.ToTable("MDM_PROFIT_CENTER");
            entity.Property(e => e.PRCTR)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DATBI).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.KHINR)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.KTEXT)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<MDM_PROFIT_CENTER_HIERARCHY>(entity =>
        {
            entity.HasKey(e => new { e.setName, e.lineID }).HasName("MDM_PROFIT_CENTER_HIERARCHY_PK");
            entity.ToTable("MDM_PROFIT_CENTER_HIERARCHY");
            entity.Property(e => e.setName)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.lineID).HasPrecision(10);
            entity.Property(e => e.createDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N'")
                .IsFixedLength();
            entity.Property(e => e.description)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.subSetName)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<MDM_STORAGE_LOCATION>(entity =>
        {
            entity.HasKey(e => new { e.plant, e.storageLocation }).HasName("MDM_STORAGE_LOCATION_PK");
            entity.ToTable("MDM_STORAGE_LOCATION");
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'1' ");
            entity.Property(e => e.authorizationCheck)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.businessSystemOfMES)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.countryCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.customer)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.descrOfStorageLoc)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.distributionChannel)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.division)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.freezeBookInvSLoc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.glmPlantCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.huReqmnt)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.inTransitAssignment)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.inventoryManagementType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.licenseNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.negStocksInSLoc)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partnerStorLoc)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.region)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.sLocMRPIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.salesOrganization)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.shippingPointReceivingPt)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageLocationType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.storageResource)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.supplier)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.tankAssgn)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.timeZone)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.validity)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OUT_COMPONENT>(entity =>
        {
            entity.HasKey(e => new { e.partNumber, e.groupStageFlowNumber, e.componentPartNumber }).HasName("OUT_COMPONENTS_PK");
            entity.ToTable("OUT_COMPONENTS");
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.groupStageFlowNumber)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.componentPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.buyOffFlag)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("'N'");
            entity.Property(e => e.componentConsumption)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N'");
            entity.Property(e => e.componentLeadTime)
                .HasDefaultValueSql("0.00")
                .HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.componentPartType)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.componentStandardUsage)
                .HasDefaultValueSql("0.00")
                .HasColumnType("NUMBER(15,6)");
            entity.Property(e => e.componentSubType)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.componentUOM)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N'");
            entity.Property(e => e.factoryFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.fiestaRules)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.groupStage)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.legacyLine)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.originalPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("0\n   ");
            entity.Property(e => e.processingSubType)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OUT_PRODUCT_VENDOR_CHAR>(entity =>
        {
            entity.HasKey(e => new { e.partNumber, e.groupStageFlowNumber, e.groupStageStep, e.characteristicsName }).HasName("OUT_PRODUCT_VENDOR_CHAR_PK");
            entity.ToTable("OUT_PRODUCT_VENDOR_CHAR");
            entity.HasIndex(e => new { e.originalPartNumber, e.groupStage, e.groupStageFlowNumber, e.groupStageStep, e.characteristicsName }, "OUT_PRODUCT_VENDOR_CHAR_UK1").IsUnique();
            entity.HasIndex(e => new { e.partNumber, e.plant, e.storageLocation, e.groupStageFlowNumber, e.groupStageStep, e.characteristicsName }, "OUT_PRODUCT_VENDOR_CHAR_UK2").IsUnique();
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.groupStageFlowNumber)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasDefaultValueSql("' ' ");
            entity.Property(e => e.groupStageStep)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.characteristicsName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.buyOffFlag)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("'N'");
            entity.Property(e => e.characteristicsValue)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.factoryFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.fiestaRules)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.groupStage)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.legacyLine)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.originalPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("0 ");
            entity.Property(e => e.processingSubType)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OUT_PRODUCT_MATRIX>(entity =>
        {
            entity.HasKey(e => new { e.partNumber, e.finishedWaferNumber }).HasName("OUT_PRODUCT_MATRIX_PK");
            entity.ToTable("OUT_PRODUCT_MATRIX");
            entity.HasIndex(e => new { e.originalPartNumber, e.groupStage, e.finishedWaferNumber }, "OUT_PRODUCT_MATRIX_UK1").IsUnique();
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.finishedWaferNumber)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.bin)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.buyOffFlag)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("'N'");
            entity.Property(e => e.createDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ")
                .IsFixedLength();
            entity.Property(e => e.fiestaRules)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.fontDiePerWafer).HasColumnType("NUMBER(38)");
            entity.Property(e => e.groupStage)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.matrixBin)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.matrixBins)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.originalPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("0 ");
            entity.Property(e => e.processingSubType)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<OUT_PRODUCTION_BOM>(entity =>
        {
            entity.HasKey(e => new { e.partNumber, e.plant, e.bomUsage, e.bomAlternative, e.bomItem }).HasName("OUT_PRODUCTION_BOM_PK");
            entity.ToTable("OUT_PRODUCTION_BOM");
            entity.HasIndex(e => new { e.partNumber, e.baseQuantity, e.deleteFlag }, "OUT_PRODUCTION_BOM_INDEX1");
            entity.HasIndex(e => new { e.bomKey, e.bomAlternative, e.bomItem }, "OUT_PRODUCTION_BOM_UK1").IsUnique();
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.bomUsage)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.bomAlternative)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.bomItem)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.baseGroupStage)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.baseGroupStageType).HasPrecision(15);
            entity.Property(e => e.baseQuantity).HasPrecision(15);
            entity.Property(e => e.baseUnitOfMeasure)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.bomItemTextLine1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.bomItemTextLine2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.bomKey)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.bomStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.buyOffFlag)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("'N'");
            entity.Property(e => e.componentGroupStage)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.componentGroupStageType).HasPrecision(15);
            entity.Property(e => e.componentPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.componentPartNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.componentQuantity).HasPrecision(15);
            entity.Property(e => e.componentUnitOfMeasure)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.factoryFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.fiestaRules)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.headerDeleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("0 ");
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.validFromDate).HasColumnType("DATE");
            entity.Property(e => e.validToDate).HasColumnType("DATE");
        });

        modelBuilder.Entity<OUT_PRODUCTION_ROUTING>(entity =>
        {
            entity.HasKey(e => new { e.partNumber, e.glmWF, e.glmSequence, e.glmAlternative }).HasName("OUT_PRODUCTION_ROUTING_PK");
            entity.ToTable("OUT_PRODUCTION_ROUTING");
            entity.HasIndex(e => e.partNumber, "OUT_PRODUCTION_ROUTING_IDX1");
            entity.HasIndex(e => new { e.partNumber, e.plant, e.groupStage }, "OUT_PRODUCTION_ROUTING_IDX2");
            entity.HasIndex(e => new { e.partNumber, e.plant, e.groupStage, e.glmWF }, "OUT_PRODUCTION_ROUTING_IDX3");
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.glmWF)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.glmSequence).HasPrecision(15);
            entity.Property(e => e.glmAlternative).HasPrecision(2);
            entity.Property(e => e.buyOffFlag)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("'N'");
            entity.Property(e => e.connectFromGLMAlternative)
                .HasPrecision(2)
                .HasDefaultValueSql("NULL");
            entity.Property(e => e.connectFromGLMSeq)
                .HasPrecision(15)
                .HasDefaultValueSql("NULL");
            entity.Property(e => e.conversionFactor)
                .HasPrecision(15)
                .HasDefaultValueSql("1");
            entity.Property(e => e.costCenter)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.endOfGroupStage)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.factoryFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.fiestaRules)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.glmStage)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.groupStage)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.groupStageFlow)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.groupStageFlowPlmStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.groupStageType).HasPrecision(15);
            entity.Property(e => e.hmeType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.laborTime)
                .HasDefaultValueSql("0.00")
                .HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.laborTimeUnitOfMeasure)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.leadTime)
                .HasDefaultValueSql("0.00")
                .HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.leadTimeUnitOfMeasure)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.legacyLine)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.legacyStage)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.mpnToOPNFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.operationNumber)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.originalPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("0 ");
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.routingGroupKey)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.routingKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.s4OperationNumber)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.setupTime)
                .HasDefaultValueSql("0.00")
                .HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.setupTimeUnitOfMeasure)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.specialOriginalPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageLocationType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.supplyLegacyLine)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.supplyPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.supplyStorageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.taskListDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.unitOfMeasure)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.validFromDate).HasColumnType("DATE");
            entity.Property(e => e.validToDate).HasColumnType("DATE");
        });

        modelBuilder.Entity<OUT_PRODUCTION_ROUTING_S4>(entity =>
        {
            entity.HasKey(e => new { e.partNumber, e.plant, e.storageLocation, e.routingGroupKey, e.routingKey, e.s4OperationNumber }).HasName("OUT_PRODUCTION_ROUTING_S4_PK");
            entity.ToTable("OUT_PRODUCTION_ROUTING_S4");
            entity.HasIndex(e => new { e.routingGroupKey, e.routingKey, e.s4OperationNumber, e.deleteFlag }, "OUT_PRODUCTION_ROUTING_S4_UK1").IsUnique();
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.routingGroupKey)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.routingKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.s4OperationNumber)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.buyOffFlag)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("'N'");
            entity.Property(e => e.controlKey)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.conversionFactor)
                .HasPrecision(15)
                .HasDefaultValueSql("1");
            entity.Property(e => e.createDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.fiestaRules)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.groupStage)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.headerDeleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.laborTime)
                .HasDefaultValueSql("0.00")
                .HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.laborTimeUnitOfMeasure)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.leadTime)
                .HasDefaultValueSql("0.00")
                .HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.leadTimeUnitOfMeasure)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.legacyLine)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("0 ");
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.s4OperationLongText)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.s4OperationShortText)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.setupTime)
                .HasDefaultValueSql("0.00")
                .HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.setupTimeUnitOfMeasure)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.taskListDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.unitOfMeasure)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.validFromDate).HasColumnType("DATE");
            entity.Property(e => e.validToDate).HasColumnType("DATE");
            entity.Property(e => e.workCenter)
                .HasMaxLength(4)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OUT_PRODUCTION_VERSION>(entity =>
        {
            entity.HasKey(e => new { e.partNumber, e.plant, e.storageLocation, e.productionVersion }).HasName("OUT_PRODUCTION_VERSION_PK");
            entity.ToTable("OUT_PRODUCTION_VERSION");
            entity.HasIndex(e => new { e.bomKey, e.bomAlternative, e.routingGroupKey, e.routingKey, e.deleteFlag }, "OUT_PRODUCTION_VERSION_UK1").IsUnique();
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.productionVersion)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.bomAlternative)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.bomKey)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.bomUsage)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.buyOffFlag)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("'N'");
            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.fiestaRules)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.glmWF)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.groupStageType).HasPrecision(15);
            entity.Property(e => e.legacyLine)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.netDieBypass)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberType)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("0 ");
            entity.Property(e => e.productionVersionLock)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.routingGroupKey)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.routingKey)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.taskListDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.validFromDate).HasColumnType("DATE");
            entity.Property(e => e.validToDate).HasColumnType("DATE");
        });

        modelBuilder.Entity<OUT_PRODUCTION_ALTERNATIVES_MIX_RATIO>(entity =>
        {
            entity.HasKey(e => new { e.partNumber, e.plant, e.storageLocation, e.supplyPlant, e.supplyStorageLocation, e.flowAlternative }).HasName("OUT_PRODUCTION_ALTERNATIVES_MIX_RATIOS_PK");
            entity.ToTable("OUT_PRODUCTION_ALTERNATIVES_MIX_RATIOS");
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.supplyPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.supplyStorageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.flowAlternative)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.buyOffFlag)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("'N'");
            entity.Property(e => e.createDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.fiestaRules)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.legacyLine)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.priority)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("0 ");
            entity.Property(e => e.productionVersion)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.ratio).HasColumnType("NUMBER(16,2)");
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.supplyLegacyLine)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OUT_PRODUCTION_CYCLETIME>(entity =>
        {
            entity.HasKey(e => new { e.partNumber, e.plant, e.storageLocation, e.glmStage, e.classification, e.validFromDate }).HasName("OUT_PRODUCTION_CYCLETIME_PK");
            entity.ToTable("OUT_PRODUCTION_CYCLETIME");
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.glmStage)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.classification)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.validFromDate).HasColumnType("DATE");
            entity.Property(e => e.buyOffFlag)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("'N'");
            entity.Property(e => e.createDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.factoryFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("' ' ");
            entity.Property(e => e.groupStage)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.legacyLine)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.originalPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("0 ");
            entity.Property(e => e.quantityUnitOfTime)
                .HasPrecision(15)
                .HasDefaultValueSql("1 ");
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.time)
                .HasDefaultValueSql("0 ")
                .HasColumnType("NUMBER(15,5)");
            entity.Property(e => e.unitOfTime)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OUT_PRODUCTION_LEADTIME>(entity =>
        {
            entity.HasKey(e => new { e.partNumber, e.plant, e.storageLocation, e.glmStage, e.validFromDate }).HasName("OUT_PRODUCTION_LEADTIME_PK");
            entity.ToTable("OUT_PRODUCTION_LEADTIME");
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.glmStage)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.validFromDate).HasColumnType("DATE");
            entity.Property(e => e.buyOffFlag)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("'N'");
            entity.Property(e => e.createDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.defaultLeadTime).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.factoryFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("' ' ");
            entity.Property(e => e.groupStage)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.leadTime).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.legacyLine)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("0 ");
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.totalStage).HasPrecision(15);
            entity.Property(e => e.updateDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OUT_PRODUCTION_LOTSIZE>(entity =>
        {
            entity.HasKey(e => new { e.partNumber, e.plant, e.storageLocation }).HasName("OUT_PRODUCTION_LOTSIZE_PK");
            entity.ToTable("OUT_PRODUCTION_LOTSIZE");
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.buyOffFlag)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("'N'");
            entity.Property(e => e.createDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.defaultMinimumLotSize).HasPrecision(15);
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.groupStage)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.incrementLotSize).HasPrecision(15);
            entity.Property(e => e.legacyLine)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.lotSizingProcedure)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.maximumLotSize).HasPrecision(15);
            entity.Property(e => e.minimumLotSize).HasPrecision(15);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("0 ");
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OUT_PRODUCTION_YIELD>(entity =>
        {
            entity.HasKey(e => new { e.partNumber, e.plant, e.storageLocation, e.glmStage, e.yieldFlag, e.validFromDate }).HasName("OUT_PRODUCTION_YIELD_PK");
            entity.ToTable("OUT_PRODUCTION_YIELD");
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.plant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.storageLocation)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.glmStage)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.yieldFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("' '");
            entity.Property(e => e.validFromDate).HasColumnType("DATE");
            entity.Property(e => e.buyOffFlag)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("'N'");
            entity.Property(e => e.createDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.defaultYield).HasColumnType("NUMBER(15,4)");
            entity.Property(e => e.deleteDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.factoryFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("' ' ");
            entity.Property(e => e.flowNumber)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.groupStage)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.legacyLine)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.pattern)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("0 ");
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.totalStage).HasPrecision(15);
            entity.Property(e => e.updateDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.yield).HasColumnType("NUMBER(15,4)");
        });

        modelBuilder.Entity<MDM_PRODUCTION_STAGE>(entity =>
        {
            entity.HasKey(e => e.stage).HasName("MDM_PRODUCTION_STAGE_PK");
            entity.ToTable("MDM_PRODUCTION_STAGE");
            entity.Property(e => e.stage)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.buyOffFlag)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("'Y'");
            entity.Property(e => e.fiesta_sys_createTimeStamp)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.fiesta_sys_updateTimeStamp)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.isRecordActive).HasPrecision(16);
            entity.Property(e => e.isRecordActiveChangeDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.stageName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.stageRecordID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
        }); ;

        modelBuilder.Entity<MDM_PRODUCTION_STAGE_CONVERSION>(entity =>
        {
            entity.HasKey(e => new { e.stage, e.legacyType, e.legacyStage }).HasName("MDM_PRODUCTION_STAGE_CONVERSION_PK");
            entity.ToTable("MDM_PRODUCTION_STAGE_CONVERSION");
            entity.Property(e => e.stage)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.legacyType)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.legacyStage)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.activeFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.buyOffFlag)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasDefaultValueSql("'Y'");
            entity.Property(e => e.fiesta_sys_createTimeStamp)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.fiesta_sys_updateTimeStamp)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.isRecordActive).HasPrecision(16);
            entity.Property(e => e.isRecordActiveChangeDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.stageVSLegacyStageRecordID)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OUT_PRODUCT_CAN_FLAGS4>(entity =>
        {
            entity.HasKey(e => e.partNumber).HasName("OUT_PRODUCT_CAN_FLAGS4_PK");

            entity.ToTable("OUT_PRODUCT_CAN_FLAGS4");

            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.applicationCode3Default)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canFlagMasterComments)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canKit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRotate)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("'N'")
                .IsFixedLength();
            entity.Property(e => e.isPartNonCancelableNonReschedule)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartNotRecommendNewDesign)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartPublish)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartRegisterable)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartSoleSource)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("0");
            entity.Property(e => e.publishedLeadTimeInWeeks)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.sampleAutoApprQtyThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprTotalValThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.tacticalMarketingMgr)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime)
                .ValueGeneratedOnAdd()
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<OUT_PRODUCT_LINE>(entity =>
        {
            entity.HasKey(e => new { e.productHierarchy1, e.productHierarchy2, e.productHierarchy3 }).HasName("OUT_PRODUCT_LINE_PK");

            entity.ToTable("OUT_PRODUCT_LINE");

            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.productLine)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
        });

        modelBuilder.Entity<OUT_PRODUCT_TYPE>(entity =>
        {
            entity.HasKey(e => new { e.productHierarchy1, e.productHierarchy2, e.productHierarchy3 }).HasName("OUT_PRODUCT_TYPE_PK");

            entity.ToTable("OUT_PRODUCT_TYPE");

            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'0' ");
            entity.Property(e => e.productType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("SYSTIMESTAMP AT TIME ZONE 'UTC'")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ");
        });

        modelBuilder.Entity<CFG_PRODUCT_CANFLAG>(entity =>
        {
            entity.HasKey(e => e.flag).HasName("CFG_PRODUCT_CANFLAG_PK");
            entity.ToTable("CFG_PRODUCT_CANFLAG");
            entity.Property(e => e.flag)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.b1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.highPriority)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.p1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.p2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.p3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.p4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.p5)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.p6)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.p7)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
        });;

        modelBuilder.Entity<RAW_CFG_PRODUCT_CANFLAG_PATTERN>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RAW_CFG_PRODUCT_CANFLAG_PATTERN");
            entity.Property(e => e.applicationCode3Default)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canFlagMasterComments)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canKit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRotate)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createdBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.createdDate)
                .HasDefaultValueSql("SYSTIMESTAMP")
                .HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N' ")
                .IsFixedLength();
            entity.Property(e => e.errorMessage).IsUnicode(false);
            entity.Property(e => e.haveDifference).HasPrecision(1);
            entity.Property(e => e.haveError).HasPrecision(1);
            entity.Property(e => e.insertOrUpdate)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.isPartNonCancelableNonReschedule)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartNotRecommendNewDesign)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartPublish)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartRegisterable)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartSoleSource)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.pattern)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.plmStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy5)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.publishedLeadTimeInWeeks)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.remark)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprQtyThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprTotalValThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.tacticalMarketingMgr)
                .HasMaxLength(100)
                .IsUnicode(false);
        });;;;

        modelBuilder.Entity<V_CFG_PRODUCT_CANFLAG_PATTERN>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PRODUCT_CANFLAG_PATTERN");
            entity.Property(e => e.applicationCode3Default)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canFlagMasterComments)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canKit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRotate)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.createdBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.isPartNonCancelableNonReschedule)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartNotRecommendNewDesign)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartPublish)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartRegisterable)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartSoleSource)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.marketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.modifiedBy)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.pattern)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.phDescription1)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.phDescription2)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.phDescription3)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.phDescription4)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.phDescription5)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.plmStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy5)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.publishedLeadTimeInWeeks)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.remark)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprQtyThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprTotalValThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.tacticalMarketingMgr)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
        });;;;;

        modelBuilder.Entity<V_CFG_PRODUCT_CANFLAG_PATTERN_HI>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CFG_PRODUCT_CANFLAG_PATTERN_HIS");
            entity.Property(e => e.CFG_PRODUCT_CANFLAG_PATTERN_HIS_DATE).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.CFG_PRODUCT_CANFLAG_PATTERN_HIS_DELEGATE)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CFG_PRODUCT_CANFLAG_PATTERN_HIS_ID)
                .HasColumnType("NUMBER");
            entity.Property(e => e.CFG_PRODUCT_CANFLAG_PATTERN_HIS_USERID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.applicationCode3Default)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canFlagMasterComments)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canKit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRotate)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.isPartNonCancelableNonReschedule)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartNotRecommendNewDesign)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartPublish)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartRegisterable)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartSoleSource)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.lastUpdateBy)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.marketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.pattern)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.phDescription1)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.phDescription2)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.phDescription3)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.phDescription4)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.phDescription5)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.plmStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy5)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.publishedLeadTimeInWeeks)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.recordKey).HasColumnType("NUMBER");
            entity.Property(e => e.remark)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprQtyThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprTotalValThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.tacticalMarketingMgr)
                .HasMaxLength(100)
                .IsUnicode(false);
        });;;;;

        modelBuilder.Entity<V_DASHBOARD_STATS_V2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_DASHBOARD_STATS_V2");
            entity.Property(e => e.COUNT).HasColumnType("NUMBER");
            entity.Property(e => e.GROUPING)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.LASTUPDATE).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.OBJECT)
                .HasMaxLength(42)
                .IsUnicode(false);
            entity.Property(e => e.SEQ).HasColumnType("NUMBER");
        });;

        modelBuilder.Entity<V_OUT_PRODUCT_CONSOLIDATE>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OUT_PRODUCT_CONSOLIDATE");
            entity.Property(e => e.MTSPNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.MTSPRevision)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.MTSPdescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.P3ExpirationDate).HasColumnType("DATE");
            entity.Property(e => e.P3QuantityLimit).HasPrecision(15);
            entity.Property(e => e.ResponsibleProductEngineer)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.activeDate).HasPrecision(6);
            entity.Property(e => e.applicationCode3Default)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.assemblyOutPackagingQty).HasPrecision(15);
            entity.Property(e => e.assemblyOutPackagingType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusPL)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoApprThresholdNonFocusSales)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.autoShipping)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.basePartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.baseUnitOfMeasure)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.bomItemText)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.bumpType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.businessDivision)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.businessPlannerCode)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.businessUnit)
                .HasMaxLength(24)
                .IsUnicode(false);
            entity.Property(e => e.buyOffFlag)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.canContract)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canDebit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canFlagMasterComments)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canForecast)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canKit)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOpportunity)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canOrder)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canQuote)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRegister)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canRotate)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSample)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.canSearch)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.carrierTapePocketPitch).HasPrecision(15);
            entity.Property(e => e.carrierTapeWidth).HasPrecision(15);
            entity.Property(e => e.chipVersion)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.classCode)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.classCodeDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.companyCode)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.companyName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.companyOfOrigin)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.createDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.customerPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.deactivateDateP7).HasPrecision(6);
            entity.Property(e => e.defaultSalesOrderCreationPlant)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.deleteDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.deleteFlag)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.diePositionForMultiDie)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.eccn)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.eccn_my)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.expiryDatePrintingFlag).HasPrecision(1);
            entity.Property(e => e.extendedSupportDate).HasColumnType("DATE");
            entity.Property(e => e.fiestaRules)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.finalTerminalFinish)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.finalTerminalFinishDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.finalTestTestProgramRevision)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.foundryPartNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.frequencyOrderIncrement).HasPrecision(15);
            entity.Property(e => e.goldenAll)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.goldenRecord)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.gradeCode)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.gradeCodeDescription)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.grossDiePerWafer).HasPrecision(15);
            entity.Property(e => e.grossWeight).HasColumnType("NUMBER(15,5)");
            entity.Property(e => e.groupStage)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.groupStageName)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.halogenFreePrintingFlag).HasPrecision(1);
            entity.Property(e => e.hasMultipleMPNcomponents)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.htsus)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.htsus_my)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.isPartASIC)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartActive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartAutomotive)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartDolbyCapable)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartITAR)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartMultipleComponent)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartNonCancelableNonReschedule)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartNotRecommendNewDesign)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.isPartPublish)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartRegisterable)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isPartSoleSource)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.isSalesRoot).HasPrecision(1);
            entity.Property(e => e.jedecReferenceID)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.legacyMPN)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.legacyOrganization)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.lotSequenceCode).HasPrecision(15);
            entity.Property(e => e.manufacturerPart)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.manufacturerPartDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketFamily)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketFamilyDetail)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketGroup)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.marketSegment)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.marketingMgr)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.materialGroup)
                .HasMaxLength(9)
                .IsUnicode(false);
            entity.Property(e => e.materialType)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.materialTypeDetail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.matrixWafer)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.maximumLeadtimeByOPN).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.minimumOrderQuantity).HasPrecision(15);
            entity.Property(e => e.moistureExposureTime)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.moistureSensitiveLevel)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.mrpType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.netDieBypass)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.netWeight).HasColumnType("NUMBER(15,5)");
            entity.Property(e => e.numberOfDie).HasPrecision(15);
            entity.Property(e => e.obsoleteDateP6).HasPrecision(6);
            entity.Property(e => e.orderUntilDate).HasColumnType("DATE");
            entity.Property(e => e.originalPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.originalSourceSystem)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.packageBodySize)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageBodyThickness).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packageCategory)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageCodeDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packageGroup)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.packageLayer)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.packageLength).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packagePinCount).HasPrecision(15);
            entity.Property(e => e.packagePitch).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packageType)
                .HasMaxLength(70)
                .IsUnicode(false);
            entity.Property(e => e.packageWidth).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.packagingBox)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.packagingCarrier)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packagingCarrierQuantity).HasPrecision(15);
            entity.Property(e => e.packagingPackage)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.packagingSpec)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.partAxis)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.partDescription)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.partNumberType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.pbFreeIndicator)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowPeakTemperature)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowRebakeCondition)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pcbOnBoardReflowStorageCondition)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.pdnIssueDate).HasColumnType("DATE");
            entity.Property(e => e.pdnLastBuyDate).HasColumnType("DATE");
            entity.Property(e => e.pdnLastShipDate).HasColumnType("DATE");
            entity.Property(e => e.plasticReelSize).HasPrecision(15);
            entity.Property(e => e.plmStatus)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.priority1OPN)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processSpecialTechnology)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.processStatus)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.processTechnology)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.productDiscontinueNotification)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.productGeneralType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy1)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy2)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy3)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy4)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchy5)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productHierarchyCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.productLine)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.productionDateP4).HasPrecision(6);
            entity.Property(e => e.profitCenter)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.publishedLeadTimeInWeeks)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.reachPrintingFlag).HasPrecision(1);
            entity.Property(e => e.recordKey)
                .HasColumnType("NUMBER");
            entity.Property(e => e.reelHubSize).HasPrecision(15);
            entity.Property(e => e.referencePackageType)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.retisSeqNo)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.roHSChinaExemptPrintingFlag).HasPrecision(1);
            entity.Property(e => e.roHSCompliant)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.roHSCompliantChina)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.roHSExemptPrintingFlag).HasPrecision(1);
            entity.Property(e => e.roughWaferProcess)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.salesRootPartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.salesRootPartNumberKey)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprQtyThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sampleAutoApprTotalValThreshold)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.sealDateFlag).HasPrecision(1);
            entity.Property(e => e.sentFromSystem)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.singulationProcess)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.specNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.specNoGreenOrYellow)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.standardPackingQuantity).HasPrecision(15);
            entity.Property(e => e.tacticalMarketingMgr)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.thickness).HasPrecision(15);
            entity.Property(e => e.totalNumberOfAllWires).HasPrecision(15);
            entity.Property(e => e.totalShelfLife).HasPrecision(15);
            entity.Property(e => e.tsFlag).HasPrecision(1);
            entity.Property(e => e.ulRatingsText)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ulRegistrationFlag).HasPrecision(1);
            entity.Property(e => e.unitLoadingOrientationQuadrant).HasPrecision(15);
            entity.Property(e => e.updateDateAndTime).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.updateType)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.waferOrInStockClass)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.waferSize)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.waferTechnology)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.whitePartNumber)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.wireDiameter).HasColumnType("NUMBER(15,2)");
            entity.Property(e => e.wireType)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LOG_PUSH>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("LOG_PUSH");
            entity.Property(e => e.AUDIT_ID)
                .HasColumnType("NUMBER");
            entity.Property(e => e.JSON_DATA).HasColumnType("CLOB");
            entity.Property(e => e.PUSH_BY)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.PUSH_TIME).HasColumnType("TIMESTAMP(6) WITH TIME ZONE");
            entity.Property(e => e.TABLE_KEY).HasColumnType("CLOB");
            entity.Property(e => e.TABLE_NAME)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TOTAL_RECORDS).HasColumnType("NUMBER");
        });

        modelBuilder.HasSequence("LOG_DATA_REQUEST_SEQ");

        modelBuilder.HasSequence("TMP_MOD_PRODUCTION_DEV_SEQ");

        modelBuilder.HasSequence("TMP_MOD_PRODUCTION_SEQ");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}