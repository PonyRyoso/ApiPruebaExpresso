use DB_Inventario;

go 


alter procedure SP_ListarProducto

@bandera int

as 

begin 
	IF  ( @bandera <> 0 ) 
BEGIN
     select p.id_producto,p.id_marca , m.descripcion as Marca,p.id_presentacion , pre.descripcion as Presentacion, p.id_proveedor, pr.descripcion as Proveedor,p.id_zona, z.descripcion as Zona, p.codigo, p.descripcion_producto 
  , p.precio, p.stock, p.iva as IMPUESTO, p.peso from producto p, marca m, zona z, proveedor pr , presentacion pre
  where p.id_marca = m.id_marca and p.id_presentacion = pre.id_presentacion and p.id_proveedor = pr.id_proveedor and p.id_zona = z.id_zona and p.id_producto = @bandera;
END
ELSE
BEGIN
     select p.id_producto,p.id_marca , m.descripcion as Marca, p.id_presentacion , pre.descripcion as Presentacion, p.id_proveedor, pr.descripcion as Proveedor,p.id_zona, z.descripcion as Zona, p.codigo, p.descripcion_producto 
  , p.precio, p.stock, p.iva as IMPUESTO, p.peso from producto p, marca m, zona z, proveedor pr , presentacion pre
  where p.id_marca = m.id_marca and p.id_presentacion = pre.id_presentacion and p.id_proveedor = pr.id_proveedor and p.id_zona = z.id_zona;
END

end 


exec SP_ListarProducto 0



create procedure sp_inserMarca
@marca varchar(100)

as

begin 
insert into marca values (@marca)
end 


create procedure SP_InsProducto 
@id_marca        int,
@id_presentacion int,
@id_proveedor    int,
@id_zona          int,
@codigo           int,
@descripcion_producto varchar(1000),
@precio           float,
@stock             int,
@impuesto          int,
@peso              float
as

begin 
insert into producto values (@id_marca,@id_presentacion,@id_proveedor,@id_zona,@codigo, @descripcion_producto, @precio, @stock, @impuesto, @peso);

select 1 as codigo, 'Insertado Correctamente' as mensaje;

end


create procedure SP_UpdProducto 
@id_producto      int,
@id_marca         int,
@id_presentacion  int,
@id_proveedor     int,
@id_zona          int,
@codigo           int,
@descripcion_producto varchar(1000),
@precio           float,
@stock            int,
@impuesto         int,
@peso             float

as
begin 

	IF EXISTS (select * from producto p where p.id_producto = @id_producto ) 
BEGIN
  update producto set id_marca = @id_marca , id_presentacion = @id_presentacion, 
  id_proveedor = @id_proveedor, id_zona =  @id_zona, 
  codigo = @codigo , descripcion_producto = @descripcion_producto,
  precio = @precio, stock = @stock, iva = @impuesto ,
  peso = @peso where id_producto = @id_producto;

  SELECT 1 as codigo, 'Actualizado Correctamente' as mensaje;
END
ELSE
BEGIN
    SELECT -1 as codigo, 'IdProducto no encontrado' as mensaje;
END

end 



create procedure Sp_DelProducto
@id_producto int

as 

begin 

	IF EXISTS (select * from producto p where p.id_producto = @id_producto ) 
BEGIN
  delete from producto where id_producto = @id_producto;
    SELECT 1 as codigo, 'Eliminado Correctamente' as mensaje;
END
ELSE
BEGIN
    SELECT -1 as codigo, 'IdProducto no encontrado' as mensaje;
END


end 

