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

```flow
st=>start: 开始
op=>operation: 加载csv
cond=>condition: 加载成功(是或否?)
sub1=>subroutine: 重复加载
io=>inputoutput: 输入输出框
op1=>operation: 创建角色
op2=>operation: 发射弓箭
cond2=>condition: 击中(是或否?)
op3=>operation: 敌方角色扣血
sub2=>subroutine: 重新发射
cond3=>condition: hp<0?
sub3=>subroutine: 继续
op4=>operation: 死亡
e=>end: 结束
st->op->cond
cond(yes)->op1->op2->cond2
cond(no)->sub1(right)->op
cond2(yes)->op3->cond3
cond2(no)->sub2(right)->op2
cond3(yes)->op4->e
cond3(no)->sub3(right)->op2
```

