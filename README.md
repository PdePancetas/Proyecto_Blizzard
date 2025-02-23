# BlizzardApp

BlizzardApp es una aplicación de escritorio que permite a los usuarios explorar, comprar y gestionar videojuegos en su biblioteca personal. Desarrollada en **C# con Windows Forms** y conectada a **MySQL** como base de datos.

## 🚀 Características

- 📜 **Catálogo de Videojuegos**: Explora una lista de juegos disponibles.
- 🛒 **Carrito de Compras**: Agrega juegos al carrito y cómpralos fácilmente.
- 🎮 **Biblioteca Personal**: Accede a los juegos comprados en una sección separada.
- 👤 **Sistema de Usuarios**: Registro e inicio de sesión.
- 🔧 **Panel de Administración**: Permite gestionar juegos y usuarios (solo para admins).

---

## 📥 Instalación y Configuración

### 🔹 1. Requisitos Previos

- Tener instalado **.NET Framework 4.8 o superior**. [Instala aquí(https://dotnet.microsoft.com/es-es/download)]
- Servidor de bases de datos [**MySQL**(https://dev.mysql.com/downloads/workbench/)].
- **Visual Studio** con soporte para Windows Forms.

### 🔹 2. Clonar el Repositorio

```sh
    git clone https://github.com/PdePancetas/Proyecto_Blizzard.git
    cd Proyecto_Blizzard
```

### 🔹 3. Configurar la Base de Datos

1. **Crear la base de datos en MySQL** ejecutando el script en `database.sql`.
2. **Actualizar la cadena de conexión** en `BlizzardApp\BlizzardApp\Logic\Func.cs -> Conectar_BD()`:

```csharp
    string datos_conexion = "server=localhost;database=catalogovideojogos;user=TU_USUARIO;password=TU_PASSWORD";
```

### 🔹 4. Ejecutar el Proyecto

1. Abrir `BlizzardApp.sln` en **Visual Studio**.
2. Ejecutar la aplicación con `F5`.

---

## 📌 Uso de la Aplicación

### 👤 Para Usuarios Normales
1. **Registrarse o Iniciar Sesión**.
2. Navegar por el **catálogo de juegos**.
3. Agregar juegos a la **cesta** y proceder con la compra.
4. Acceder a los juegos comprados en la **Biblioteca**.

### 🔧 Para Administradores
1. Acceder con una cuenta de **admin**.
2. Administrar videojuegos: **añadir, editar o eliminar** juegos.
3. Gestionar usuarios y pedidos.
4. + Todas las opciones de un Usuario normal

---

## 🛠 Tecnologías Utilizadas

- **Lenguaje**: C# (.NET Framework)
- **Interfaz**: Windows Forms
- **Base de Datos**: MySQL
- **ORM**: MySQL Connector for .NET
- **Gestión de Versiones**: Git y GitHub

---

## 📄 Licencia
Este proyecto es de código abierto y se distribuye bajo la **MIT License**.

📧 Para dudas o mejoras, contáctame en [blancomiguel.bj@gmail.com o [github.com/PdePancetas](https://github.com/PdePancetas/)].

