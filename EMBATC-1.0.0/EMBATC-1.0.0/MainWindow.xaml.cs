using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EMBATC_1._0._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Filepath; // 画像ファイルのパス
        int Color_value; // MieruEMB 用に変更した数値データ
        bool openflag = false; // ファイルを開いているかフラグ
        bool saveflag = false; // コードを生成しているかフラグ

        public MainWindow()
        {
            InitializeComponent();
        }


        private void OpenFile_Button(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog(); //ファイルオープンのインスタンス化

            dialog.Filter = "pngファイル (*.png)|*.png|jpegファイル (*.jpg)|*.jpg|bmpファイル (*.bmp)|*.bmp";

            if (dialog.ShowDialog() == true)
            {
                Filepath = (dialog.FileName);
            }
            else
            {
                return;
            }

            content_path.Content = Filepath;
            picture.Source = new BitmapImage(new Uri(Filepath)); //UIに画像を表示
            openflag = true; //ファイル開いたフラグ
        }

        private async void CreateCode_Button(object sender, RoutedEventArgs e)
        {
            if(openflag == false)
            {
                MessageBox.Show("開くファイルを選択してください", "コード生成エラー", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            Bitmap bitmap = new Bitmap(Filepath); //描画用クラスのインスタンス化

            int w = bitmap.Width; //画素の幅
            int h = bitmap.Height; //画素の高さ

            progress.Minimum = 0; //最小値は0
            progress.Maximum = h; //高さの分が最大値

            if(w > 128 || h > 128)
            {
                MessageBox.Show("幅または高さが 128[px] を超えているものは生成できません。", "コード生成エラー", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            status.Content = "ステータス：生成中...";

            Textbox_code.Text = "";

            Textbox_code.Text += "#define P_WIDTH  " + w.ToString() + "\n";
            Textbox_code.Text += "#define P_HEIGHT " + h.ToString() + "\n\n";

            Textbox_code.Text += "const unsigned int pic_data[P_HEIGHT][P_WIDTH] = {\n";

            for (int y = 0; y < h; y++)
            {

                Textbox_code.Text += "\t"; //タブスペース "\t"
                Textbox_code.Text += "{";
                for (int x = 0; x < w; x++)
                {
                    System.Drawing.Color pixel = bitmap.GetPixel(x, y);

                    float H = pixel.GetHue();
                    float S = pixel.GetSaturation(); //0に行くほど白
                    float B = pixel.GetBrightness(); //0にいくほど黒

                    await Task.Run(() => { Color_value = ConvertColor(H, S, B); });

                    //Textbox_code.Text += "[" + H.ToString()+ " " + S.ToString() + " " + B.ToString() + "]"; //数値確認
                    Textbox_code.Text += Color_value.ToString();

                    if (x == w - 1)
                    {
                        Textbox_code.Text += "";
                    }
                    else
                    {
                        Textbox_code.Text += ", ";
                    }
                }

                //Invoke は他のタスクで使用されているコントローラに操作する権利を与える
                //非同期処理で進捗率も示す。
                await Task.Run(() =>
                {
                    Dispatcher.Invoke((Action)(() => 
                    {
                        progress.Value = y + 1;

                    }));
                });

                Textbox_code.Text += "},\n";
            }
            
            Textbox_code.Text += "};\n";
            saveflag = true;
            status.Content = "ステータス：完了";
        }

        //色をMieruEMB用に変換する関数
        int ConvertColor(float H, float S, float B)
        {
            int value = 0;
            //1 -> 赤
            //2 -> 黄緑
            //3 -> 黄色
            //4 -> 青色
            //5 -> 紫色
            //6 -> 水色

            if (B <= 0.4) //明るさが0 -> 黒
            {
                value = 0; //黒
            }
            else if(B <= 0.4 && S <= 0.6)
            {
                value = 0; // 黒
            }
            else if(S < 0.1) //彩度が0 -> 白
            {
                value = 7; //白
            }
            else if(H > 300) //色相環は角度で判定
            {
                value = 1; //赤
            }
            else if(H > 240)
            {
                value = 5; //紫
            }
            else if(H > 192)
            {
                value = 4; //青
            }
            else if(H > 135)
            {
                value = 6; //水色
            }
            else if(H > 56)
            {
                value = 2; //黄緑
            }
            else if(H > 24)
            {
                value = 3; //黄色
            }
            else if(H > 0)
            {
                value = 1; //赤
            }
                return value;
        }

        private void Save_Button(object sender, RoutedEventArgs e)
        {
            if(saveflag == false)
            {
                MessageBox.Show("コードが生成されていません", "保存できません", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var dialog = new SaveFileDialog(); //ファイルセーブのインスタンス化
            dialog.FileName = "code.c";
            dialog.Filter = "cファイル (*.c)|*.c|テキストファイル (*.txt)|*.txt|全てのファイル (*.*)|*.*";
            if (true == dialog.ShowDialog())
            {
                var filename = dialog.FileName;
                // ファイルを開く処理
                File.WriteAllText(dialog.FileName, this.Textbox_code.Text);
            }
            else
            {
                return;
            }
        }
    }
}
