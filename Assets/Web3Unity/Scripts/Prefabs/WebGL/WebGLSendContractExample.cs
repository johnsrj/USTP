using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

#if UNITY_WEBGL
public class WebGLSendContractExample : MonoBehaviour
{
    async public void OnSendContract(int score, string nickname)
    {
        // smart contract method to call
        string method = "addScore";
        // abi in json format
        string abi =
            "[{\"inputs\": [{\"internalType\": \"string\",\"name\": \"user\",\"type\": \"string\"},{\"internalType\": \"uint256\", \"name\": \"score\",\"type\": \"uint256\"}],\"name\": \"addScore\",\"outputs\": [{\"internalType\": \"bool\",\"name\": \"\",\"type\": \"bool\"}],\"stateMutability\": \"nonpayable\",\"type\": \"function\"},{\"inputs\": [],\"stateMutability\": \"nonpayable\",\"type\": \"constructor\"},{\"inputs\": [{\"internalType\": \"uint256\",\"name\": \"\",\"type\": \"uint256\"}],\"name\": \"leaderboard\",\"outputs\": [{\"internalType\": \"string\",\"name\": \"user\",\"type\": \"string\"},{\"internalType\": \"uint256\",\"name\": \"score\",\"type\": \"uint256\"}],\"stateMutability\": \"view\",\"type\": \"function\"}]";
        // address of contract
        string contract = "0xda1E1FfF58C2Ea4d836682ae13B016a71C92b71F";
        // array of arguments for contract
        string args = $"[\"{nickname}\",\"{score}\']";
        // value in wei
        string value = "0";
        // gas limit OPTIONAL
        string gasLimit = "";
        // gas price OPTIONAL
        string gasPrice = "";
        // connects to user's browser wallet (metamask) to update contract state
        try {
            string response = await Web3GL.SendContract(method, abi, contract, args, value, gasLimit, gasPrice);
            Debug.Log(response);
        } catch (Exception e) {
            Debug.LogException(e, this);
        }
    }

    async public Task<Score> OnCallContract(int index)
    {
        string chain = "binance";
        string network = "testnet";
        string method = "leaderboard";
        string abi =
            "[{\"inputs\": [{\"internalType\": \"string\",\"name\": \"user\",\"type\": \"string\"},{\"internalType\": \"uint256\", \"name\": \"score\",\"type\": \"uint256\"}],\"name\": \"addScore\",\"outputs\": [{\"internalType\": \"bool\",\"name\": \"\",\"type\": \"bool\"}],\"stateMutability\": \"nonpayable\",\"type\": \"function\"},{\"inputs\": [],\"stateMutability\": \"nonpayable\",\"type\": \"constructor\"},{\"inputs\": [{\"internalType\": \"uint256\",\"name\": \"\",\"type\": \"uint256\"}],\"name\": \"leaderboard\",\"outputs\": [{\"internalType\": \"string\",\"name\": \"user\",\"type\": \"string\"},{\"internalType\": \"uint256\",\"name\": \"score\",\"type\": \"uint256\"}],\"stateMutability\": \"view\",\"type\": \"function\"}]";

        string args = $"[\"{index}\"]";
        string response =
            await EVM.Call(chain, network, "0xda1E1FfF58C2Ea4d836682ae13B016a71C92b71F", abi, method, args);
        Debug.Log(response);

        MyInfo nameObject = JsonConvert.DeserializeObject<MyInfo>(response);
        Score sc = new Score(nameObject.Score, nameObject.User);
        return sc;
    }
}
#endif

class MyInfo
{
    public string User { get; set; }
    public int Score { get; set; }
}