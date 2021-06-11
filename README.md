# FFTCS

[ここ](https://www.youtube.com/watch?v=qB0cffZpw-A)が元ネタの空間周波数ドメイン理解用の教材です。
元ネタは静止画ですが，こっちはWebカメラの画像をキャプチャしてます。昔C++/CLIで作ったもののC++/CLIのWindows formsプロジェクトがディスコン状態なのでC#に移植。

## 導入方法

OpenCvSharpを使ってますが，Cloneした後にVisual StudioでNuget構成を復元するとすぐ使えます。

## 画面構成

![](https://github.com/eiichiromomma/FFTCS/blob/master/FFTCS.gif)

* 左上: カメラ画像
* 左下: カメラ画像の空間周波数パワースペクトル(+1してlog)
* 右下: マウスでドラッグしてフィルタを書く
* 右上: パワースペクトル画像とフィルタのANDの結果を逆フーリエ変換した結果

Clearボタンを押すとフィルタがリセットできる。

## その他

* やっつけで書いたのでコードは汚いです。ガベージコレクションに任せても良いのですが毎フレーム大量にゴミを発生することになるので都度Disposeしてます。
* OpenCVにFFT Shiftが無いので，原画像に-1^(x+y)を乗算してFFTして，パワースペクトルの中心に原画像の直流成分が来るようにしています。なのでIFFTした結果にも同様に-1^(x+y)をして戻す必要があります。
* 思った以上に可変サイズウィンドウは面倒だったのでサイズ固定にしてます。マジックナンバーは使っていないので，ビルド前にデザインでサイズを変えればそのまま動くかと思います。

