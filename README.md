# BlizzardApp

BlizzardApp es una aplicación de escritorio que permite a los usuarios explorar, comprar y gestionar videojuegos en su biblioteca personal. Desarrollada en **C# con Windows Forms** y conectada a **MySQL** como base de datos.

## 🚀 Características

- 📜 **Catálogo de Videojuegos**: Explora una lista de juegos disponibles.
- 🛒 **Carrito de Compras**: Agrega juegos al carrito y cómpralos fácilmente.
- 🎮 **Biblioteca Personal**: Accede a los juegos comprados en una sección separada.
- 👤 **Sistema de Usuarios**: Registro e inicio de sesión con autenticación.
- 🔧 **Panel de Administración**: Permite gestionar juegos y usuarios (solo para admins).

---

## 📥 Instalación y Configuración

### 🔹 1. Requisitos Previos

- Tener instalado **.NET Framework 4.8 o superior**.
- Servidor de bases de datos **MySQL**.
- **Visual Studio** con soporte para Windows Forms.

### 🔹 2. Clonar el Repositorio

```sh
    git clone https://github.com/tu-usuario/BlizzardApp.git
    cd BlizzardApp
```

### 🔹 3. Configurar la Base de Datos

1. **Crear la base de datos en MySQL** ejecutando el script en `database.sql`.
2. **Actualizar la cadena de conexión** en `Func.cs`:

```csharp
    private static string connectionString = "server=TU_SERVIDOR;database=TU_BD;user=TU_USUARIO;password=TU_PASSWORD";
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

📧 Para dudas o mejoras, contáctame en [tu email o GitHub].

