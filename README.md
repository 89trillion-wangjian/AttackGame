## 1. 整体架构：

​		开局通过配置文件中的数据创建自己角色和敌方角色，己方发射弓箭向敌对角色，敌对角色收到攻击扣除Hp，model
保存玩家数据，设置委托类，ui类监听，通过controller控制逻辑。

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
* Res                     #场景模型文件
* Effect                  #模型材质文件

## 3. 代码逻辑分层

|文件夹        |主要职责                  |
|-----------   |----------              |
|Controller     |玩具/敌人逻辑控制                 |
|Entity       |静态类，枚举等              |
|Model       |存放玩家数据，设置委托            |
|Utils          |事件传递脚本  |
|View         |委托事件绑定，处理ui显示，血量刷新              |
|TableRead    | 解析csv文件工具      |

## 4.流程图

![draw](https://github.com/89trillion-wangjian/AttackGame/blob/master/seq.png)

