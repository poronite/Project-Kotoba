using UnityEngine;

namespace SimpleStateMachine
{
    public class State : MonoBehaviour
    {
        public virtual void EnterState()
        {
            Debug.Log($"Entered {gameObject.name.Replace("State", string.Empty)} State.");
        }

        public virtual State UpdateState()
        {
            Debug.Log($"Inside {gameObject.name.Replace("State", string.Empty)} State...");

            return this;
        }

        public virtual void ExitState()
        {
            Debug.Log($"Exited {gameObject.name.Replace("State", string.Empty)} State.");
        }
    }
}







//Tutorial - How to create a new state (English version):

//1 - Create a new script
//2 - Add a using directive for the SimpleStateMachine namespace at the top of the script
//3 - Make the script inherit from this class
//4 - Override the functions that you need
//5 - Define the behavior of each function
//6 - In the State Machine Game Object create a child and add the new state's script to it
//7 - If new state is the first state to run add the state's game object to StateMachine's startingState reference →
//  → If not you have to write logic in a different state to switch to the new state


//Example of a simple, organized Unity Game Object Hierarchy:

// ➤ "Game Object Name" (Player, Game Manager, etc...) (you can put the State Machine script here)
//  ➤ States (Empty Game Object to group the States)
//   ➤ Idle State
//   ➤ Move State
//   ...



//使い方 - 新しい状態の作り方（日本語版）：

//１ - 新しいスクリプトを作成してください
//２ - スクリプトの先頭に「using SimpleStateMachine;」を追加してください
//３ - スクリプトをこのクラスから引き継がさせてください
//４ - 必要な関数をオーバーライドしてください
//５ - 各関数の内容を書いてください
//６ - 状態機械のゲームオブジェクトに子を作成して、新しい状態のスクリプトを付けてください
//７ - もしこの状態はゲームが起動後に最初に実行状態だったら状態機械のゲームオブジェクトにこの状態を参照してください →
//  → その場合なければ別の状態からこの状態への切り替え処理を書かなければなりません


//シンプルでわかりやすいUnityのゲームオブジェクトのHierarchy：

// ➤ 「ゲームオブジェクトの名前」（Player, Game Managerなど）（状態機械のスクリプトをここに付けてもいいです）
//  ➤ States (各状態はこのゲームオブジェクトの子になります)
//   ➤ Idle State (状態)
//   ➤ Move State (状態)
//   ...
