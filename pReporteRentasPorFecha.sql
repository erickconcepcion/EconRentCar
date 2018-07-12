create procedure pReporteRentasPorFechas(@fecha1 datetime = null, @fecha2 datetime = null)
as
select 
ins.Id,
ren.Id Renta,
CONCAT(cli.Nombres, ' ', cli.Apellidos) Cliente,
cli.CedulaCliente Cedula,
CONCAT(cli.Nombres, ' ', cli.Apellidos) Empleado,
veh.Placa,
CONCAT(mar.Nombre, ' ', mod.Nombre) Marca,
veh.NoChasis,
veh.NoMotor,
ren.FechaRenta,
ren.FechaDevolucion,
ins.FechaInspeccion,
ins.GalonesCombustibles,
ins.TieneRayaduras,
ins.CristalRoto,
ins.GomasDaniadas,
ins.TieneGomaRepuesta,
ins.TieneGato,
ins.PasaInspeccion,
ROW_NUMBER() OVER(PARTITION BY ins.RentaId ORDER BY ins.Id ASC) Inspeccion
from Inspeccions ins
	inner join Rentas ren on ins.RentaId = ren.Id
	inner join Vehiculoes veh on ren.VehiculoId = veh.Id
	inner join Modeloes mod on veh.ModeloId = mod.Id
	inner join Marcas mar on mod.MarcaId = mar.Id
	inner join TipoVehiculoes tve on veh.TipoVehiculoId = tve.Id
	inner join Clientes cli on ren.ClienteId = cli.Id
	inner join Empleadoes emp on ren.EmpleadoId = emp.Id
	where ren.FechaRenta 
			between ISNULL(@fecha1, ren.FechaRenta)
			and ISNULL(@fecha2, ren.FechaRenta)