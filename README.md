# MultiLanguagesの使用方法 / Introduction


このプロジェクトは4国語の翻訳プラットフォームを提供し（英、日、中国語簡体、中国語繁体）、原則的に[Mixed Reality ToolKit](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet)を使用しています。
もし、インポートの必要性を見つける場合は、Unityに対応したバージョンを[Release Pages](https://github.com/Microsoft/MixedRealityToolkit-Unity/releases) からダウンロードしてください。
<br>

This project provives 4 languages translation platform in Unity. (English,Japanese,Simplfied Chinese,Traditional Chinese) and basically is built on [Mixed Reality ToolKit](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet), please download each Unity package at [Release Pages](https://github.com/Microsoft/MixedRealityToolkit-Unity/releases) if you find it is necessary.

☆using [Unity-QuickSheet](https://github.com/kimsama/Unity-QuickSheet) scripts and pluding to gather GoogleSheet and Excel datum.



# Step1 
言語ソースを決める <br>
Decide your project's language data source　<br>

・GoogleSheet　<br>
・Excel　<br>
・CSV　<br>

# Step2 
(GoogleSheetではない場合は省略/If not using GoogleSheet, please ignore #2)
<br>
まず認証から始めます。[Google Developer Console](https://console.developers.google.com/apis/dashboard?project=test20181110-1541853844271&duration=PT1H)　にアクセスし、新しいプロジェクトを作成し、
Google Drive APIを有効にし、OAuth 2.0 クライアント IDを作成し、認証情報Jsonファイルをダウンロードしてください。この設定は、google sreadsheetを使用するのに必要です。

<br>

Start it with authorization. Access to [Google Developer Console](https://console.developers.google.com/apis/dashboard?project=test20181110-1541853844271&duration=PT1H), then create
a new project, enable the Drive API, create a new client ID of type "service account" and download json file.
See this page for setting up credentials and getting OAuth2 'client_ID' and 'client_secret' those are needed to set up google sreadsheet setting file. *

## スプレッドシートを作成　/　Create a spreadsheet and worksheet
スプレッドシートをご自身のGoogle　Driveに作成してください。
シートの名前は以下のように「Translation」にしてください。
内容は、このテンプレートをコピーし、ご自身のシートにはりつけてください。
https://docs.google.com/spreadsheets/d/1uaXqVP4XUuIsGnzDPZk2q_OvTNz1z6T8ZrzYxTXsMgk/edit?usp=sharing
<br><br>
Create a google spreadsheet on your 'Google Drive' after logging in your 'Google Drive' with your account.
Please name the sheet as "Translation". <br>
Also, pay attention that you have to copy the EXACT sheet from this template.
https://docs.google.com/spreadsheets/d/1uaXqVP4XUuIsGnzDPZk2q_OvTNz1z6T8ZrzYxTXsMgk/edit?usp=sharing
![alt text](https://i.gyazo.com/d76a00b2ed50a9d6c3fa2ff171299f25.png)


# Import UnityPackage from [MultiLanguages Releases](https://github.com/cindychen0204/MultiLanguages/releases)

* インポートの前に　/　Before importing
このパッケージはC#6.0が必要ですので、Edit>Project Settings>Player>Other Settings>Scripting Runtime Version を `Experimental(.NET 4.6 Equivalent) `に設定してください。<br>
Set your UnityProject to C#6.0 with following: Edit>Project Settings>Player>Other Settings>Scripting Runtime Version into `Experimental(.NET 4.6 Equivalent) `
<br>
** もしMixedRealityToolKitを使わない場合は/ If you are not using MixedRealityToolKit
検索機能を使い、Newtonsoft.JsonのInclude PlatformをEditorだけにしてください。
Please set `Newtonsoft.Json` file's `Include Platform` settings into `Editor` only and apply it.
<br>

もし、先ほどのGoogleアカウントの設定に無事に成功すれば、 'Assets/MultiLanguagePlatform/QuickSheet/GDataPlugin/Editor' フォルダの下に'GoogleDataSettings.asset' の設定を行います。
まず、ダウンロードしたJSONファイルをプロジェクトにインポートし、GoogleDataSettings.assetの`I have OAuth2 JSON file`にチェックを入れて、Jsonファイルにパスを設定してください。
Client ID　と　Client Secretが自動判別されることを確認した後、'Start Authentication'を押し、認証を完成させてください。（GIFに参照することも可能）
<br><br>
If you successfully get the json private key then select 'GoogleDataSettings.asset' file which can be found under 'Assets/MultiLanguagePlatform/QuickSheet/GDataPlugin/Editor' folder <br>
First, set the downloaded json private key to the 'JSON File'.  <br>
Add Check `I have OAuth2 JSON file` as true, then direct the json file. <br>
2. Now, you can see 'Client ID' and 'Client Secret' will be automatically sepcified <br>
3. Click 'Start Authentication' button. It will launch your browser with the following image: <br>

Or you could reference in this GIF:
![](https://i.gyazo.com/24a0d910bf760cc88be11f83ceccea22.gif?_ga=2.165977085.271426080.1545019028-698536499.1488878597)

そして、 `Update`を押してデータを取得する。<br>
ここからGoogleSpreadSheetの開発は可能となります。 <br>
Now, press `Update` buttom on `MultiLanguagePlatform\TranslationSettings\GoogleSheet\Import Setting.asset` to get the data. <br>
Whole data could be seen at Translation.asset in GoogleSheet folder. <br>


# Step 3
パッケージをインポートした時点でもう開発は可能となります。データを更新する場合。（CSVの場合は不要） <br>
EXCEL:  MultiLanguagePlatform\TranslationSettings\Excel\TranslateExcelImporter.assetの <br>
`Update`を押してください。<br>
`Reimport`はデータの構造もリセットされてしまうので押さないでください。 <br>

It is possible to develop once you import this Unity package.
However, if you want to update your data (CSV is not nessesary)
go MultiLanguagePlatform\TranslationSettings\Excel\TranslateExcelImporter.asset
and press `Update` buttom to make an update.
Do not press `Reimport` because it will destroy the whole data structure.


Wish you have a happy development.

*Reference from [Unity-QuickSheet](https://github.com/kimsama/Unity-QuickSheet)
