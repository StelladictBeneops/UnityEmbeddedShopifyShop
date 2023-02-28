using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shopify.Unity;

public class UnityBuySDKDemo : MonoBehaviour {

  // Use this for initialization
  void Start () {

      // Add your access token and store domain
      string accessToken = "4571c1c03df7d64797cea5a524836005";
      string storeDomain = "http://snugglycuddlycafe.myshopify.com";
    
      // Initialize the Unity Buy SDK
      ShopifyBuy.Init(accessToken, storeDomain);

      // Retrieve products from your store
      ShopifyBuy.Client().products((products, error) => {

     if (error != null) {
          Debug.Log("Encountered an SDK Error");
          return;
          // it's unlikely but if an invalid GraphQL query was sent a list of errors will be returned
        } 

        Cart cart = ShopifyBuy.Client().Cart();
        List<ProductVariant> firstProductVariants = (List<ProductVariant>) products[0].variants();
        ProductVariant firstProductFirstVariant = firstProductVariants[0];

        // Let's make sure we're grabbing a product
        Debug.Log(firstProductVariant.id());

        // The following example adds a line item using the first product's first variant
        // in this case the cart will have 1 copy of the variant
        cart.LineItems.AddOrUpdate(firstProductFirstVariant, 1);

        // The following line will get a checkout url using the above line items and open the url in browser
        cart.CheckoutWithNativeWebView(
                success: () => {
                    Debug.Log("User finished purchase/checkout!");
                },
                cancelled: () => {
                    Debug.Log("User cancelled out of the web checkout.");
                },
                failure: (e) => {
                    Debug.Log("Something bad happened - Error: " + e);
                }
            );

      });
  }
}
