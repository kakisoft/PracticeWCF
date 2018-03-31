using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PracticeWCF
{
    //================================================
    //
    //             チュートリアルコード
    //
    //  機能概要：オンライン電卓
    //================================================

    /// <summary>
    /// サービスコントラクトの定義
    /// </summary>
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double n1, double n2);
        [OperationContract]
        double Subtract(double n1, double n2);
        [OperationContract]
        double Multiply(double n1, double n2);
        [OperationContract]
        double Divide(double n1, double n2);
    }

    /*
    // メモ: [リファクター] メニューの [名前の変更] コマンドを使用すると、コードと config ファイルの両方で同時にインターフェイス名 "ICalculator" を変更できます。
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: ここにサービス操作を追加します。
    }

    // サービス操作に複合型を追加するには、以下のサンプルに示すようにデータ コントラクトを使用します。
    // プロジェクトに XSD ファイルを追加できます。プロジェクトのビルド後、そこで定義されたデータ型を、名前空間 "PracticeWCF.ContractType" で直接使用できます。
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
    */
}
