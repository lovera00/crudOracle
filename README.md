# crudOracle
API Para realizar abm de personas

#Creacion de tabla en la base de datos
-- Create table
create table PERSONAS
(
  PERS_CODIGO         NUMBER not null,
  PERS_NOMBRE         VARCHAR2(30),
  PERS_APELLIDO       VARCHAR2(30),
  PERS_NRO_DOCUMENTO  VARCHAR2(7),
  PERS_CORREO         VARCHAR2(50),
  PERS_TELEFONO       VARCHAR2(10),
  PERS_FCH_NACIMIENTO DATE
)
tablespace SYSTEM
  pctfree 10
  pctused 40
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
-- Create/Recreate primary, unique and foreign key constraints 
alter table PERSONAS
  add constraint PK_PERSONAS primary key (PERS_CODIGO)
  using index 
  tablespace SYSTEM
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
alter table PERSONAS
  add constraint UK_DOCUMENTO unique (PERS_NRO_DOCUMENTO)
  using index 
  tablespace SYSTEM
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    next 1M
    minextents 1
    maxextents unlimited
  );
