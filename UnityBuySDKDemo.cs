using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shopify.Unity;

public class UnityBuySDKDemo : MonoBehaviour {

  // Use this for initialization
  void Start () {

      // Add your access token and store domain
      string accessToken = "4571c1c03df7d64797cea5a524836005";
      string storeDomain = "http://snugglycuddlycafe.myshopify.com/";

      // Initialize the Unity Buy SDK
      ShopifyBuy.Init(accessToken, storeDomain);
  }
}
