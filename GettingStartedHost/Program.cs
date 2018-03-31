using PracticeWCF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace GettingStartedHost
{
    //================================================
    //
    //             チュートリアルコード
    //
    //  機能概要：オンライン電卓
    //================================================

    /// <summary>
    /// How to: Host and Run a Basic Windows Communication Foundation Service
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //--------------------------------------------------------
            // Step 1 Create a URI to serve as the base address.  
            // 【ステップ1】
            // サービスのベースアドレスを保持するUriクラスのインスタンスを作成します。 
            // サービスは、ベースアドレスとオプションのURIを含むURLで識別されます。 
            // ベースアドレスは次のようにフォーマットされます：
            // [トランスポート]：// [マシン名またはドメイン] [：オプションのポート番号] / [オプションのURIセグメント]
            //--------------------------------------------------------

            // 電卓サービスのベースアドレスは、HTTPトランスポート、ローカルホスト、 URIセグメント "GettingStarted"
            Uri baseAddress = new Uri("http://localhost:8000/GettingStarted/");

            //--------------------------------------------------------
            // Step 2 Create a ServiceHost instance  
            // 【ステップ2】
            // サービスをホストするServiceHostクラスのインスタンスを作成します。 
            // コンストラクタは、サービスコントラクトを実装するクラスの型とサービスのベースアドレスの2つのパラメータをとります。
            //--------------------------------------------------------
            ServiceHost selfHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            try
            {
                //--------------------------------------------------------
                // Step 3 Add a service endpoint. 
                // 【ステップ3】
                // System.ServiceModel.ServiceEndpointインスタンスを作成します。
                // サービスエンドポイントは、アドレス、バインディング、およびサービスコントラクトで構成されます。
                // したがって、System.ServiceModel.ServiceEndpointコンストラクターは、
                // サービスコントラクトインターフェイスタイプ、バインディング、およびアドレスを取ります。
                // サービスコントラクトはICalculatorで、サービスタイプで定義して実装します。
                // このサンプルで使用されるバインディングは、
                // WS - *仕様に準拠するエンドポイントに接続するために使用されるビルトインバインディングであるWSHttpBindingです。 
                // WCFバインディングの詳細については、「WCFバインディングの概要」を参照してください。
                // アドレスは、エンドポイントを識別するためにベースアドレスに付加されます。
                // このコードで指定されたアドレスは "CalculatorService"なので、エンドポイントの完全修飾アドレスは 
                // "http：// localhost：8000 / GettingStarted / CalculatorService" 
                // .NET Framework 4.0以降を使用する場合、サービスエンドポイントの追加はオプションです。
                // これらのバージョンでは、コードまたは構成にエンドポイントが追加されていない場合、
                // WCFはサービスによって実装されたベースアドレスと契約の組み合わせごとに1つのデフォルトエンドポイントを追加します。
                // デフォルトのエンドポイントの詳細については、「エンドポイントアドレスの指定」を参照してください。
                // 既定のエンドポイント、バインディング、および動作の詳細については、
                // 「WCFサービスの簡略化された構成と簡易化された構成」を参照してください。
                //--------------------------------------------------------
                selfHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "CalculatorService");

                //--------------------------------------------------------
                // Step 4 Enable metadata exchange.  
                // 【ステップ4】
                // メタデータの交換を有効にする。
                // クライアントは、メタデータ交換を使用して、サービス操作を呼び出すために使用されるプロキシを生成します。 
                // メタデータの交換を有効にするには、ServiceMetadataBehaviorインスタンスを作成し、
                // そのHttpGetEnabledプロパティをtrueに設定し、
                // その動作をServiceHostインスタンスのSystem.ServiceModel.ServiceHost.Behaviors％2Aコレクションに追加します。
                //--------------------------------------------------------
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);


                //--------------------------------------------------------
                // Step 5 Start the service.  
                // 【ステップ5】
                // 受信メッセージを受信するためにServiceHostを開きます。 
                // コードは、ユーザーがenterキーを押すのを待ちます。 
                // これをしないと、アプリケーションはすぐに終了し、サービスがシャットダウンされます。
                // また、try / catchブロックが使用されていることに気付きます。 
                // ServiceHostがインスタンス化されると、他のすべてのコードがtry / catchブロックに配置されます。 
                // ServiceHostでスローされた例外を安全にキャッチする方法の詳細については、
                // 「ステートメントの使用に関する問題の回避」を参照してください。
                //--------------------------------------------------------
                selfHost.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.  
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
        }
    }

    /*
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    */
}
