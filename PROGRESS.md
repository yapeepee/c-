# 學習進度追蹤

## 📅 進度總覽

| 階段 | 狀態 | 開始日期 | 完成日期 | 備註 |
|------|------|----------|----------|------|
| 第一階段：環境設置與基礎 | 🟡 進行中 | 2025-07-07 | - | |
| 第二階段：後端開發 | ⚪ 未開始 | - | - | |
| 第三階段：前端開發 | ⚪ 未開始 | - | - | |
| 第四階段：整合與優化 | ⚪ 未開始 | - | - | |
| 第五階段：部署與 DevOps | ⚪ 未開始 | - | - | |

---

## 📝 詳細進度記錄

### 2025-07-07 - 計畫開始
**今日完成：**
- ✅ 建立學習計畫檔案結構
- ✅ 制定完整學習路線圖
- ✅ 設計進度追蹤系統
- ✅ 建立 EDUCATE 資料夾
- ✅ 建立 MyFirstAPI 專案
- ✅ 決定採用正規開發流程

**學習重點：**
- 了解全端開發的技術堆疊
- 規劃專案架構
- 設定學習目標
- 學習正確的開發流程：Model → DbContext → Repository → Service → Controller

**當前專案架構：**
```
/home/dialunds/EDUCATE/MyFirstAPI/
├── MyFirstAPI.csproj
├── Program.cs
├── Controllers/
│   └── HelloController.cs (已建立但未完成)
├── appsettings.json
└── Properties/
```

**下一步：**
- [ ] 建立 Models 資料夾和第一個 Model
- [ ] 安裝 Entity Framework Core
- [ ] 建立 DbContext
- [ ] 設定資料庫連線

---

## 🎯 當前任務

### 已完成
1. ✅ **環境設置**
   - ✅ 安裝 .NET 8 SDK
   - ✅ 設置 VS Code
2. ✅ **後端 API 開發**
   - ✅ 建立 ASP.NET Core Web API 專案
   - ✅ 實作 Product Model
   - ✅ 設定 Entity Framework Core + SQLite
   - ✅ 實作 Repository Pattern
   - ✅ 實作 Service Layer
   - ✅ 實作 Controller (完整 CRUD)
   - ✅ 測試所有 API 端點

### 正在進行
- 學習進階 API 功能（驗證、DTO、錯誤處理）

### 待辦事項
1. 實作全域錯誤處理中介軟體
2. 加入 Data Annotations 驗證
3. 學習 DTO 模式
4. 實作使用者認證 (JWT)
5. 建立前端 React TypeScript 專案
6. 整合前後端
7. 配置 Docker

---

## 💡 學習筆記

### 重要概念
- **JWT (JSON Web Token)**: 用於安全傳輸資訊的開放標準
- **Entity Framework Core**: .NET 的現代物件資料庫映射器
- **Docker**: 容器化平台，確保開發環境一致性
- **TypeScript**: JavaScript 的超集，提供靜態型別

### 常用指令
```bash
# 前端
npm create vite@latest frontend -- --template react-ts
npm install axios react-router-dom

# 後端
dotnet new webapi -n Backend
dotnet add package Microsoft.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer

# Docker
docker-compose up -d
docker-compose down
```

---

## 🚧 遇到的問題與解決方案

### 問題 1：[待記錄]
**描述：**
**解決方案：**
**學到的教訓：**

---

## 📊 技能評估

| 技能 | 掌握程度 (1-5) | 備註 |
|------|----------------|------|
| TypeScript | ⭐⭐⭐ | 基礎語法已掌握 |
| React | ⭐⭐⭐ | 需加強 Hooks 使用 |
| C# / .NET | ⭐⭐⭐ | 已掌握基礎 Web API 開發 |
| Entity Framework | ⭐⭐⭐ | 能使用 Repository Pattern |
| RESTful API | ⭐⭐⭐⭐ | 理解設計原則與實作 |
| SQL | ⭐⭐⭐ | 基礎查詢已掌握 |
| Docker | ⭐⭐ | 需要更多實踐 |

---

## 🔄 更新記錄
- 2025-07-07: 初始化進度追蹤檔案
- 2025-01-09: 完成Service層實作，開始Controller開發
- 2025-01-10: 完成Controller層實作，成功測試所有API端點

---

### 2025-01-09 - Service層與Controller開發
**今日完成：**
- ✅ 修正所有介面和類別命名（統一使用單數）
- ✅ 完成 IProductService 介面定義
- ✅ 實作 ProductService 類別
  - GetAllAsync()
  - GetByIdAsync(int id)
  - CreateAsync(Product product)
  - UpdateProductAsync(int id, Product product)
  - DeleteProductAsync(int id)
- ✅ 加入完整的資料驗證邏輯
- ✅ 使用適當的例外類型（ArgumentException, KeyNotFoundException, ArgumentOutOfRangeException）
- ✅ 在 Program.cs 註冊 Repository 和 Service
- 🔄 開始建立 ProductController

**學習重點：**
- Service層的角色與責任
- 依賴注入的實作方式
- 例外處理的最佳實踐
- C# 命名慣例（私有欄位使用底線前綴）
- nameof 操作符的使用
- 三層架構的實作

