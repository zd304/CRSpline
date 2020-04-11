# CRSpline

![screenshot](https://github.com/zd304/CRSpline/blob/master/screenshot.png)

## API

### 1. 曲线对象（CRSplinePath.cs）

### 1.1. 根据名称获取曲线对象

```csharp
public static CRSplinePath GetPathByName(string name);
```

| 名称 | 描述 | 类型 |
| :--: | :--: | :--: |
| 返回类型 | 场景里已经存在的CRSplinePath对象 | CRSplinePath |
| 参数name | 要查找的CRSplinePath对象的名称 | string |

### 1.2. 获取曲线方程

```csharp
public CRSpline spline = null;
```

| 名称 | 描述 | 类型 |
| :--: | :--: | :--: |
| 曲线方程 | 公共成员变量 | CRSpline |

## 2. 曲线方程（CRSpline.cs）

### 2.1. 用路线点重置曲线方程

```csharp
public void Reset(params Vector3[] points);
```

| 名称 | 描述 | 类型 |
| :--: | :--: | :--: |
| 参数points | 曲线经过的所有点 | params Vector3[] |

### 2.2. 根据插值系数，在曲线上插值出某一个点的位置

```csharp
public Vector3 Interp(float t);
```

| 名称 | 描述 | 类型 |
| :--: | :--: | :--: |
| 返回类型 | 插值出来的结果位置坐标 | Vector3 |
| 参数 | 插值系数，取值0到1 | float |

### 2.3. 获得曲线长度

```csharp
public float Length { get; set; }
```

| 名称 | 描述 | 类型 |
| :--: | :--: | :--: |
| 曲线长度 | 公共成员属性 | float |