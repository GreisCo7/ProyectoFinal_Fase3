# Proyecto Final - Fase 3
# PetLife - Sistema de Gestión de Citas Veterinarias

## Objetivo

Desarrollar un sistema de escritorio para la gestión de citas veterinarias de la veterinaria PetLife, implementando los casos de uso seleccionados durante las fases de análisis, diseño e implementación. La solución integra una interfaz gráfica desarrollada en Windows Forms, una arquitectura por capas, reglas de negocio para la validación de horarios y persistencia de datos mediante MySQL.

## Requisitos Previos

| Tecnología | Versión / Tipo |
| :--- | :--- |
| **Lenguaje** | C# |
| **Entorno de Desarrollo** | Microsoft Visual Studio Community |
| **Interfaz Gráfica** | Windows Forms (Escritorio) |
| **Base de Datos** | MySQL 8.x |
| **Conector de Base de Datos** | MySql.Data |
| **Control de Versiones** | Git & GitHub |

## Estructura del Proyecto

| Carpeta / Archivo | Función |
| :--- | :--- |
| **Datos/** | Conexión a MySQL y repositorios de acceso a datos |
| **Entidades/** | Clases que representan las entidades principales del sistema |
| **Negocio/** | Reglas de negocio, validaciones y controladores |
| **Presentacion/** | Formularios Windows Forms e interfaz gráfica |
| **ScriptsBD/** | Script SQL para la creación y carga inicial de la base de datos |
| **README.md** | Documentación principal del proyecto |

## Arquitectura Implementada

El sistema fue desarrollado siguiendo una arquitectura de capas:

```text
Presentación (Windows Forms)
           |
           v
Lógica de Negocio
           |
           v
Datos (MySQL)
```

Cada capa cumple una función específica dentro del sistema, facilitando la organización del código, el mantenimiento y la comunicación entre los componentes.

## Instalación y Ejecución

### 1. Clonar el repositorio

```bash
git clone https://github.com/USUARIO/PetLife.git
```

### 2. Crear la Base de Datos

Ejecutar el archivo:

```text
ScriptsBD/petlife.sql
```

En MySQL Workbench para crear la base de datos y sus respectivas tablas.

### 3. Crear el usuario de aplicación

Ejecutar las siguientes instrucciones SQL:

```sql
CREATE USER IF NOT EXISTS 'petlife_app'@'localhost'
IDENTIFIED BY 'Petlife123';

GRANT SELECT ON petlife.*
TO 'petlife_app'@'localhost';

GRANT INSERT ON petlife.cita
TO 'petlife_app'@'localhost';

FLUSH PRIVILEGES;
```

### 4. Configurar la conexión

Verificar la cadena de conexión en el archivo:

```text
D_Conexion.cs
```

Ejemplo de configuración:

```csharp
"Server=localhost;"
+ "Database=petlife;"
+ "Uid=petlife_app;"
+ "Pwd=Petlife123;";
```

**Nota:** Los datos de conexión deben coincidir con la configuración de MySQL del equipo donde se ejecute la aplicación. 

### 5. Ejecutar el proyecto

1. Abrir la solución en Visual Studio Community
2. Verificar que los proyectos estén correctamente cargados
3. Compilar la solución
4. Seleccionar el proyecto de Presentación como proyecto de inicio
5. Presionar **F5** o seleccionar **Iniciar**
6. Utilizar la interfaz para consultar disponibilidad y registrar citas.

---

# Resultados

## 1. Consulta de Disponibilidad (CU-04)

**Descripción:** Permite consultar los horarios disponibles para atención veterinaria según la fecha seleccionada y el veterinario elegido.

**Explicación:** El sistema obtiene la información desde la base de datos y muestra los espacios disponibles en un DataGridView. Los resultados incluyen el nombre del veterinario, la especialidad y el horario disponible para la atención.

**Evidencia:**

<img width="735" height="506" alt="image" src="https://github.com/user-attachments/assets/aa851a3c-d78f-4e44-bfe0-7e24e61389ea" />


---

## 2. Solicitud de Cita (CU-05)

**Descripción:** Permite registrar una nueva cita veterinaria seleccionando mascota, horario y motivo de consulta.

**Explicación:** Una vez seleccionado un horario disponible, el usuario registra el motivo de la consulta y confirma la operación. La información es enviada a la capa de negocio para ser validada y posteriormente almacenada en la base de datos.

**Evidencia:**

<img width="763" height="524" alt="image" src="https://github.com/user-attachments/assets/9454d8a5-0b81-4366-a93a-fbd99f674ff0" />


---

## 3. Verificación de Disponibilidad (CU-10)

**Descripción:** Valida que el horario seleccionado continúe disponible antes de registrar la cita.

**Explicación:** Antes de guardar la información, el sistema verifica que no exista una cita previamente registrada para el mismo horario. Esta validación evita conflictos de agenda y previene registros duplicados.

**Evidencia:**

<img width="743" height="511" alt="image" src="https://github.com/user-attachments/assets/6cbb8928-e203-4cb3-ba91-eb6c96aaddd4" />


---

## 4. Registro Exitoso de una Cita

**Descripción:** Confirmación del registro exitoso de una nueva cita veterinaria.

**Explicación:** Una vez superadas todas las validaciones, el sistema registra la cita y muestra un mensaje de confirmación con el identificador generado.

**Evidencia:**

<img width="761" height="532" alt="image" src="https://github.com/user-attachments/assets/40e7467b-a8be-41a4-8b5d-358b065c9658" />


---

## 5. Base de Datos Actualizada

**Descripción:** Verificación de los registros generados desde la aplicación.

**Explicación:** Los datos ingresados desde la interfaz son almacenados en MySQL, manteniendo la integridad de la información mediante restricciones y validaciones implementadas en la base de datos.

**Evidencia:**

<img width="921" height="214" alt="image" src="https://github.com/user-attachments/assets/b0693ead-bfb0-4698-b0f1-79f8b8da2ba4" />


---

## Base de Datos

### Tablas Principales

- Usuario
- Dueño
- Veterinario
- Mascota
- Horario_Atencion
- Cita
- Notificacion
- Recepcionista

### Diagrama Entidad-Relación

**Evidencia:**

<img width="698" height="922" alt="image" src="https://github.com/user-attachments/assets/57197301-3808-4a1c-ba0a-a5c1a0a34477" />



### Script SQL

La creación de la base de datos se encuentra disponible dentro de la carpeta:

```text
ScriptsBD/
```

Incluida en el repositorio del proyecto.

---

## Validaciones y Manejo de Errores

### Campos obligatorios

El sistema valida que los datos esenciales hayan sido seleccionados antes de procesar una cita.

- Selección de dueño
- Selección de mascota
- Selección de horario
- Ingreso del motivo de consulta

### Horarios ocupados

Antes de registrar una cita se verifica nuevamente la disponibilidad del horario seleccionado para evitar conflictos en la agenda veterinaria.

### Mensajes de error

Se implementaron mensajes informativos para situaciones como:

- Seleccione una mascota
- Seleccione un horario disponible
- Seleccione un dueño
- Error al consultar disponibilidad
- Horario no disponible
- Confirmación de cita registrada

---

## Capas en C#

El proyecto fue organizado en cuatro proyectos principales:

### 1. Datos

Contiene la conexión a MySQL y los repositorios encargados de ejecutar consultas, inserciones y validaciones.

### 2. Entidades

Agrupa las clases que representan los objetos principales del sistema.

### 3. Negocio

Implementa la lógica del sistema y coordina la comunicación entre la interfaz y la base de datos.

### 4. Presentación

Contiene la interfaz gráfica desarrollada mediante Windows Forms.

---

## Conexión con la Base de Datos y Repositorios

Se implementó la clase `D_Conexion` para establecer la comunicación con MySQL mediante un usuario específico con permisos limitados. Adicionalmente, se desarrollaron repositorios para gestionar la información de citas, mascotas, veterinarios y horarios.

**Evidencia:**

<img width="409" height="243" alt="image" src="https://github.com/user-attachments/assets/1a8ee47e-1990-4d72-9ed3-ce7fa391fec1" />

<img width="300" height="230" alt="image" src="https://github.com/user-attachments/assets/bd57577e-9684-4607-bbc5-d358a6ff5cc1" />


---

## Fecha de Ejecución

Noviembre de 2026

| Datos del Proyecto | Detalles |
| :--- | :--- |
| **Proyecto** | Veterinaria PetLife |
| **Materia** | Ingeniería de Software II |
| **Fase** | Fase III - Implementación |
| **Tecnología Principal** | C# Windows Forms |
| **Base de Datos** | MySQL |
| **Control de Versiones** | GitHub |
| **Universidad** | Universidad Tecnológica de Panamá |

## Integrantes

| Nombre | Identificación |
| :--- | :--- |
| **Greisy Coronado** | 8-1031-491 |
| **Kevin Esquivel** | 8-1023-1678 |
| **Julián Mosquera** | E-8-222274 |
| **Wilson Wu** | 2-756-299 |
