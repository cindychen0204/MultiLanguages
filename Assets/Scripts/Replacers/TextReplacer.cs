﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace MultiLanguageTK
{
    public class TextReplacer : TranslationTextBase
    {


        public override void Replace()
        {
            try
            {
                //var text_ = this.GetComponent<Text>().text;
                //var translationResult = _loadable.TranslationResults(ResourceLanguage.ToString(), TargetLanguage.ToString(), text);
                //var translationResult = _loadable.TranslationResults(ResourceLang.En.ToString(), TargetLang.Zhcn.ToString(), "Adjust");
                //text_ = translationResult;
                //Debug.Log(translationResult);
            }

            catch (Exception ex)
            {

                Debug.Log(ex);
            }
        }

    }
}