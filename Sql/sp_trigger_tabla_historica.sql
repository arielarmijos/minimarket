
--USE [db_minimarket]
--GO

--/****** Object:  Table [dbo].[tbl_producto]    Script Date: 06/15/2021 10:52:49 ******/
--SET ANSI_NULLS ON
--GO

--SET QUOTED_IDENTIFIER ON
--GO

--SET ANSI_PADDING ON
--GO

--CREATE TABLE [dbo].[tbl_producto_historico](
--	[id] [int]  NOT NULL,
--	[id_categoria] [int] NOT NULL,
--	[id_proveedor] [int] NOT NULL,
--	[id_marca] [int] NOT NULL,
--	[medidas] [nchar](10) NOT NULL,
--	[descripcion] [varchar](100) NOT NULL,
--	[cantidad] [int] NOT NULL,
--	[precio_unitario] [decimal](18, 4) NOT NULL,
-- CONSTRAINT [PK_tbl_producto_his] PRIMARY KEY CLUSTERED 
--(
--	[id] ASC
--)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
--) ON [PRIMARY]

--GO

--SET ANSI_PADDING OFF
--GO

--create trigger trg_productos
--  on tbl_producto
--  after update
--  as
--  begin
--      set nocount on;
--	  declare @id int
--	  select @id = (Select id From Inserted )
--		  insert into tbl_producto_historico (id,id_categoria,id_proveedor,id_marca,medidas,descripcion,cantidad,precio_unitario)
--		  select id,id_categoria,id_proveedor,id_marca,medidas,descripcion,cantidad,precio_unitario from tbl_producto where  id = @id 
--  end
  
  
--exec usp_consulta_Productos @opcion=2,@id=1

 --create procedure usp_consulta_Productos
 -- @opcion int,
 -- @id int=null
  
 --as 
 
 --begin
 
 --     if @opcion = 1 --todos
 --        select p.id, c.categoria,pr.proveedor,
 --        m.marca,p.medidas,p.descripcion,p.cantidad,p.precio_unitario
 --         from tbl_producto p, tbl_categoria c, tbl_proveedor pr, tbl_marca m
 --        where p.id_categoria = c.id
 --        and p.id_proveedor = pr.id
 --        and p.id_marca = m.id
         
  
	--  if (@opcion = 2) --uno en especifico
 --          select p.id, c.categoria,pr.proveedor,
 --        m.marca,p.medidas,p.descripcion,p.cantidad,p.precio_unitario
 --         from tbl_producto p, tbl_categoria c, tbl_proveedor pr, tbl_marca m
 --        where p.id_categoria = c.id
 --        and p.id_proveedor = pr.id
 --        and p.id_marca = m.id
 --        and p.id = @id
  
 --end
 
  

  