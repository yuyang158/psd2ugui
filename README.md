# psd2ugui (整体参考自 [Baum2](https://github.com/kyubuns/Baum2))

## 安装PS插件
将PhotoshopScript\Baum.js 拷贝到PS插件目录（PS安装目录\Presets\Scripts）

## 导出
1. 在PS目录中选择 文件-->脚本-->Baum
2. 在弹出的文件夹选择对话框中选择导出目录
3. 执行导出过程等待complete对话框

## 导入Unity
1. 首先需要在Unity Assets中创建Art/UI/Sprites、Art/UI/Fonts、Art/UI/Prefabs目录
2. 将导出的文件夹放置到Sprites中
3. 将导出的*.layout文件放置到Art/UI/Prefabs中

## PS图层名格式描述
Name[Type(Text, Image ...)][@配置=Value,配置=Value]

### 通用配置

* pivot: left|center|right, top|middle|bottom

例：pivot=lefttop
  
* stretchx
* stretchy
* stretchxy

例：stretchx=1

### 支持类型：
#### 带有子节点的图层
* Type=Button
* Type=List(特殊配置scroll=vertical | horizontal)
* Type=Slider(特殊配置scroll=vertical | horizontal)
* Type=Scrollbar(特殊配置scroll=vertical | horizontal)
* Type=Toggle
* Type=空-->GameObject

#### 未带有子节点
* 如果是文本类型转换为Unity中的Text（如果需要TextMeshPro再提）
* 其他类型会被转换成带Image的GameObject

### 特殊引用类型
* Type=Prefab 引用到已有的Prefab上

例：NamePrefab
