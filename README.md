# RabbitTune
## RabbitTuneの概要
RabbitTune は、シンプルな外観を特徴とする、Windows 向けのオーディオプレーヤーです。  
オープンソースで開発されるフリーソフトですので、無料で自由に使用いただけます。  

## RabbitTuneの特徴
 - シンプルな外観
 - 多くのオーディオファイルやプレイリストファイルのフォーマットをサポート 
 - ASIO、WASAPI（共有/排他モード）に対応
 - イコライザ、ピッチシフタ、リサンプラーなどの高度な音響処理機能を、標準で使用可能。
  
## 動作環境
RabbitTune は、以下の要件を満たす環境での使用を想定して開発されています。  
なお、以下に示す要件はあくまでも推奨するものであり、要件を満たさない環境であっても、  
動作する可能性があります。（開発者は動作確認を行っておりません。）一方で、要件を  
十分に満たす環境であっても、オーディオ出力デバイス等との互換性や設定など、一部の環境では、  
正常に動作しない可能性があります。

### OS
 - Windows 8.1
 - Windows 10
 - Windows 11
### .NET Framework
 - .NET Framework 4.8 以降必須。

RabbitTune は、日本語版 Windows 環境での使用を想定しています。また、.NET Core や、  
.NET n(nはバージョン) 等がインストールされていても、.NET Framework 4.8 または  それ以降の  
バージョンがインストールされていない環境では動作しません。

## ライセンス
RabbitTune 本体は、MIT License を採用しています。RabbitTune で使用しているライブラリの  
ライセンスについては、[doc/thirdpartylicenses](https://github.com/koobar/RabbitTune/tree/master/RabbitTune/doc/thirdpartylicenses) フォルダにライブラリごとのライセンスを  
記載したテキストファイルが用意されていますので、そちらをご覧ください。

## 連絡先
RabbitTune に関するお問い合わせやクレーム等は、以下の連絡先で受け付けております。  

 - GitHubページのIssue（推奨）
 - koobar14@gmail.com（非推奨）