# EMB-ArtToCode (EMBATC)

## EMBATC ver1.0.0
ドット絵をコードに変換するツールです。</br>
Windows上でのみ動きます。(Macの人ごめんなさい)

## インストール
[release](https://github.com/takunology/EMBATC/releases) のほうから "EMBATCSetup.msi" を選択してダウンロードしてください。発行者不明と出ますが許可してあげてください。</br>

あとはインストーラの指示に従ってインストールしてください。</br>

![s](picture/01.png)

## 使い方
インストール先のフォルダに exe ファイルがあるので開いてください。こんな画面が表示されます。</br>

![s](picture/02.png)

### 1. 画像を選ぶ
こんな画面が出てくるので、まずは "画像ファイル読み込み" をクリックします。対応形式は Jpeg, png, bmp の3種類です。128 x 128 以上の画像は読み込めません。
</br>

![s](picture/03.png)

### 2. コード生成
画像を開いたら "コード生成" をクリックし、ステータスが "完了" になるまでしばらく待ってください。ちなみに 128 x 128 ピクセル の画像だと生成までに30秒以上かかります。 

![s](picture/04.png)

### 3. コードを保存
生成されたコードはテキストボックス上でドラッグアンドドロップでコピーもできますが、cコードとして保存もできます。VScodeやSublimeなどのエディタ環境がある人は、保存したほうが見やすくなります。

VScodeで開くとこのようになります。

![s](picture/05.png)

### 4. main.cへの書き換え
生成されたコードをそのまま貼り付ければ、その画像を表示できます。

</br>

------
皆さんも良きMieruEMBライフを。</br>
P.S. 色の調整が完全ではないのでそこは勘弁してください。