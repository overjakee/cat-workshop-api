# 🖥️ .NET C# Backend - Cat Workshop API

โปรเจกต์นี้เป็น RESTful API ที่พัฒนาด้วย .NET 8 (ตามที่ใช้) สำหรับรองรับระบบ Cat Workshop Web

## 🛠️ การติดตั้งและใช้งาน

### 1. Clone Repository

```bash
git clone https://github.com/overjakee/cat-workshop-api.git
cd cat-workshop-api
```

### 2. แก้ไขค่า `appsettings.json`

ภายในไฟล์ `appsettings.json` ให้คุณแก้ไขค่า `DefaultConnection` และ `Key` เป็นของคุณเอง เช่น:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=CatWorkshopDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Jwt": {
    "Key": "ใส่คีย์ลับของคุณตรงนี้"
  }
}
```

> ⚠️ แนะนำให้ใช้ `.env` หรือ Secret Manager ในการซ่อนค่าใน production

### 3. สร้าง Database และ Migration

```bash
# หากยังไม่มี Migration
dotnet ef migrations add InitialCreate

# จากนั้นอัปเดต Database
dotnet ef database update
```

> 💡 ใช้คำสั่ง `Update-Database` ได้ใน Package Manager Console ของ Visual Studio ด้วย

---

## 🔐 บัญชีผู้ใช้เริ่มต้น (สำหรับทดสอบ)

| Username | Password |
|----------|----------|
| admin    | 123456   |
| admin2   | 123456   |

> 🧪 สามารถใช้บัญชีเหล่านี้ในการทดสอบการ Login ผ่าน API หรือ UI

---

## ▶️ การรันโปรเจกต์

```bash
dotnet run
```

API จะเริ่มต้นที่: `https://localhost:7251/api`

---
