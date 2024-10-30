using UnityEngine;
using WeChatWASM;

public class InterstitalAd : Details
{
    private WXInterstitialAd _interstitialAd;

    private void Start()
    {
        // 绑定按钮事件
        GameManager.Instance.detailsController.BindExtraButtonAction(0, ShowAd);
        GameManager.Instance.detailsController.BindExtraButtonAction(1, DestroyAd);
    }

    // 创建插屏广告并挂载事件、预加载广告
    protected override void TestAPI(string[] args)
    {
        // 创建插屏广告
        _interstitialAd = WX.CreateInterstitialAd(
            new WXCreateInterstitialAdParam()
            {
                // adUnitId 请填写自己的广告位 ID
                adUnitId = "adunit-xxxxxxxxxxxxxxxx"
            }
        );

        _interstitialAd.OnLoad(
            (res) =>
            {
                WX.ShowModal(
                    new ShowModalOption()
                    {
                        content = "RewardedVideoAd OnLoad Result:" + JsonUtility.ToJson(res)
                    }
                );
            }
        );
        _interstitialAd.OnError(
            (res) =>
            {
                WX.ShowModal(
                    new ShowModalOption()
                    {
                        content = "RewardedVideoAd onError Result:" + JsonUtility.ToJson(res)
                    }
                );
            }
        );
        _interstitialAd.OnClose(() =>
        {
            WX.ShowModal(new ShowModalOption() { content = "RewardedVideoAd onClose" });
        });
        // 预加载广告
        _interstitialAd.Load();

        WX.ShowToast(new ShowToastOption() { title = "已创建并加载广告" });
    }

    // 展示广告
    private void ShowAd()
    {
        _interstitialAd.Show();
        WX.ShowToast(new ShowToastOption() { title = "已展示广告" });
    }

    // 销毁广告
    private void DestroyAd()
    {
        _interstitialAd.Destroy();
        WX.ShowToast(new ShowToastOption() { title = "已销毁广告" });
    }

    private void OnDestroy()
    {
        _interstitialAd.Destroy();
    }
}