**遇到的問題與解決：**
1. **問題**：介面命名不一致（IProductServices vs IProductService）
   **解決**：統一使用單數形式，符合C#慣例
   
2. **問題**：DeleteAsync 方法參數設計（接收id還是整個物件）
   **解決**：Service層接收id，Repository層接收物件，提高效能和彈性

**下一步：**
- [ ] 完成 ProductController 所有端點
- [ ] 加入錯誤處理中介軟體
- [ ] 測試所有 API 端點
- [ ] 實作資料庫遷移

---

### 2025-01-10 - 完成 Controller 層實作與 API 測試
**今日完成：**
- ✅ 完成 ProductController 基礎結構
  - 繼承 ControllerBase
  - 設定路由 [Route("api/[controller]")]
  - 透過建構子注入 IProductService
- ✅ 實作所有 CRUD 端點
  - GetAll() - GET /api/product
  - GetById(int id) - GET /api/product/{id}
  - Create(Product product) - POST /api/product
  - Update(int id, Product product) - PUT /api/product/{id}
  - Delete(int id) - DELETE /api/product/{id}
- ✅ 正確實作 HTTP 狀態碼
  - 200 OK (成功取得/更新)
  - 201 Created (建立成功，含 Location header)
  - 204 No Content (刪除成功)
  - 400 Bad Request (驗證失敗)
  - 404 Not Found (找不到資源)
- ✅ 修正程式碼錯誤
  - 修正 [HttpPut] 和 [HttpDelete] 屬性大小寫
  - 加入遺漏的 await 關鍵字
  - 修正 Delete 方法的邏輯（檢查 bool 回傳值）
- ✅ 成功測試 API
  - 使用 curl 測試所有端點
  - 確認 API 在 http://localhost:5049 正常運作
  - 成功建立、讀取、更新、刪除產品

**學習重點：**
- Controller 層的責任：處理 HTTP 請求/回應，不包含業務邏輯
- ActionResult<T> vs IActionResult 的使用時機
- RESTful API 設計原則（使用正確的 HTTP 動詞和狀態碼）
- 路由參數 {id} 的使用
- [FromBody] 屬性的作用（在 [ApiController] 中可省略）
- CreatedAtAction 的使用（設定 Location header）
- 非同步程式設計（async/await）的重要性
- 例外處理的分層（Service 層拋出，Controller 層捕捉並轉換）

**遇到的問題與解決：**
1. **問題**：瀏覽器無法連線到 Swagger UI
   **解決**：使用 curl 命令直接測試 API，確認 API 正常運作
   **原因**：可能是 WSL 環境的網路設定問題

2. **問題**：屬性大小寫錯誤 [httpPut] [httpDelete]
   **解決**：改為正確的大小寫 [HttpPut] [HttpDelete]
   
3. **問題**：Delete 方法錯誤使用 deletedProduct 變數
   **解決**：正確使用 bool result 並檢查回傳值

**技能掌握評估：**
- ✅ 理解三層架構（Controller → Service → Repository）
- ✅ 掌握依賴注入概念
- ✅ 理解 RESTful API 設計
- ✅ 能夠除錯並修正程式碼錯誤
- ✅ 理解 HTTP 狀態碼的使用時機

**下一步：**
- [ ] 學習使用 Swagger UI 進行 API 文件化
- [ ] 實作全域錯誤處理中介軟體
- [ ] 加入資料驗證屬性（Data Annotations）
- [ ] 學習 DTO (Data Transfer Object) 模式
- [ ] 實作分頁、排序、篩選功能

---

### 2025-01-10 (續) - Data Annotations 與資料驗證
**今日完成：**
- ✅ 學習 Data Annotations 基本概念
- ✅ 在 Product Model 加入驗證屬性
  - Required（必填）
  - StringLength（字串長度）
  - Range（數值範圍）
  - Display（顯示名稱）
  - DataType（資料類型）
- ✅ 新增 StockQuantity 屬性到 Product Model
- ✅ 建立並執行 Migration (AddStockQuantity)
- ✅ 測試所有驗證規則
- ✅ 理解 ModelState 與 [ApiController] 的自動驗證機制

**學習重點：**
- Data Annotations 提供宣告式驗證
- [ApiController] 自動執行模型驗證
- 新增欄位需要：Model → Migration → 重啟應用程式
- 驗證錯誤自動回傳 400 Bad Request
- Problem Details 標準錯誤格式

**遇到的問題與解決：**
1. **問題**：新增 StockQuantity 後 API 沒有回傳該欄位
   **解決**：需要重新啟動應用程式讓序列化生效
   
2. **問題**：忘記其他層沒有處理新欄位
   **學習**：了解到新增欄位時需要考慮整個資料流程

**目前專案狀態：**
- 完整的 CRUD API with 驗證
- 三層架構：Controller → Service → Repository
- 資料驗證透過 Data Annotations
- 使用 SQLite 資料庫

**接下來的學習計畫：**
1. DTO 模式 - 分離資料傳輸與領域模型
2. JWT 認證 - API 安全性
3. 前端 React + TypeScript
4. 前後端整合