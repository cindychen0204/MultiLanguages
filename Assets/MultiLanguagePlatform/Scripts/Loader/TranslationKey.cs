namespace MultiLanguageTK
{
    /// <summary>
    /// TranslationKeyといった、三つの要素からできた翻訳キー
    /// </summary>
    public class TranslationKey
    {
        public Languages Resource;
        public Languages Target;
        public string Input;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="resource"></param>　元言語
        /// <param name="target"></param>　ターゲット言語
        /// <param name="input"></param>　翻訳内容
        public TranslationKey(Languages resource, Languages target, string input)
        {
            this.Resource = resource;
            this.Target = target;
            this.Input = input;
        }

        /// <summary>
        /// システムのハッシュコードをOverrideする（しないと、Keyがうまく一致しない）
        /// </summary>
        /// <returns></returns>　
        public override int GetHashCode()
        {
            return Resource.GetHashCode() ^ Target.GetHashCode() ^ Input.GetHashCode();
        }


        /// <summary>
        /// システムの等価メソッドをOverrideする（しないと、Keyがうまく一致しない）
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as TranslationKey;
            if (other == null) return false;
            return this.Resource == other.Resource && this.Target == other.Target && this.Input == other.Input;
        }
    
    }
}