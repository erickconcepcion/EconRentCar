namespace EconRentCar.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false),
                        Apellidos = c.String(nullable: false),
                        CedulaCliente = c.String(nullable: false),
                        NoTArjetaCredito = c.String(nullable: false),
                        LimiteCredito = c.Double(nullable: false),
                        TipoPersona = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rentas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaRenta = c.DateTime(nullable: false),
                        FechaDevolucion = c.DateTime(nullable: false),
                        Comentario = c.String(nullable: false),
                        EstadoRenta = c.Int(nullable: false),
                        VehiculoId = c.Int(nullable: false),
                        EmpleadoId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Empleadoes", t => t.EmpleadoId, cascadeDelete: true)
                .ForeignKey("dbo.Vehiculoes", t => t.VehiculoId, cascadeDelete: true)
                .Index(t => t.VehiculoId)
                .Index(t => t.EmpleadoId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false),
                        Apellidos = c.String(nullable: false),
                        CedulaEmpleado = c.String(nullable: false),
                        TandaLaboral = c.Int(nullable: false),
                        PorcentajeComision = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaIngreso = c.DateTime(nullable: false),
                        Activo = c.Boolean(nullable: false),
                        AppUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.AppUserId, cascadeDelete: true)
                .Index(t => t.AppUserId);
            
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Inspeccions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RentaId = c.Int(nullable: false),
                        TieneRayaduras = c.Boolean(nullable: false),
                        GalonesCombustibles = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TieneGomaRepuesta = c.Boolean(nullable: false),
                        TieneGato = c.Boolean(nullable: false),
                        CristalRoto = c.Boolean(nullable: false),
                        GomasDaniadas = c.Boolean(nullable: false),
                        CargosExtra = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaInspeccion = c.DateTime(nullable: false),
                        PasaInspeccion = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rentas", t => t.RentaId, cascadeDelete: true)
                .Index(t => t.RentaId);
            
            CreateTable(
                "dbo.Vehiculoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Placa = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                        NoChasis = c.String(nullable: false),
                        NoMotor = c.String(nullable: false),
                        EstadoVehiculo = c.Int(nullable: false),
                        ModeloId = c.Int(nullable: false),
                        TipoVehiculoId = c.Int(nullable: false),
                        TipoCombustibleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Modeloes", t => t.ModeloId, cascadeDelete: true)
                .ForeignKey("dbo.TipoCombustibles", t => t.TipoCombustibleId, cascadeDelete: true)
                .ForeignKey("dbo.TipoVehiculoes", t => t.TipoVehiculoId, cascadeDelete: true)
                .Index(t => t.ModeloId)
                .Index(t => t.TipoVehiculoId)
                .Index(t => t.TipoCombustibleId);
            
            CreateTable(
                "dbo.Modeloes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                        MontoPorDia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Activo = c.Boolean(nullable: false),
                        MarcaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marcas", t => t.MarcaId, cascadeDelete: true)
                .Index(t => t.MarcaId);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoCombustibles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoVehiculoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehiculoes", "TipoVehiculoId", "dbo.TipoVehiculoes");
            DropForeignKey("dbo.Vehiculoes", "TipoCombustibleId", "dbo.TipoCombustibles");
            DropForeignKey("dbo.Rentas", "VehiculoId", "dbo.Vehiculoes");
            DropForeignKey("dbo.Vehiculoes", "ModeloId", "dbo.Modeloes");
            DropForeignKey("dbo.Modeloes", "MarcaId", "dbo.Marcas");
            DropForeignKey("dbo.Inspeccions", "RentaId", "dbo.Rentas");
            DropForeignKey("dbo.Rentas", "EmpleadoId", "dbo.Empleadoes");
            DropForeignKey("dbo.Empleadoes", "AppUserId", "dbo.AppUsers");
            DropForeignKey("dbo.Rentas", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Modeloes", new[] { "MarcaId" });
            DropIndex("dbo.Vehiculoes", new[] { "TipoCombustibleId" });
            DropIndex("dbo.Vehiculoes", new[] { "TipoVehiculoId" });
            DropIndex("dbo.Vehiculoes", new[] { "ModeloId" });
            DropIndex("dbo.Inspeccions", new[] { "RentaId" });
            DropIndex("dbo.Empleadoes", new[] { "AppUserId" });
            DropIndex("dbo.Rentas", new[] { "ClienteId" });
            DropIndex("dbo.Rentas", new[] { "EmpleadoId" });
            DropIndex("dbo.Rentas", new[] { "VehiculoId" });
            DropTable("dbo.TipoVehiculoes");
            DropTable("dbo.TipoCombustibles");
            DropTable("dbo.Marcas");
            DropTable("dbo.Modeloes");
            DropTable("dbo.Vehiculoes");
            DropTable("dbo.Inspeccions");
            DropTable("dbo.AppUsers");
            DropTable("dbo.Empleadoes");
            DropTable("dbo.Rentas");
            DropTable("dbo.Clientes");
        }
    }
}
