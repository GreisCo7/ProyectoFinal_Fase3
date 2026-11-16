-- Ejecutar como root/administrador DESPUÉS de importar "Base de datos/Petlife.sql".
-- Crea el usuario que usa Datos/D_Conexion.cs con permisos mínimos.
CREATE USER IF NOT EXISTS 'petlife_app'@'localhost' IDENTIFIED BY 'Petlife123';
GRANT SELECT ON petlife.* TO 'petlife_app'@'localhost';
GRANT INSERT ON petlife.cita TO 'petlife_app'@'localhost';
FLUSH PRIVILEGES;
