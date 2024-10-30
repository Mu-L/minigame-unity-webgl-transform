# 推荐引擎版本

## 版本兼容性
 Unity WebGL微信小游戏适配方案是以WebAssembly为基础，具有非常宽泛的兼容性，转换插件理论上支持的Unity版本涵盖：2018、2019、2020、2021、2022等
 
 但并非每个小版本我们都有足够的验证，我们会根据验证情况以及大量转换游戏反馈的情况给出引擎版本建议。

## 推荐版本

| 引擎版本 | 压缩纹理/音频 | 编译体积 | 已验证小版本 | 其他 |
| --- | --- | --- | --- | --- |
| 2018 | 仅DXT,不支持ETC2/ASTC | 100% | 2018.4.25~2018.4.34 | 不支持设置dpr分辨率 |
| 2019 | 仅DXT,不支持ETC2/ASTC | 100% | 2019.4.28~2019.4.35 | --- |
| 2019 InstantGame| 全支持DXT/ETC2/ASTC | 100% | 2019.4.29 | 增加WebGL移动端压缩纹理、AutoStreaming等支持 |
| 2020 | DXT/ETC2,不支持ASTC | 100% | 2020.3.1~2020.3.36 | --- |
| 2021 | 全支持DXT/ETC2/ASTC | 80% | 2021.2.11~2021.3.33 | --- |
| 2021 InstantGame | 全支持DXT/ETC2/ASTC | 80% | 2021.2.5 | 增强运行时性能、UnityProfiler以及更小的包体 |
| 2022(推荐) | 全支持DXT/ETC2/ASTC | 80% | 2022.3.1~2022.3.14| --- | 更稳定的memoryprofiler，支持BRG等新渲染能力 |
| 团结引擎(推荐) | 全支持DXT/ETC2/ASTC | 60~80% | --- | 基于2022.3.2, 但包体、内存更多优化，支持FrameDebugger调试 |


备注:
- Unity引擎在早期版本如5.x已提供WebGL平台导出模式，但我们并不推荐使用早期版本，因为存在较多BUG
- 小游戏平台的压缩纹理支持：PC端DXT，移动端Android ETC2/ASTC, iOS ASTC
- Unity2018~2020在WebGL上没有明显的性能差异，但2018缺少部分功能(如不支持设置WebGL分辨率)，老项目请尽量选择2019以上版本
- Unity2021~2022开始支持更多特性，如更全的压缩纹理、压缩音频、更快的编译速度与更小的体积，强烈建议2022.3
- 引擎(如2018-2020)不支持移动端压缩纹理(ETC2/ASTC)时，请务必使用[压缩纹理优化](CompressedTexture.md)进行优化；
- Unity2022支持新的[memoryprofiler](https://docs.unity3d.com/Packages/com.unity.memoryprofiler@1.0/manual/index.html) Package, 有助于更好地分析WebGL内存使用
- Unity InstantGame版本目前是在2019.4.29/2021.2.5基础上，由Unity中国区特殊优化，提供更强的[Unity Profier内存分析](https://docs.qq.com/doc/DV0hudk5TamlIek1L)、[AutoStreaming](InstantGameGuide.md)等功能，如有条件尽可能使用
- 团结引擎基于2022.3.2，但引擎针对小游戏/WebGL环境有更多的优化，比如内存更低，包体更小，也支持更多的调试工具。可查阅官网了解详细信息


## Unity InstantGame/团结引擎获取

中国特供版[下载地址](https://unity.cn/instantgame/docs/WechatMinigame/InstallUnityWithTuanjieBackport/)


## QA
1. 项目使用2017/Unity5等早期版本，应该使用哪个引擎版本转换？
- 转换工具最低需要引擎版本为2018, 建议直接升级到2022支持压缩纹理、更小的编译体积

2. 项目在使用2018-2020版本，是否可以直接使用？
- 前期建议继续使用当前版本，这些版本需要用微信压缩纹理以优化内存，2018版本不支持修改dpr（修改分辨率）；有人力情况下强烈建议升级2022, 编译速度都更快利于版本迭代，编译体积更小利于启动速度和运行内存

3. Unity InstantGame/团结引擎相对于普通版本有特别之处？
- Unity InstantGame是对特定正式版本的增强，2019 InstantGame增加了压缩纹理、音频支持；2021 InstantGame增强了Unity Profiler内存分析能力，提供AutoStreaming资源自动化处理
- 团结引擎基于2022.3.2，但引擎针对小游戏/WebGL环境有更多的优化，比如内存更低，包体更小，也支持更多的调试工具。可查阅官网了解详细信息

4. 版本是越新越好吗？
- 不是. 虽然适配方案有较为广泛的兼容性，但新版本(特别是小版本)实现变更可能会导致适配问题，所以建议尽量使用表格中有实际游戏验证的版本
