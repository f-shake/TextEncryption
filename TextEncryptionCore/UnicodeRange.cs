﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEncryption
{
    public class UnicodeRange
    {
        public readonly static UnicodeRange[] Ranges = new UnicodeRange[]
              {
                 new UnicodeRange { Name = "数字", EnglishName = "Digit", Start = 0x0030, End = 0x0039 },
                 new UnicodeRange { Name = "大写字母", EnglishName = "Upper Latin", Start = 0x0041, End = 0x005A },
                 new UnicodeRange { Name = "小字母", EnglishName = "Lower Latin", Start = 0x0061, End = 0x007A },
                //new UnicodeRange { Name = "C0控制符", EnglishName = "C0 Control", Start = 0x0000, End = 0x001F },
                //new UnicodeRange { Name = "基本拉丁文", EnglishName = "Basic Latin", Start = 0x0020, End = 0x007F },
                //new UnicodeRange { Name = "C1控制符", EnglishName = "C1 Control and", Start = 0x0080, End = 0x009F },
                new UnicodeRange { Name = "拉丁文补充-1", EnglishName = "Latin 1 Supplement", Start = 0x00A0, End = 0x00FF },
                new UnicodeRange { Name = "拉丁文扩展-A", EnglishName = "Latin Extended-A", Start = 0x0100, End = 0x017F },
                new UnicodeRange { Name = "拉丁文扩展-B", EnglishName = "Latin Extended-B", Start = 0x0180, End = 0x024F },
                new UnicodeRange { Name = "国际音标扩展", EnglishName = "IPA Extensions", Start = 0x0250, End = 0x02AF },
                new UnicodeRange { Name = "空白修饰字母", EnglishName = "Spacing Modifiers", Start = 0x02B0, End = 0x02FF },
                new UnicodeRange { Name = "结合用读音符号", EnglishName = "Combining Diacritics Marks", Start = 0x0300, End = 0x036F },
                new UnicodeRange { Name = "希腊文及科普特文", EnglishName = "Greek and Coptic", Start = 0x0370, End = 0x03FF },
                new UnicodeRange { Name = "西里尔字母", EnglishName = "Cyrillic", Start = 0x0400, End = 0x04FF },
                new UnicodeRange { Name = "西里尔字母补充", EnglishName = "Cyrillic Supplement", Start = 0x0500, End = 0x052F },
                new UnicodeRange { Name = "亚美尼亚语", EnglishName = "Armenian", Start = 0x0530, End = 0x058F },
                new UnicodeRange { Name = "希伯来文", EnglishName = "Hebrew", Start = 0x0590, End = 0x05FF },
                new UnicodeRange { Name = "阿拉伯文", EnglishName = "Arabic", Start = 0x0600, End = 0x06FF },
                new UnicodeRange { Name = "叙利亚文", EnglishName = "Syriac", Start = 0x0700, End = 0x074F },
                new UnicodeRange { Name = "阿拉伯文补充", EnglishName = "Arabic Supplement", Start = 0x0750, End = 0x077F },
                new UnicodeRange { Name = "马尔代夫语", EnglishName = "Thaana", Start = 0x0780, End = 0x07BF },
                new UnicodeRange { Name = "西非书面语言", EnglishName = "N'Ko", Start = 0x07C0, End = 0x07FF },
                new UnicodeRange { Name = "阿维斯塔语及巴列维语", EnglishName = "Avestan and Pahlavi", Start = 0x0800, End = 0x085F },
                new UnicodeRange { Name = "曼达安语", EnglishName = "Mandaic", Start = 0x0860, End = 0x087F },
                new UnicodeRange { Name = "撒马利亚语", EnglishName = "Samaritan", Start = 0x0880, End = 0x08AF },
                new UnicodeRange { Name = "天城文书", EnglishName = "Devanagari", Start = 0x0900, End = 0x097F },
                new UnicodeRange { Name = "孟加拉语", EnglishName = "Bengali", Start = 0x0980, End = 0x09FF },
                new UnicodeRange { Name = "古木基文", EnglishName = "Gurmukhi", Start = 0x0A00, End = 0x0A7F },
                new UnicodeRange { Name = "古吉拉特文", EnglishName = "Gujarati", Start = 0x0A80, End = 0x0AFF },
                new UnicodeRange { Name = "奥里亚文", EnglishName = "Oriya", Start = 0x0B00, End = 0x0B7F },
                new UnicodeRange { Name = "泰米尔文", EnglishName = "Tamil", Start = 0x0B80, End = 0x0BFF },
                new UnicodeRange { Name = "泰卢固文", EnglishName = "Telugu", Start = 0x0C00, End = 0x0C7F },
                new UnicodeRange { Name = "卡纳达文", EnglishName = "Kannada", Start = 0x0C80, End = 0x0CFF },
                new UnicodeRange { Name = "马拉雅拉姆语", EnglishName = "Malayalam", Start = 0x0D00, End = 0x0D7F },
                new UnicodeRange { Name = "僧伽罗语", EnglishName = "Sinhala", Start = 0x0D80, End = 0x0DFF },
                new UnicodeRange { Name = "泰文", EnglishName = "Thai", Start = 0x0E00, End = 0x0E7F },
                new UnicodeRange { Name = "老挝文", EnglishName = "Lao", Start = 0x0E80, End = 0x0EFF },
                new UnicodeRange { Name = "藏文", EnglishName = "Tibetan", Start = 0x0F00, End = 0x0FFF },
                new UnicodeRange { Name = "缅甸语", EnglishName = "Myanmar", Start = 0x1000, End = 0x109F },
                new UnicodeRange { Name = "格鲁吉亚语", EnglishName = "Georgian", Start = 0x10A0, End = 0x10FF },
                new UnicodeRange { Name = "朝鲜文字母", EnglishName = "Hangul Jamo", Start = 0x1100, End = 0x11FF },
                new UnicodeRange { Name = "埃塞俄比亚语", EnglishName = "Ethiopic", Start = 0x1200, End = 0x137F },
                new UnicodeRange { Name = "埃塞俄比亚语补充", EnglishName = "Ethiopic Supplement", Start = 0x1380, End = 0x139F },
                new UnicodeRange { Name = "切罗基语", EnglishName = "Cherokee", Start = 0x13A0, End = 0x13FF },
                new UnicodeRange { Name = "统一加拿大土著语音节", EnglishName = "Unified Canadian Aboriginal Syllabics", Start = 0x1400, End = 0x167F },
                new UnicodeRange { Name = "欧甘字母", EnglishName = "Ogham", Start = 0x1680, End = 0x169F },
                new UnicodeRange { Name = "如尼文", EnglishName = "Runic", Start = 0x16A0, End = 0x16FF },
                new UnicodeRange { Name = "塔加洛语", EnglishName = "Tagalog", Start = 0x1700, End = 0x171F },
                new UnicodeRange { Name = "哈努诺文", EnglishName = "Hanunóo", Start = 0x1720, End = 0x173F },
                new UnicodeRange { Name = "布锡文", EnglishName = "Buhid", Start = 0x1740, End = 0x175F },
                new UnicodeRange { Name = "塔格巴努亚文", EnglishName = "Tagbanwa", Start = 0x1760, End = 0x177F },
                new UnicodeRange { Name = "高棉语", EnglishName = "Khmer", Start = 0x1780, End = 0x17FF },
                new UnicodeRange { Name = "蒙古文", EnglishName = "Mongolian", Start = 0x1800, End = 0x18AF },
                new UnicodeRange { Name = "鞑靼语", EnglishName = "Cham", Start = 0x18B0, End = 0x18FF },
                new UnicodeRange { Name = "林布文", EnglishName = "Limbu", Start = 0x1900, End = 0x194F },
                new UnicodeRange { Name = "德宏傣语", EnglishName = "Tai Le", Start = 0x1950, End = 0x197F },
                new UnicodeRange { Name = "新傣仂语", EnglishName = "New Tai Lue", Start = 0x1980, End = 0x19DF },
                new UnicodeRange { Name = "高棉语记号", EnglishName = "Khmer Symbols", Start = 0x19E0, End = 0x19FF },
                new UnicodeRange { Name = "布吉文", EnglishName = "Buginese", Start = 0x1A00, End = 0x1A1F },
                new UnicodeRange { Name = "巴塔克文", EnglishName = "Batak", Start = 0x1A20, End = 0x1A5F },
                new UnicodeRange { Name = "兰纳文", EnglishName = "Lanna/Tai Tham", Start = 0x1A80, End = 0x1AEF },
                new UnicodeRange { Name = "巴厘语", EnglishName = "Balinese", Start = 0x1B00, End = 0x1B7F },
                new UnicodeRange { Name = "巽他语", EnglishName = "Sundanese", Start = 0x1B80, End = 0x1BBF },
                new UnicodeRange { Name = "救世苗文", EnglishName = "Pahawh Hmong", Start = 0x1BC0, End = 0x1BFF },
                new UnicodeRange { Name = "雷布查语", EnglishName = "Lepcha", Start = 0x1C00, End = 0x1C4F },
                new UnicodeRange { Name = "奥尔其基语字母", EnglishName = "Ol Chiki", Start = 0x1C50, End = 0x1C7F },
                new UnicodeRange { Name = "曼尼普尔语", EnglishName = "Meithei/Manipuri", Start = 0x1C80, End = 0x1CDF },
                new UnicodeRange { Name = "语音学扩展", EnglishName = "Phonetic Extensions", Start = 0x1D00, End = 0x1D7F },
                new UnicodeRange { Name = "语音学扩展补充", EnglishName = "Phonetic Extensions Supplement", Start = 0x1D80, End = 0x1DBF },
                new UnicodeRange { Name = "结合用读音符号补充", EnglishName = "Combining Diacritics Marks Supplement", Start = 0x1DC0, End = 0x1DFF },
                new UnicodeRange { Name = "拉丁文扩充附加", EnglishName = "Latin Extended Additional", Start = 0x1E00, End = 0x1EFF },
                new UnicodeRange { Name = "希腊语扩充", EnglishName = "Greek Extended", Start = 0x1F00, End = 0x1FFF },
                new UnicodeRange { Name = "常用标点", EnglishName = "General Punctuation", Start = 0x2000, End = 0x206F },
                new UnicodeRange { Name = "上标及下标", EnglishName = "Superscripts and Subscripts", Start = 0x2070, End = 0x209F },
                new UnicodeRange { Name = "货币符号", EnglishName = "Currency Symbols", Start = 0x20A0, End = 0x20CF },
                new UnicodeRange { Name = "组合用记号", EnglishName = "Combining Diacritics Marks for Symbols", Start = 0x20D0, End = 0x20FF },
                new UnicodeRange { Name = "字母式符号", EnglishName = "Letterlike Symbols", Start = 0x2100, End = 0x214F },
                new UnicodeRange { Name = "数字形式", EnglishName = "Number Form", Start = 0x2150, End = 0x218F },
                new UnicodeRange { Name = "箭头", EnglishName = "Arrows", Start = 0x2190, End = 0x21FF },
                new UnicodeRange { Name = "数学运算符", EnglishName = "Mathematical Operator", Start = 0x2200, End = 0x22FF },
                new UnicodeRange { Name = "杂项工业符号", EnglishName = "Miscellaneous Technical", Start = 0x2300, End = 0x23FF },
                //new UnicodeRange { Name = "控制图片", EnglishName = "Control Pictures", Start = 0x2400, End = 0x243F },
                new UnicodeRange { Name = "光学识别符", EnglishName = "Optical Character Recognition", Start = 0x2440, End = 0x245F },
                new UnicodeRange { Name = "封闭式字母数字", EnglishName = "Enclosed Alphanumerics", Start = 0x2460, End = 0x24FF },
                new UnicodeRange { Name = "制表符", EnglishName = "Box Drawing", Start = 0x2500, End = 0x257F },
                new UnicodeRange { Name = "方块元素", EnglishName = "Block Element", Start = 0x2580, End = 0x259F },
                new UnicodeRange { Name = "几何图形", EnglishName = "Geometric Shapes", Start = 0x25A0, End = 0x25FF },
                new UnicodeRange { Name = "杂项符号", EnglishName = "Miscellaneous Symbols", Start = 0x2600, End = 0x26FF },
                new UnicodeRange { Name = "印刷符号", EnglishName = "Dingbats", Start = 0x2700, End = 0x27BF },
                new UnicodeRange { Name = "杂项数学符号-A", EnglishName = "Miscellaneous Mathematical Symbols-A", Start = 0x27C0, End = 0x27EF },
                new UnicodeRange { Name = "追加箭头-A", EnglishName = "Supplemental Arrows-A", Start = 0x27F0, End = 0x27FF },
                new UnicodeRange { Name = "盲文点字模型", EnglishName = "Braille Patterns", Start = 0x2800, End = 0x28FF },
                new UnicodeRange { Name = "追加箭头-B", EnglishName = "Supplemental Arrows-B", Start = 0x2900, End = 0x297F },
                new UnicodeRange { Name = "杂项数学符号-B", EnglishName = "Miscellaneous Mathematical Symbols-B", Start = 0x2980, End = 0x29FF },
                new UnicodeRange { Name = "追加数学运算符", EnglishName = "Supplemental Mathematical Operator", Start = 0x2A00, End = 0x2AFF },
                new UnicodeRange { Name = "杂项符号和箭头", EnglishName = "Miscellaneous Symbols and Arrows", Start = 0x2B00, End = 0x2BFF },
                new UnicodeRange { Name = "格拉哥里字母", EnglishName = "Glagolitic", Start = 0x2C00, End = 0x2C5F },
                new UnicodeRange { Name = "拉丁文扩展-C", EnglishName = "Latin Extended-C", Start = 0x2C60, End = 0x2C7F },
                new UnicodeRange { Name = "古埃及语", EnglishName = "Coptic", Start = 0x2C80, End = 0x2CFF },
                new UnicodeRange { Name = "格鲁吉亚语补充", EnglishName = "Georgian Supplement", Start = 0x2D00, End = 0x2D2F },
                new UnicodeRange { Name = "提非纳文", EnglishName = "Tifinagh", Start = 0x2D30, End = 0x2D7F },
                new UnicodeRange { Name = "埃塞俄比亚语扩展", EnglishName = "Ethiopic Extended", Start = 0x2D80, End = 0x2DDF },
                new UnicodeRange { Name = "追加标点", EnglishName = "Supplemental Punctuation", Start = 0x2E00, End = 0x2E7F },
                new UnicodeRange { Name = "CJK部首补充", EnglishName = "CJK Radicals Supplement", Start = 0x2E80, End = 0x2EFF },
                new UnicodeRange { Name = "康熙字典部首", EnglishName = "Kangxi Radicals", Start = 0x2F00, End = 0x2FDF },
                new UnicodeRange { Name = "表意文字描述符", EnglishName = "Ideographic Description Characters", Start = 0x2FF0, End = 0x2FFF },
                new UnicodeRange { Name = "CJK符号和标点", EnglishName = "CJK Symbols and Punctuation", Start = 0x3000, End = 0x303F },
                new UnicodeRange { Name = "日文平假名", EnglishName = "Hiragana", Start = 0x3040, End = 0x309F },
                new UnicodeRange { Name = "日文片假名", EnglishName = "Katakana", Start = 0x30A0, End = 0x30FF },
                new UnicodeRange { Name = "注音字母", EnglishName = "Bopomofo", Start = 0x3100, End = 0x312F },
                new UnicodeRange { Name = "朝鲜文兼容字母", EnglishName = "Hangul Compatibility Jamo", Start = 0x3130, End = 0x318F },
                new UnicodeRange { Name = "象形字注释标志", EnglishName = "Kanbun", Start = 0x3190, End = 0x319F },
                new UnicodeRange { Name = "注音字母扩展", EnglishName = "Bopomofo Extended", Start = 0x31A0, End = 0x31BF },
                new UnicodeRange { Name = "CJK笔画", EnglishName = "CJK Strokes", Start = 0x31C0, End = 0x31EF },
                new UnicodeRange { Name = "日文片假名语音扩展", EnglishName = "Katakana Phonetic Extensions", Start = 0x31F0, End = 0x31FF },
                new UnicodeRange { Name = "封闭式CJK文字和月份", EnglishName = "Enclosed CJK Letters and Months", Start = 0x3200, End = 0x32FF },
                new UnicodeRange { Name = "CJK兼容", EnglishName = "CJK Compatibility", Start = 0x3300, End = 0x33FF },
                new UnicodeRange { Name = "CJK统一表意符号扩展-A", EnglishName = "CJK Unified Ideographs Extension-A", Start = 0x3400, End = 0x4DBF },
                new UnicodeRange { Name = "易经六十四卦符号", EnglishName = "Yijing Hexagrams Symbols", Start = 0x4DC0, End = 0x4DFF },
                new UnicodeRange { Name = "CJK统一表意符号", EnglishName = "CJK Unified Ideographs", Start = 0x4E00, End = 0x9FFF },
                new UnicodeRange { Name = "彝文音节", EnglishName = "Yi Syllables", Start = 0xA000, End = 0xA48F },
                new UnicodeRange { Name = "彝文字根", EnglishName = "Yi Radicals", Start = 0xA490, End = 0xA4CF },
                new UnicodeRange { Name = "瓦伊语", EnglishName = "Vai", Start = 0xA500, End = 0xA61F },
                new UnicodeRange { Name = "统一加拿大土著语音节补充", EnglishName = "Unified Canadian Aboriginal Syllabics Supplement", Start = 0xA660, End = 0xA6FF },
                new UnicodeRange { Name = "声调修饰字母", EnglishName = "Modifier Tone Letters", Start = 0xA700, End = 0xA71F },
                new UnicodeRange { Name = "拉丁文扩展-D", EnglishName = "Latin Extended-D", Start = 0xA720, End = 0xA7FF },
                new UnicodeRange { Name = "锡尔赫特文字母", EnglishName = "Syloti Nagri", Start = 0xA800, End = 0xA82F },
                new UnicodeRange { Name = "八思巴字", EnglishName = "Phags-pa", Start = 0xA840, End = 0xA87F },
                new UnicodeRange { Name = "索拉什特拉语", EnglishName = "Saurashtra", Start = 0xA880, End = 0xA8DF },
                new UnicodeRange { Name = "爪哇语", EnglishName = "Javanese", Start = 0xA900, End = 0xA97F },
                new UnicodeRange { Name = "查克玛语", EnglishName = "Chakma", Start = 0xA980, End = 0xA9DF },
                new UnicodeRange { Name = "Varang Kshiti", EnglishName = "Varang Kshiti", Start = 0xAA00, End = 0xAA3F },
                new UnicodeRange { Name = "索拉索姆字母", EnglishName = "Sorang Sompeng", Start = 0xAA40, End = 0xAA6F },
                new UnicodeRange { Name = "尼瓦尔语", EnglishName = "Newari", Start = 0xAA80, End = 0xAADF },
                new UnicodeRange { Name = "越南傣语", EnglishName = "Vi?t Thái", Start = 0xAB00, End = 0xAB5F },
                new UnicodeRange { Name = "克耶字母", EnglishName = "Kayah Li", Start = 0xAB80, End = 0xABA0 },
                new UnicodeRange { Name = "朝鲜文音节", EnglishName = "Hangul Syllables", Start = 0xAC00, End = 0xD7AF },
                new UnicodeRange { Name = "High-half zone of UTF-16", EnglishName = "High-half zone of UTF-16", Start = 0xD800, End = 0xDBFF },
                new UnicodeRange { Name = "Low-half zone of UTF-16", EnglishName = "Low-half zone of UTF-16", Start = 0xDC00, End = 0xDFFF },
                new UnicodeRange { Name = "自行使用区域", EnglishName = "Private Use Zone", Start = 0xE000, End = 0xF8FF },
                new UnicodeRange { Name = "CJK兼容象形文字", EnglishName = "CJK Compatibility Ideographs", Start = 0xF900, End = 0xFAFF },
                new UnicodeRange { Name = "字母表达形式", EnglishName = "Alphabetic Presentation Form", Start = 0xFB00, End = 0xFB4F },
                new UnicodeRange { Name = "阿拉伯表达形式A", EnglishName = "Arabic Presentation Form-A", Start = 0xFB50, End = 0xFDFF },
                new UnicodeRange { Name = "变量选择符", EnglishName = "Variation Selector", Start = 0xFE00, End = 0xFE0F },
                new UnicodeRange { Name = "竖排形式", EnglishName = "Vertical Forms", Start = 0xFE10, End = 0xFE1F },
                new UnicodeRange { Name = "组合用半符号", EnglishName = "Combining Half Marks", Start = 0xFE20, End = 0xFE2F },
                new UnicodeRange { Name = "CJK兼容形式", EnglishName = "CJK Compatibility Forms", Start = 0xFE30, End = 0xFE4F },
                new UnicodeRange { Name = "小型变体形式", EnglishName = "Small Form Variants", Start = 0xFE50, End = 0xFE6F },
                new UnicodeRange { Name = "阿拉伯表达形式B", EnglishName = "Arabic Presentation Form-B", Start = 0xFE70, End = 0xFEFF },
                new UnicodeRange { Name = "半型及全型形式", EnglishName = "Halfwidth and Fullwidth Form", Start = 0xFF00, End = 0xFFEF },
                new UnicodeRange { Name = "特殊", EnglishName = "Specials", Start = 0xFFF0, End = 0xFFFF },
                //new UnicodeRange { Name = "第1辅助平面，多文种补充平面", EnglishName = "Supplementary Multilingual Plane, SMP", Start = 0x10000, End = 0x1FFFF },
                //new UnicodeRange { Name = "第2辅助平面，表意文字补充平面", EnglishName = "Supplementary Ideographic Plane, SIP", Start = 0x20000, End = 0x2FFFF },
                //new UnicodeRange { Name = "第3辅助平面，表意文字第三平面", EnglishName = "Tertiary Ideographic Plane, TIP", Start = 0x30000, End = 0x3FFFF },
                //new UnicodeRange { Name = "第4-13辅助平面，尚未使用", EnglishName = "Plane 4-13, Unassigned", Start = 0x40000, End = 0xDFFFF },
                //new UnicodeRange { Name = "第14辅助平面，特别用途补充平面", EnglishName = "Supplementary Special-purpose Plane, SSP", Start = 0xE0000, End = 0xEFFFF },
                //new UnicodeRange { Name = "第15辅助平面，保留作为私人使用区", EnglishName = "Private Use Area, PUA", Start = 0xF0000, End = 0xFFFFF },
                //new UnicodeRange { Name = "第16辅助平面，保留作为私人使用区", EnglishName = "Private Use Area, PUA", Start = 0x100000, End = 0x10FFFF }
              };
        public string Name { get; private set; }
        public string EnglishName { get; private set; }
        public int Start { get; private set; }
        public int End { get; private set; }
    }
}
