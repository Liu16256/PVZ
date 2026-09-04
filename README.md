# PVZ - Plants vs. Zombies

一个使用 Unity 制作的 2D 塔防游戏，植物大战僵尸。

玩家通过收集阳光、选择植物卡牌并进行种植，阻止僵尸进入基地。

这个项目主要用于练习 Unity 2D 游戏开发和 C# 编程，目前已经实现了基本的植物、僵尸、阳光、卡牌、战斗以及游戏流程。

## 游戏玩法

游戏的基本流程：

```text
开始游戏
   ↓
选择植物卡牌
   ↓
消耗阳光种植植物
   ↓
植物攻击僵尸
   ↓
击败所有僵尸 → 胜利
        ↓
   僵尸进入基地 → 失败
```

玩家需要合理使用阳光，并根据僵尸出现的位置选择合适的植物。

### 植物

目前项目中包含：

* Sunflower
* Peashooter

向日葵可以生产阳光，豌豆射手可以发射豌豆攻击僵尸。

植物通过卡牌进行选择，然后放置到对应的种植格中。

### 僵尸

僵尸会从地图一侧出现并向植物所在区域移动。

当僵尸遇到植物后，会停止移动并进行攻击。植物或僵尸的生命值归零后会从游戏中移除。

### 阳光

阳光是种植植物需要消耗的资源。

玩家可以通过向日葵等方式获得阳光，然后使用阳光购买植物。

---

## 项目结构

主要代码位于 `Assets/Scripts/`：

```text
Scripts/
├── Manager/
│   ├── AudioManager.cs
│   ├── Config.cs
│   ├── GameManager.cs
│   ├── HandManager.cs
│   ├── SunManager.cs
│   └── ZombieManager.cs
│
├── UI/
│   ├── CardListUI.cs
│   ├── FailUI.cs
│   ├── PreparedUI.cs
│   └── WinUI.cs
│
├── Card.cs
├── Cell.cs
├── PeaBullet.cs
├── Peashooter.cs
├── Plant.cs
├── Sun.cs
├── Sunflower.cs
├── Zombie.cs
│
├── MenuSceneController.cs
└── StartSceneController.cs
```

### Manager

`Manager` 目录主要放游戏中的管理类。

| 脚本                 | 作用          |
| ------------------ | ----------- |
| `GameManager.cs`   | 管理游戏整体流程和状态 |
| `HandManager.cs`   | 管理玩家手中的植物卡牌 |
| `SunManager.cs`    | 管理阳光相关逻辑    |
| `ZombieManager.cs` | 管理僵尸生成等逻辑   |
| `AudioManager.cs`  | 管理游戏音效      |
| `Config.cs`        | 保存游戏中的相关配置  |

### UI

UI 相关脚本单独放在 `UI` 目录下。

| 脚本              | 作用          |
| --------------- | ----------- |
| `CardListUI.cs` | 植物卡牌列表相关 UI |
| `PreparedUI.cs` | 游戏准备阶段 UI   |
| `WinUI.cs`      | 游戏胜利界面      |
| `FailUI.cs`     | 游戏失败界面      |

### 游戏对象

游戏中的主要实体直接放在 `Scripts` 目录下：

```text
Plant.cs
    ├── Sunflower.cs
    └── Peashooter.cs

PeaBullet.cs
Sun.cs
Zombie.cs
Cell.cs
Card.cs
```

其中：

* `Plant.cs`：植物的基础逻辑
* `Sunflower.cs`：向日葵逻辑
* `Peashooter.cs`：豌豆射手逻辑
* `PeaBullet.cs`：豌豆子弹
* `Zombie.cs`：僵尸逻辑
* `Sun.cs`：阳光对象
* `Cell.cs`：种植区域
* `Card.cs`：植物卡牌

场景控制相关代码：

* `StartSceneController.cs`
* `MenuSceneController.cs`

用于处理开始场景和菜单场景的相关逻辑。

---

## 核心流程

### 植物种植

```text
植物卡牌
   ↓
检查阳光是否足够
   ↓
选择种植位置
   ↓
检查 Cell
   ↓
生成植物
   ↓
扣除阳光
```

### 豌豆射手攻击

```text
Peashooter
    ↓
检测僵尸
    ↓
生成 PeaBullet
    ↓
子弹移动
    ↓
碰撞 Zombie
    ↓
造成伤害
    ↓
Zombie HP <= 0
    ↓
Zombie 死亡
```

### 游戏结束

```text
游戏进行
   ↓
僵尸不断生成
   ↓
植物进行防守
   ↓
判断游戏状态
   ├── 僵尸全部消灭 → Win
   └── 僵尸突破防线 → Fail
```

---

## 🛠️ 开发环境

| 项目   | 内容           |
| ---- | ------------ |
| 游戏引擎 | Unity        |
| 开发语言 | C#           |
| 游戏类型 | 2D 塔防        |
| 平台   | Windows      |
| 版本控制 | Git / GitHub |

## 运行项目

### 克隆项目

```bash
git clone https://github.com/Liu16256/PVZ.git
```

### 使用 Unity Hub 打开

打开 Unity Hub：

```text
Add
→ Add project from disk
→ 选择 PVZ 项目目录
```

使用项目对应的 Unity 版本打开。

### 运行

打开项目中的游戏场景：

```text
Assets/Scenes/
```

选择对应场景后点击 Unity 编辑器顶部的：

```text
▶ Play
```

即可运行。

> 建议使用开发时使用的 Unity 版本打开项目，不同 Unity 版本之间可能存在资源UI位置偏移或项目设置兼容问题。

---

## 游戏截图

后续会补充游戏截图。


## 后续计划

目前项目还会继续完善：

* [ ] 增加更多植物
* [ ] 增加更多僵尸
* [ ] 增加更多关卡
* [ ] 完善僵尸 AI
* [ ] 增加更多植物攻击方式
* [ ] 完善 UI
* [ ] 增加音效和背景音乐
* [ ] 优化游戏表现
* [ ] 增加存档功能

## 项目说明

这是一个个人 Unity 学习项目，主要用于练习 C#、Unity 2D 游戏开发以及 Git/GitHub 的使用。

项目中部分图片、音频以及其他素材来自第三方资源，其版权归原作者或相关版权方所有。
