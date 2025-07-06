# Inventory Management System (ASP.NET Core MVC)

This is a basic inventory management system built using **ASP.NET Core MVC** and **Entity Framework Core**, with integrated **user registration, login, and role-based management**.

---

## 🚀 Features

- ✅ User Registration & Login
- ✅ Role-based Authorization (Admin/User)
- ✅ User List (Admin only)
- ✅ Admin user configuration page (edit username, password, roles)
- ✅ Inventory/Product management (basic)
- ⏳ AccountService and separation of logic into services
- ⏳ Partial form pages (Edit Username, etc.)

---

## 📁 Project Structure

- `Controllers/` – MVC Controllers (Admin, Account)
- `Views/` – Razor Pages
- `Models/` – ViewModels & Identity Models
- `Services/` – Business logic layer
- `Data/` – EF Core DbContext and seeding logic

---

## 🛠 Tech Stack

- ASP.NET Core MVC
- Entity Framework Core
- Identity (User + Role)
- Razor Pages
- Bootstrap (for layout/styling)
- SQL Server / SQLite

---

## 📸 Screenshots

### Login
| Register/Login | Login Page | Alternative Login |
|----------------|------------|-------------------|
| ![Register Login Page](InventoryApp/assets/screenshots/register-login-page.png) | ![Login Page](InventoryApp/assets/screenshots/login-page.png) | ![Login Page 2](InventoryApp/assets/screenshots/login-page-2.png) |

### Product Management
| Create Page | Edit Page | Admin Product List | User Product List |
|-------------|-----------|-------------------|-------------------|
| ![Create Page](InventoryApp/assets/screenshots/create-page.png) | ![Edit Page](InventoryApp/assets/screenshots/edit-page.png) | ![Admin Product List](InventoryApp/assets/screenshots/admin-product-list.png) | ![User Product List](InventoryApp/assets/screenshots/user-product-list.png) |

### Notification System
| Create Notification | Edit Notification | Delete Notification |
|---------------------|-------------------|---------------------|
| ![Create Notification](InventoryApp/assets/screenshots/create-notification.png) | ![Edit Notification](InventoryApp/assets/screenshots/edit-notification.png) | ![Delete Notification](InventoryApp/assets/screenshots/delete-notification.png) |

### Admin Dashboard
| Admin Dashboard | Admin Home | Admin User List |
|----------------|------------|-----------------|
| ![Admin Dashboard](InventoryApp/assets/screenshots/admin-dashboard.png) | ![Admin Home Page](InventoryApp/assets/screenshots/admin-home-page.png) | ![Admin User List](InventoryApp/assets/screenshots/admin-user-list.png) |


## ⚙️ Getting Started

1. Clone the repo:
   ```bash
   git clone https://github.com/patrick856/Inventory-system.git
   cd Inventory-system

