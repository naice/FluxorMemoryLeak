using Fluxor;

namespace FluxorMemoryLeak
{
    public record UpdateAssetState(int Value);

    [FeatureState(MaximumStateChangedNotificationsPerSecond = 1)]
    public record AssetState
    {
        public int State { get; set; } = 0;
    }

    public static class AssetStateReducers
    {
        [ReducerMethod]
        public static AssetState UpdateAssetState(AssetState state, UpdateAssetState action)
        {
            return state with
            {
                State = state.State + 1,
            };
        }
    }
}
