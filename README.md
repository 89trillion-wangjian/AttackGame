## 1. 整体架构：

​		开局通过配置文件中的数据创建自己角色和敌方角色，己方发射弓箭向敌对角色，敌对角色收到攻击扣除Hp，行为分离，通过监听刷新Hp。

## 2. 目录结构：

* Scene
   * MainScene
* Resources
   * FrostArcher.          #模型文件等
   * Image                     #ui文件
   * Json                        #json数据
* Scripts
   * View                     #控制血量刷新等
   * Controller           #控制角色/敌方角色行为
   * Model                 #数据模型
   * TableRead         #读取json
   * Utils                    #工具化

## 3. 代码逻辑分层

| 文件夹    | 主要职责                 |
| --------- | ------------------------ |
| Resources | 存放资源                 |
| Scripts   | 存放脚本文件             |
| Prefabs   | 存放预制体资源           |
| Json      | 存放本地存放的json数据等 |
| Scene     | 存放场景文件             |
| TableRead | 存放解析json的工具       |

## 4.流程图

![draw](https://github.com/89trillion-wangjian/AttackGame/blob/master/README.png)

