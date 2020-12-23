# psd2ugui

## PS图层名格式描述
Name[Type(Text, Image ...)][@配置=Value,配置=Value]

## 通用配置

* pivot: left|center|right, top|middle|bottom

例：pivot=lefttop
  
* stretchx
* stretchy
* stretchxy

例：stretchx=1

## 支持类型：
### 带有子节点的图层
* Type=Button
* Type=List(特殊配置scroll=vertical | horizontal)
* Type=Slider(特殊配置scroll=vertical | horizontal)
* Type=Scrollbar(特殊配置scroll=vertical | horizontal)
* Type=Toggle
* Type=空-->GameObject

### 未带有子节点
* 如果是文本类型转换为Unity中的Text（如果需要TextMeshPro再提）
* 其他类型会被转换成带Image的GameObject

## 特殊引用类型
* Type=Prefab 引用到已有的Prefab上

NamePrefab
