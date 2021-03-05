//#############################################################################
// CWSウェブサイト
let projectname = "CWS_website"
let version = "1.0.0"
//#############################################################################

#if INTERACTIVE
#I "C:\\Aqualis\\lib"
#r "genhtml.dll"
#r "System.dll"
#load "backup.fsx"
#endif

let outputdir = @"C:\Users\j-sug\OneDrive\HTML\研究室ホームページ"
let fullversion = preprocess.backup __SOURCE_DIRECTORY__ __SOURCE_FILE__ projectname version

open System
open genhtml
open genhtml.css

type Tag =
  |Member
  |Research1
  |Research2
  |Research3
  |Research4
  |Achieve
  |Link
  
type Screen =
  |Wide
  |Narrow

HTMLDocument.makecss outputdir "style" <| fun doc ->
    //本文のテキスト
    style "body" <| fun () ->
        css.margin.all "0"
        css.font.family "\"源ノ角ゴシック\",\"原ノ味角ゴシック\",\"Noto Sans Japanese\",\"Hiragino Kaku Gothic ProN\", \"ヒラギノ角ゴ ProN W3\", \"Yu Gothic\", YuGothic, \"游ゴシック体\", Meiryo, \"メイリオ\", sans-serif"
        
    //ヘッダ、News、フッタの左右余白設定
    style ".boxA, .box4, .box5" <| fun () ->
        css.padding.left "15px"
        css.padding.right "15px"
    
    //ヘッダの上下余白設定
    style ".boxA" <| fun () ->
        css.padding.top "20px"
        css.padding.bottom "10px"
        
    //ヘッダ以下の回り込み解除
    style ".boxA:after" <| fun () ->
        css.content ""
        css.display.block()
        css.clear.both()
        
    //ヘッダ内のメニュー
    stylegroup ".menu" <| fun () ->
        
        //テキストを右寄せ
        style "" <| fun () ->
            css.text_align.right()
            
        //テキストを右寄せ
        style "a" <| fun () ->
            css.text_decoration.none()
            
        //余白の設定と箇条書きのマークをなしに設定
        style "ul" <| fun () ->
            css.margin.all "0px"
            css.padding.all "0px"
            css.list_style.none()
            
        //項目のスタイル
        style "li a" <| fun () ->
            css.display.block()
            css.padding.vertical_horizontal "10px" "15px"
            css.color "#000000"
            css.font.size "14px"
            css.text_decoration.none()
            
        //マウスポインタがある時に背景色を変更
        style "li a:hover" <| fun () ->
            css.background.color "#eeeeee"
            
        //箇条書き以降のスタイルを戻す
        style "ul:after" <| fun () ->
            css.content ""
            css.display.block()
            css.clear.both()
            
        //箇条書きスタイルを横並びに設定
        style "li" <| fun () ->
            css.float.left()
            css.width "auto"
        
    //研究テーマへのリンク
    stylegroup ".gaiyou" <| fun () ->
        //リンクのスタイル
        style "a" <| fun () ->
            css.display.block()
            css.background.color "#0000ff"
            css.color "#ffffff"
            css.text_align.center()
            css.text_decoration.none()
        //マウスホバー時
        style "a:hover" <| fun () ->
            css.opacity "0.8"
        //タイトル
        style "h1" <| fun () ->
            css.margin.top "0"
            css.margin.bottom "0"
            css.font.size "36px"
            css.height "auto"
            css.vertical_align.bottom()
        //サブタイトル
        style "p" <| fun () ->
            css.margin.top "0"
            css.margin.bottom "0"
            css.padding.top "15px"
            css.padding.bottom "15px"
        
    //お知らせ
    stylegroup ".news" <| fun () ->
        //余白
        style "" <| fun () ->
            css.padding.all "20px"
        
        //見出し
        style "h1" <| fun () ->
            css.margin.top "0"
            css.margin.bottom "5px"
            css.font.size "18px"
            css.color "#666666"
            css.border.left.width "6px"
            css.border.left.color "#0000ff"
            css.border.left.style.solid()
            css.padding.left "7px"
        
        //箇条書きスタイル
        style "ul" <| fun () ->
            css.margin.all "0"
            css.padding.all "0"
            css.list_style.none()
            
        //お知らせコンテンツ
        style "li a" <| fun () ->
            css.display.block()
            css.padding.all "5px"
            css.border.bottom.style.dotted()
            css.border.bottom.width "2px"
            css.border.bottom.color "#dddddd"
            css.color "#000000"
            css.font.size "14px"
            css.text_decoration.none()
            
        //マウスホバー時
        style "li a:hover" <| fun () ->
            css.background.color "#eeeeee"
            
        //日付
        style "time" <| fun () ->
            css.color "#888888"
            css.font.weight.bold()
        
        //配列をクリア
        style "a:after" <| fun () ->
            css.content ""
            css.display.block()
            css.clear.both()
        
        //日付
        style "time" <| fun () ->
            css.float.left()
            css.width "90px"
        
        //テキスト
        style ".text" <| fun () ->
            css.float.none()
            css.width "auto"
            
    //メインコンテンツ
    stylegroup ".kiji" <| fun () ->
        //大見出し
        style "h1" <| fun () ->
            css.margin.top "0"
            css.padding.left "20px"
            css.border.left.style.solid()
            css.border.left.width "20px"
            css.border.left.color "#0000ff"
            css.color "#0000aa"
            css.margin.bottom "20px"
            css.font.size "36px"
            css.font.weight.bold()
            
        //小見出し
        style "h2" <| fun () ->
            css.margin.top "0"
            css.padding.left "10px"
            css.border.left.style.solid()
            css.border.left.width "10px"
            css.border.left.color "#0000ff"
            css.margin.bottom "10px"
            css.font.size "22px"
            css.font.weight.bold()
            
        //論文タイトル見出し
        style "h4" <| fun () ->
            css.margin.top "0"
            css.padding.left "10px"
            css.border.left.style.solid()
            css.border.left.width "5px"
            css.border.left.color "#0000ff"
            css.margin.bottom "10px"
            css.font.size "18px"
            css.color "#0066ff"
            css.font.weight.bold()

        //論文著者
        style ".author" <| fun () ->
            css.margin.top "0"
            css.padding.left "15px"
            css.margin.bottom "10px"
            css.font.size "14px"
            css.color "#626262"
            
        //学術誌名
        style ".article" <| fun () ->
            css.margin.top "0"
            css.padding.left "15px"
            css.margin.bottom "10px"
            css.font.size "14px"
            css.color "#626262"

        //本文
        style "p" <| fun () ->
            css.margin.top "0"
            css.margin.bottom "20px"

        //本文
        style "img" <| fun () ->
            css.width "100%"
            
    //レスポンシブデザイン
    for s in [Narrow;Wide] do
        let head = 
            match s with
              |Narrow ->
                //スクリーン幅959px以下のとき
                "@media (max-width: 959px)"
              |Wide ->
                //スクリーン幅960px以上のとき
                "@media (min-width: 960px)"
        style head <| fun _ ->
            //パンくずメニュー
            stylegroup ".bread" <| fun () ->
                //下余白
                style "" <| fun () ->
                    css.margin.bottom "20px"
        
                //項目の余白
                style "ol" <| fun () ->
                    match s with
                      |Narrow ->
                        css.list_style.none()
                        css.padding.left "0"
                      |Wide ->
                        css.list_style.none()
                        css.margin.all "0"
                        css.padding.all "0"
                        
                //コンテンツ
                style "li a" <| fun () ->
                    css.display.inline_block()
                    css.padding.all "5px"
                    css.color "#000000"
                    css.font.size "14px"
                    css.text_decoration.none()
        
                //マウスホバー時
                style "li a:hover" <| fun () ->
                    css.background.color "#eeeeee"
        
                //配置をクリア
                style "ol:after" <| fun () ->
                    css.content ""
                    css.display.block()
                    css.clear.both()
        
                //箇条書きを横並びに変更
                style "li" <| fun () ->
                    css.float.left()
                    css.width "auto"
        
                //箇条書き項目の後のコンテンツ
                style "li:after" <| fun () ->
                    css.content "\\003e"
                    css.color "#888888"
                    css.margin.left "10px"
                    css.margin.right "10px"

            //左サイドメニュー
            stylegroup ".sidemenu" <| fun () ->
                //サイドメニューの箇条書き
                style "ul" <| fun () ->
                    css.margin.all "0"
                    css.padding.all "0"
                    css.list_style.none()
                        
                //サイドメニューの項目
                match s with
                  |Narrow ->
                    stylegroup "li" <| fun () ->
                    style "" <| fun () ->
                    css.float.left()
                  |Wide -> ()

                //サイドメニューのリンクスタイル
                stylegroup "li a" <| fun () ->
                    style "" <| fun () ->
                        css.display.block()
                        css.padding.all "5px"
                        css.color "#000000"
                        css.font.size "14px"
                        css.text_decoration.none()
                        
                    style ":hover" <| fun () ->
                        css.background.color "#eeeeee"
        
            //トップページのスライドショー
            match s with
              |Narrow ->
                style "#slideshow" <| fun () ->
                css.width "100%"
              |_ -> ()

            //フッタのコピーライト表記
            style ".copyright p" <| fun () ->
                css.margin.all "0"
                css.color "#666666"
                css.font.size "14px"
        
            //フッタ領域
            style ".box5" <| fun () ->
                css.padding.top "15px"
                css.padding.bottom "15px"
                css.background.color "#dddddd"
                
            //お知らせ領域
            style ".box4" <| fun () ->
                css.padding.top "20px"
                css.padding.bottom "20px"
                
            //テーマ一覧領域
            style ".box6 h1" <| fun () ->
                css.font.size "20px"
                
            //ヘッダ内メニュー
            match s with
              |Narrow ->
                style ".menu li a" <| fun () ->
                    css.padding.vertical_horizontal "10px" "7px"
                    css.font.size "14px"
              |_ -> ()

            //テーマ一覧
            match s with
              |Wide ->
                style ".box3, .box4, .boxA-inner, .box5-inner, .box6, .box7" <| fun () ->
                    css.width "960px"
                    css.margin.left "auto"
                    css.margin.right "auto"
                    
                //メニュー領域を右寄せ
                style ".box2" <| fun () ->
                    css.float.right()
                    css.padding.top "94px"
                    css.width "auto"
                    
                //テーマ一覧を横に並べる
                style ".box6:after" <| fun () ->
                    css.content ""
                    css.display.block()
                    css.clear.both()
                    
                style ".box6-1" <| fun () ->
                    css.float.left()
                    css.width "220px"
                    css.margin.left "10px"
                    css.margin.right "10px"
                    
                style ".box6-2" <| fun () ->
                    css.float.left()
                    css.width "220px"
                    css.margin.left "10px"
                    css.margin.right "10px"
                    
                style ".box6-3" <| fun () ->
                    css.float.left()
                    css.width "220px"
                    css.margin.left "10px"
                    css.margin.right "10px"

                style ".box6-4" <| fun () ->
                    css.float.left()
                    css.width "220px"
                    css.margin.left "10px"
                    css.margin.right "10px"
                    
                style ".box7:after" <| fun () ->
                    css.content ""
                    css.display.block()
                    css.clear.both()
              |_ -> ()
            //サイドメニュー右のコンテンツ  
            style ".box7-1" <| fun () ->
                match s with
                  |Narrow ->
                    css.width "100%"
                  |Wide ->
                    css.float.right()
                    css.width "80%"
                    css.padding.left "50px"
                    css._moz_box_sizing.border_box()
                    css._webkit_box_sizing.border_box()
                    css.box_sizing.border_box()
            
            //サイドメニュー右のコンテンツ画像  
            style ".box7-1 img" <| fun () ->
                css.width "100%"
                
            //サイドメニュー  
            style ".box7-2" <| fun () ->
                match s with
                  |Narrow ->
                    css.width "100%"
                    css.height "30px"
                    css.padding.left "15px"
                    css.background.color "#7fbfff"
                    css.color "#FFFFFF"
                  |Wide ->
                    css.float.left()
                    css.width "20%"
                    
            //メインコンテンツ内の2段組外枠
            style ".box8" <| fun () ->
                css.padding.left("15px")
                css.padding.bottom("20px")

            match s with
              |Wide ->
                style ".box8:after" <| fun () ->
                    css.content ""
                    css.display.block()
                    css.clear.both()
              |_ -> ()
              
            //2段組（左段）のコンテンツ
            style ".box8-A" <| fun () ->
                match s with
                  |Wide ->
                    css.float.left()
                    css.width((int(float(960-15)*0.4)).ToString()+"px")
                  |Narrow ->
                    ()
                
            //2段組（左段）のコンテンツ
            style ".box8-B" <| fun () ->
                match s with
                  |Wide ->
                    css.float.left()
                    css.width((int(float(960-15)*0.6)-10).ToString()+"px")
                    css.padding.left("10px")
                  |Narrow ->
                    ()
                
    //お知らせタグ：メンバ  
    style ".tag_member" <| fun () ->
        css.display.inline_block()
        css.color "#000000"
        css.font.weight.bold()
        
    //お知らせタグ：研究  
    style ".tag_research1" <| fun () ->
        css.display.inline_block()
        css.color "#FF0000"
        css.font.weight.bold()
    style ".tag_research2" <| fun () ->
        css.display.inline_block()
        css.color "#FFAA00"
        css.font.weight.bold()
    style ".tag_research3" <| fun () ->
        css.display.inline_block()
        css.color "#00AA00"
        css.font.weight.bold()
    style ".tag_research4" <| fun () ->
        css.display.inline_block()
        css.color "#0000FF"
        css.font.weight.bold()
        
    //お知らせタグ：業績  
    style ".tag_achieve" <| fun () ->
        css.display.inline_block()
        css.color "#000000"
        css.font.weight.bold()
        
    //お知らせタグ：リンク  
    style ".tag_link" <| fun () ->
        css.display.inline_block()
        css.color "#000000"
        css.font.weight.bold()
        
let LL g a b = match g with |J -> a |E -> b

let pageheader g pagename (doc:HTMLDocument) =
    doc.div "boxA" <| fun () ->
        doc.div "boxA-inner" <| fun () ->
            
            doc.image "cws_logo.png"
                            
            doc.div "box2" <| fun () ->
                doc.div "menu" <| fun () ->
                    doc.page_ref (pagename+".html") <| fun () ->
                        doc.s "Japanese"
                    doc.s "|"
                    doc.page_ref (pagename+"_en.html") <| fun () ->
                        doc.s "English"
                    doc.ul [
                        fun () ->
                            doc.page_ref <| LL g "index.html" "index_en.html" <| fun () ->
                                doc.s <| LL g "トップ" "Top"
                        fun () ->
                            doc.page_ref <| LL g "mem.html" "mem_en.html" <| fun () ->
                                doc.s <| LL g "メンバー" "Members"
                        fun () ->
                            doc.page_ref <| LL g "res.html" "res_en.html" <| fun () ->
                                doc.s <| LL g "研究内容" "Research Contents"
                        fun () ->
                            doc.page_ref <| LL g "ach.html" "ach_en.html" <| fun () ->
                                doc.s <| LL g "研究業績" "Research Achievements"
                        //fun () ->
                        //    doc.page_ref <| LL g "lin.html" "lin_en.html" <| fun () ->
                        //        doc.s <| LL g "リンク" "Links"
                           ]
                            
let resAi g = LL g "res_ai" "res_ai_en"
let resHo g = LL g "res_ho" "res_ho_en"
let resIs g = LL g "res_is" "res_is_en"
let resSc g = LL g "res_sc" "res_sc_en"

//ページのフォーマット
let page g filename pagename code =
    HTMLDocument.makehtml outputdir (filename+(LL g "" "_en")) pagename ["style"] [] [] <| fun doc ->
        
        pageheader g filename doc
        
        doc.div "box7" <| fun () ->
            code(doc)
                        
        doc.div "box5" <| fun () ->
            doc.div "box5-inner" <| fun () ->
                doc.div "copyright" <| fun () ->
                    doc.p "" <| fun () -> 
                        doc.s <| LL g "Copyright &copy; 数理波動システム研究室" "Copyright &copy; Computational Wave System Laboratory"
                        
//コンテンツのフォーマット
let contentsPage g filename pagename code =
    page g filename pagename <| fun doc ->
        doc.div "box7" <| fun () ->
            doc.article "kiji" <| fun () ->
                code(doc)
                
//研究内容のフォーマット
let resPage g filename pagename code =
    page g filename pagename <| fun doc ->
            doc.div "box7-2" <| fun () ->
                doc.aside "sidemenu" <| fun () ->
                    doc.ul [
                            fun () ->
                                doc.page_ref ((resAi g)+".html") <| fun () ->
                                    doc.s <| LL g 
                                        "人工知能"
                                        "Artificial intelligence"
                            fun () ->
                                doc.page_ref ((resHo g)+".html") <| fun () ->
                                    doc.s <| LL g
                                        "ホログラム"
                                        "Hologram"
                            fun () ->
                                doc.page_ref ((resIs g)+".html") <| fun () ->
                                    doc.s <| LL g
                                        "光計測"
                                        "Optical measurement"
                            fun () ->
                                doc.page_ref ((resSc g)+".html") <| fun () ->
                                    doc.s <| LL g
                                        "散乱解析"
                                        "Scattering analysis"
                           ]
            doc.div "box7-1" <| fun () ->
                doc.article "kiji" <| fun () ->
                    code(doc)
                    
//トップページ
for g in [J;E;] do
    HTMLDocument.makehtml outputdir (LL g "index" "index_en") (LL g "数理波動システム研究室" "CWS Laboratory") ["https://sugisaka.github.io/cwslab/style"] ["https://sugisaka.github.io/cwslab/"+(LL g "script1" "script1_en")] [("onload","draw()")] <| fun doc ->
        
        pageheader g "index" doc
        
        doc.div "box3" <| fun () ->
            doc.image_id "slideshow" <| LL g "top_fig-01.svg" "top_fig_en-01.svg"
            
        doc.div "box6" <| fun () ->
            doc.div "box6-1" <| fun () ->
                doc.div "gaiyou" <| fun () ->
                    doc.page_ref ((resAi g)+".html") <| fun () ->
                        doc.h1 <| fun () ->
                            doc.s <| LL g
                                "人工知能"
                                "Artificial intelligence"
                        doc.p  "" <| fun () -> 
                            doc.s <| LL g
                                "光波とコンピュータの<br/>ハイブリッド人工知能"
                                "Hybrid artificial intelligence of light waves and computers"
                            
            doc.div "box6-2" <| fun () ->
                doc.div "gaiyou" <| fun () ->
                    doc.page_ref ((resHo g)+".html") <| fun () ->
                        doc.h1 <| fun () ->
                            doc.s <| LL g
                                "ホログラム"
                                "Hologram"
                        doc.p  "" <| fun () -> 
                            doc.s<| LL g
                                "究極の微細光学像を投影する<br/>ホログラム"
                                "Hologram that projects the ultimate micro-optical image"
                            
            doc.div "box6-3" <| fun () ->
                doc.div "gaiyou" <| fun () ->
                    doc.page_ref ((resIs g)+".html") <| fun () ->
                        doc.h1 <| fun () ->
                            doc.s <| LL g
                                "物体計測システム"
                                "Optical measurement"
                        doc.p "" <| fun () -> 
                            doc.s <| LL g
                                "物体の形状を推定する<br/>計測システム"
                                "Estimation algorithms of scatterer shapes"
                            
            doc.div "box6-4" <| fun () ->
                doc.div "gaiyou" <| fun () ->
                    doc.page_ref ((resSc g)+".html") <| fun () ->
                        doc.h1 <| fun () ->
                            doc.s <| LL g
                                "光・電波の散乱解析"
                                "Scattering analysis"
                        doc.p "" <| fun () -> 
                            doc.s <| LL g
                                "シミュレーションの<br/>高速化・高精度化"
                                "Fast and high-accuracy numerical analysis"
                            
        let newsadd g (tags:Tag list) year month day text =
            fun () ->
                doc.page_ref (match tags.[0] with |Tag.Member -> LL g "member.html" "member_en.html" |Tag.Research1 -> LL g "res_ai.html" "res_ai_en.html" |Tag.Research2 -> LL g "res_ho.html" "res_ho_en.html" |Tag.Research3 -> LL g "res_is.html" "res_is_en.html" |Tag.Research4 -> LL g "res_sc.html" "res_sc_en.html" |Tag.Achieve -> LL g "ach.html" "ach_en.html" |Tag.Link -> LL g "link.html" "link_en.html") <| fun () -> 
                    doc.time g (year,month,day) <| fun () -> doc.s (year.ToString()+"/"+month.ToString("00")+"/"+day.ToString("00"))
                    doc.span "text" <| fun () ->
                        doc.s text
                    for tag in tags do
                        doc.span (match tag with |Tag.Member -> "tag_member" |Tag.Research1 -> "tag_research1" |Tag.Research2 -> "tag_research2" |Tag.Research3 -> "tag_research3" |Tag.Research4 -> "tag_research4" |Tag.Achieve -> "tag_achieve" |Tag.Link -> "tag_link") <| fun () ->
                            doc.s (match tag with |Tag.Member -> LL g "【メンバ】" "[Members]" |Tag.Research1|Tag.Research2|Tag.Research3|Tag.Research4 -> LL g "【研究】" "[Research]" |Tag.Achieve -> LL g "【業績】" "[Achieve]" |Tag.Link -> LL g "【リンク】" "[Link]")

        doc.div "box4" <| fun () ->
            doc.div "news" <| fun () ->
                doc.h1 <| fun () ->
                    doc.s <| LL g "お知らせ" "News"
                doc.ul [
                    newsadd g [Tag.Research3] 2021  1 21 <| LL g 
                        "電磁界理論研究会（光関係合同研究会）にて、逆散乱問題について発表を行いました。"
                        "We made a presentation on the inverse scattering problem at the IEICE and IEEJ EMT Meeting."
                    newsadd g [Tag.Member] 2020 11 30 <| LL g 
                        "学部3年生2名が1次配属により配属されました"
                        "Two students have assigned to our laboratory."
                    newsadd g [Tag.Research1] 2020 11  5 <| LL g
                        "電磁界理論シンポジウムにて、ハイブリッド人工知能について発表を行いました。"
                        "We made a presentation on hybrid artificial intelligence at the IEICE and IEEJ EMT Symposium."
                    newsadd g [Tag.Achieve;Tag.Research2] 2020 10  1 <| LL g
                        "逆散乱問題についての論文が、論文誌Optics Expressに掲載されました。"
                        "Our paper on the inverse scattering problem was published in Optics Express."
                    newsadd g [Tag.Achieve;Tag.Research2] 2020  9 23 <| LL g
                        "フォトンシーブホログラムについての論文が、論文誌Journal of Opticsに掲載されました。"
                        "Our paper on the photon sieve program was published in Journal of Optics."
                    newsadd g [Tag.Research1] 2020  7 17 <| LL g
                        "電磁界理論研究会（光・電波ワークショップ）にて、ハイブリッド人工知能について発表を行いました。"
                        "We made a presentation on hybrid artificial intelligence at the IEICE and IEEJ EMT meeting."
                       ]
                        
        doc.div "box5" <| fun () ->
            doc.div "box5-inner" <| fun () ->
                doc.div "copyright" <| fun () ->
                    doc.p "" <| fun () -> 
                        doc.s <| LL g
                            "Copyright &copy; 数理波動システム研究室"
                            "Copyright &copy; Computational Wave System Laboratory"
                            
    //メンバーのページ
    contentsPage g "mem" (LL g "メンバー" "Members") <| fun doc ->
        doc.aside "bread" <| fun () ->
            doc.ol [
                fun () -> doc.page_ref <| LL g "index.html" "index_en.html" <| fun () -> doc.s <| LL g "トップ" "Top"
                fun () -> doc.page_ref <| LL g "mem.html" "mem_en.html"   <| fun () -> doc.s <| LL g "メンバー" "Members"
                ]
        doc.h1 <| fun () -> doc.s <| LL g "メンバー" "Members"
        doc.h2 <| fun () -> doc.s <| LL g "教員" "Associate professor"
        doc.ul[
            fun () -> doc.s <| LL g "杉坂 純一郎" "Jun-ichiro SUGISAKA"
            ]
        doc.h2 <| fun () -> doc.s <| LL g "学生" "Students"
        doc.h3 <| LL g "2020年度" "2020" <| fun () -> 
            doc.ul[
                fun () -> doc.s <| LL g "(B4) 佐々木 葵" "Aoi SASAKI"
                fun () -> doc.s <| LL g "(B4) 細矢 玲央" "Reo HOSOYA"
                fun () -> doc.s <| LL g "(B3) 児島 健太" "Kenta KOJIMA"
                fun () -> doc.s <| LL g "(B3) 島田 慎吾" "Shingo SHIMADA"
                ]
        if g = J then
            doc.h2 <| fun () -> doc.s "その他"
            doc.s "オンライン教材の登場キャラクター"
            doc.image "characters_web.png"

    //研究内容のページ
    resPage g "res" (LL g "研究内容" "Research Contents") <| fun doc ->
        doc.aside "bread" <| fun () ->
            doc.ol [
                fun () -> doc.page_ref <| LL g "index.html" "index_en.html" <| fun () -> doc.s <| LL g "トップ" "Top"
                fun () -> doc.page_ref <| LL g "res.html" "res_en.html"   <| fun () -> doc.s <| LL g "研究内容" "Research Contents"
                ]

        doc.h1 <| fun () -> doc.s <| LL g "研究内容" "Research Contents"
        doc.p "" <| fun () ->
            doc.s <| LL g
                "光や電波の性質を利用した、さまざまな新技術の開発を行っています。無線通信の電波や光通信の信号はもちろんのこと、身の回りの物体から反射してくる光にも、大量の情報が暗号のように隠されています。その情報を取り出したり、逆に情報を埋め込んだりできれば、新しい情報技術が生まれてくるかもしれません。例えば、微細加工を目標とするモノづくりの研究、光で物体の形状を測る計測の研究、光波を利用した人工知能を開発する研究、光や電波の散乱現象を解析する物理の研究、問題を効率よく解く方法を考える数学分野の研究、使いやすいプログラミング言語を作る研究など、基礎から応用までを対象にしています。難しい数学と物理を使った研究というより、自由にアイディアを出しながら、発想を現実の形にしていく研究です。研究発表や発明（特許出願）なども積極的に行っています。また、ゼミなどの一部の活動は、波動エレクトロニクス研究室と合同で実施します。"
                "We are developing various new technologies that utilize the properties of light and radio waves. A large amount of information is hidden, similar to code, not only in radio waves and optical communication signals of wireless communication but also in the light reflected from objects around us. If we can extract such information or embed it to light, we may be able to produce a new form of information technology. Research work varies from fundamental to application-oriented studies, including studies on manufacturing aimed at fine processing, measurement studies that measure the shape of objects using light, studies on developing artificial intelligence using light waves, physics research that analyzes the scattering phenomena of light and radio waves, mathematical studies that explore ways to solve problems more efficiently, and research on creating new programming languages that are easy to use. Rather than being research work that uses advanced mathematics and physics, these are studies where researchers freely come up with ideas and turn these into reality. We have been active in publicizing our research and invention (patent applications). In addition, some activities such as seminars are being carried out jointly with the Wave Electronics Laboratory of Kitami Institute of Technology."

        doc.h2 <| fun () -> doc.s <| LL g "人工知能" "Artificial intelligence"
        doc.p "" <| fun () ->
            doc.s <| LL g
                "人工知能を構成するニューラルネットワークの大部分を光とホログラムで置き換えます。コンピュータのみで処理するより遥かに速く、立体物を正確に認識できるようになります。"
                "Hybrid artificial intelligence of light waves and computers"
        doc.p "" <| fun () ->
            doc.page_ref <| LL g "res_ai.html" "res_ai_en.html" <| fun () ->
                doc.s <| LL g "詳細" "For more information..."

        doc.h2 <| fun () -> doc.s <| LL g "ホログラム" ""
        doc.p "" <| fun () ->
            doc.s <| LL g
                "世界最高レベルの解像度の立体像を投影するホログラムを開発します。半導体プロセッサの製造に利用し、安価で高品質な次世代コンピュータの開発を支えます。"
                "Hologram that projects the ultimate micro-optical image"
        doc.p "" <| fun () ->
            doc.page_ref <| LL g "res_ho.html" "res_ho_en.html" <| fun () ->
                doc.s <| LL g "詳細" "For more information..."

        doc.h2 <| fun () -> doc.s <| LL g "光計測" ""
        doc.p "" <| fun () ->
            doc.s <| LL g
                "微細な物体に光や電波を照射し、物体の形状を推定します。顕微鏡の限界を超えた観測、凍結路面や建築物、農作物など、様々な対象の状態を観測するシステムを目指します。"
                "Measurement system that estimates the shape of an object"
        doc.p "" <| fun () ->
            doc.page_ref <| LL g "res_is.html" "res_is_en.html" <| fun () ->
                doc.s <| LL g "詳細" "For more information..."

        doc.h2 <| fun () -> doc.s <| LL g "散乱解析" ""
        doc.p "" <| fun () ->
            doc.s <| LL g
                "光や電波の散乱現象を効率的にシミュレーションする計算手法、計算機システム、プログラミング言語を開発します。スーパーコンピュータでも困難な大規模計算を、パソコン1台で計算可能にします。"
                "Fast and high-accuracy numerical analysis of electromagnetic field scattering"
        doc.p "" <| fun () ->
            doc.page_ref <| LL g "res_sc.html" "res_sc_en.html" <| fun () ->
                doc.s <| LL g "詳細" "For more information..."

    //研究内容1（人工知能）のページ
    resPage g (resAi J) (LL g "研究内容" "Research Contents") <| fun doc ->
        doc.aside "bread" <| fun () ->
            doc.ol [
                fun () -> doc.page_ref <| LL g "index.html" "index_en.html" <| fun () -> doc.s <| LL g "トップ" "Top"
                fun () -> doc.page_ref <| LL g "res.html" "res_en.html"   <| fun () -> doc.s <| LL g "研究内容" "Research Contents"
                fun () -> doc.page_ref ((resAi g)+".html") <| fun () -> doc.s <| LL g "人工知能" "Artificial intelligence"
                ]

        doc.h1 <| fun () -> doc.s <| LL g "人工知能" "Artificial intelligence"

        doc.p "" <| fun () ->
            doc.s <| LL g
                "人工知能は、「見ている物体がどのような形か」を認識でき、車の自動運転や工業製品のチェックなど、現代の生活になくてはならないものになりつつあります。ニューラルネットワークやディープラーニングと呼ばれる人工知能は、生物の脳のしくみをヒントに作られた人工知能です。"
                "Artificial intelligence can recognize &quot;what the object you are looking at is shaped like&quot; and is becoming an indispensable part of modern life, including automatic driving of cars and quality control of industrial products. Neural networks and deep learning are artificial intelligence technologies inspired by the how the brains of living things work."

        doc.p "" <| fun () ->
            doc.s <| LL g
                "物体をカメラで撮影し、画像データを人工知能に入力します。"
                "An object is photographed with a camera, and the image data is imported into artificial intelligence."

        doc.image <| LL g "res_fig-01.svg" "res_fig_en-01.svg"

        doc.p "" <| fun () ->
            doc.s <| LL g
                "この多数の線の上を信号が伝達します。コンピュータは、この線の上のデータを1本ずつ計算していきます。"
                "Signals travel over these many lines. The computer calculates the data on this line one by one."

        doc.p "" <| fun () ->
            doc.s <| LL g
                "立方体の写真を入力すると、間違って六角形と認識してしまいました。これは、画像データが平面で、物体の立体情報が含まれていなかったためです。"
                "When an image of a cube was imported, it was misrecognized as a hexagon. This is because the image data was flat and did not contain the 3D information of the object. To avoid misrecognition, the same object should be shot from different angles."

        doc.image <| LL g "res_fig-02.svg" "res_fig_en-01.svg"

        doc.p "" <| fun () ->
            doc.s <| LL g
                "上の新システムでは、物体からの光をカメラで真っ先に電気信号へ変換せず、途中まで光のまま処理します。前半の光学系サイドでは、ホログラムを使って光波から物体の立体情報を抽出します。立体的な像を映し出すというホログラムの性質を逆に利用しているのです。"
                "In the new system above, the light from the object is processed midway, rather than the camera converting it to an electrical signal right away. In the optical system side on the first half, holograms are used to extract 3D information of an object from light waves. It reverse utilizes the property of holograms to project a 3D image."

        doc.p "" <| fun () ->
            doc.s <| LL g
                "光学系サイドでは、光が進むだけで数百億本に相当する「信号の経路」が一瞬で計算されます。そのおかげで、計算機サイドで処理するデータ量を大幅に少なくできます。"
                "On the optical system side, the “signal path” equivalent to tens of billions of lines is calculated in an instant as light passes. Owing to this, the amount of data processed on the computer side can be significantly reduced."

    //研究内容2（ホログラム）のページ
    resPage g (resHo J) (LL g "研究内容" "Research Contents") <| fun doc ->
        doc.aside "bread" <| fun () ->
            doc.ol [
                fun () -> doc.page_ref <| LL g "index.html" "index_en.html" <| fun () -> doc.s <| LL g "トップ" "Top"
                fun () -> doc.page_ref <| LL g "res.html" "res_en.html"   <| fun () -> doc.s <| LL g "研究内容" "Research Contents"
                fun () -> doc.page_ref ((resHo g)+".html") <| fun () -> doc.s <| LL g "ホログラム" "Hologram"
                ]

        doc.h1 <| fun () -> doc.s <| LL g "ホログラム" "Hologram"

        doc.p "" <| fun () ->
            doc.s <| LL g
                "コンピュータのチップには、1000万個以上の素子が、ナノメートルの大きさで加工されています。工場では半導体ウェハに、配線パターンの像を投影することで加工しています。この方法はフォトリソグラフィと呼ばれ、より短い波長の光で投影することで、電子回路の微細化を実現してきました。"
                "More than 10 million elements are processed in the nanometer scale on computer chips. In the factory, the elements are processed by projecting an image of the wiring pattern on a semiconductor wafer. This method is called photolithography and has achieved miniaturization of electronic circuits by projecting light with a shorter wavelength."

        doc.p "" <| fun () ->
            doc.s <| LL g
                "配線パターンを半導体ウェハに転写する装置はステッパと呼ばれています。レチクルに配線パターンが加工されており、それを多数のレンズやミラーでウェハに投影します。"
                "A device that transfers a wiring pattern to a semiconductor wafer is called a stepper. A wiring pattern is processed on the reticle and projected onto the wafer using a large number of lenses and mirrors."

        doc.p "" <| fun () ->
            doc.s <| LL g
                "紫外線など、短い波長の光を使うことで、より小さな配線パターンを投影できますが、その方法も限界になりつつあります。"
                "Smaller wiring patterns can be projected by using shorter-wavelength light such as ultraviolet light, but this approach too is reaching its limits."

        doc.ul
            [fun () ->
                doc.s <| LL g
                    "これ以上短い光はレンズを透過せず、代わりにミラーが必要。ミラーが作る像は非常に暗く、像の縮小率も低い。"
                    "Light having a shorter wavelength than this does not pass through the lens but requires a mirror instead. The image created by the mirror is very dark, and the reduction rate of the image is low."
             fun () ->
                doc.s <| LL g
                    "レチクルにわずかな塵埃が付着しただけで、投影される配線が断線・ショートしてしまう。（清浄度を上げる大がかりな設備が必要）"
                    "	Even a small amount of dust on the reticle causes the projected wiring to break or short circuit. (requires large-scale equipment to improve cleanliness)"
            ]

        doc.image <| LL g "res_fig-03.svg" "res_fig_en-03.svg"

        doc.p "" <| fun () ->
            doc.s <| LL g
                "ホログラムを使って像を投影できれば、レンズもミラーも必要なくなります。ホログラム表面の塵埃が、像に悪影響を及ぼすこともありません。"
                "If an image can be projected using a hologram, there will be no need for a lens or mirror. Dust on the hologram surface does not adversely affect the image."

        doc.image <| LL g "res_fig-04.svg" "res_fig_en-04.svg"

        doc.p "" <| fun () ->
            doc.s <| LL g
                "この研究室では、微細な像をレンズ・ミラーなしに直接投影できるホログラム「準結晶ホログラム」「フォトンシーブホログラム」を開発しています。ひし形や円を組み合わせた基盤図形からホログラムパターンを設計し、ガラスに加工して光を照射すると、微細な像が現れます。"
                "In this laboratory, we are developing holograms called &quot;quasicrystal holograms&quot; and &quot;photon sieve holograms&quot; that can directly project microscale images without a lens or mirror. When a hologram pattern is designed from a base layout that combines diamonds and circles, process it onto glass, and shine light on it, a microscale image appears."

    //研究内容3（光計測）のページ
    resPage g (resIs J) (LL g "研究内容" "Research Contents") <| fun doc ->
        doc.aside "bread" <| fun () ->
            doc.ol [
                fun () -> doc.page_ref <| LL g "index.html" "index_en.html" <| fun () -> doc.s <| LL g "トップ" "Top"
                fun () -> doc.page_ref <| LL g "res.html" "res_en.html"   <| fun () -> doc.s <| LL g "研究内容" "Research Contents"
                fun () -> doc.page_ref ((resIs g)+".html") <| fun () -> doc.s <| LL g "光計測" "Object measurement system"
                ]

        doc.h1 <| fun () -> doc.s <| LL g "光計測" "Object measurement system"

        doc.p "" <| fun () ->
            doc.s <| LL g
                "顕微鏡は物体を拡大してみることができます。これは、物体からの光をレンズで屈折させ、元よりも大きな像を作っているためです。レンズの組み合わせ次第で拡大倍率を上げることができますが、これには限界があり、照明光の波長より小さい物体の像は作れません。これを回折限界といいます。"
                "Microscopes magnify objects. This is because the lens refracts the light from the object and creates an image larger than the original object. The magnification can be increased by combining lenses, but there is a limit to this, and creating an image of an object smaller than the wavelength of the light being shone is not possible. This is called the diffraction limit."

        doc.image <| LL g "res_fig-05.svg" "res_fig_en-05.svg"

        doc.p "" <| fun () ->
            doc.s <| LL g
                "レーダーやX線CTのように、物体からの光（電磁波）をコンピュータで処理して、物体の形を推定する技術が多く考案されており、一般に逆散乱問題と言われています。"
                "Many techniques such as radar and X-ray CT have been devised to estimate the shape of an object by processing the light (electromagnetic waves) from the object with a computer, and it is commonly referred to as the inverse scattering problem."

        doc.p "" <| fun () ->
            doc.s <| LL g
                "X線で照明する場合、物体が非常に薄い場合は、散乱や回折の効果が小さいため、物体の形を推定することは比較的容易です。そうでない場合は、複雑で強い散乱が発生するため、推定は難しくなります。"
                "When X-rays are irradiated, if the object is very thin, the scattering and diffraction effects are small, making it relatively easy to estimate the shape of the object. If the object is not very thin, complex and intense scattering renders the estimation difficult."

        doc.image <| LL g "res_fig-06.svg" "res_fig_en-06.svg"

        doc.p "" <| fun () ->
            doc.s <| LL g
                "この研究室では、物体の形と散乱光の関係をシンプルに表してくれる「積分方程式」を使って推定を行います。計算を反復し（繰り返し）ながら推定形状を少しずつ正確なものに近づけていきます。"
                "In our laboratory, we run estimations using the “integral equation” which simply expresses the relation between the shape of an object and the scattered light. The calculations are repeated to progressively bring the estimated shape closer to accuracy."

        doc.image <| LL g "res_fig-07.svg" "res_fig_en-07.svg"

        doc.p "" <| fun () ->
            doc.s <| LL g
                "数回の反復処理で、ほぼ正確な形状が推定できています。この物体は顕微鏡の解像度では計測不可能なサイズで、回折限界を超えた計測が可能であることを示しています。"
                "A near-accurate shape can be estimated through several rounds of repeated processing. This object is of a size that cannot be measured with the resolution of a microscope, indicating that taking measurements beyond the diffraction limit is possible."

    //研究内容4（散乱解析）のページ
    resPage g (resSc J) (LL g "研究内容" "Research Contents") <| fun doc ->
        doc.aside "bread" <| fun () ->
            doc.ol [
                fun () -> doc.page_ref <| LL g "index.html" "index_en.html" <| fun () -> doc.s <| LL g "トップ" "Top"
                fun () -> doc.page_ref <| LL g "res.html" "res_en.html"   <| fun () -> doc.s <| LL g "研究内容" "Research Contents"
                fun () -> doc.page_ref ((resSc g)+".html") <| fun () -> doc.s <| LL g "散乱解析" "Scatter Analysis"
                ]

        doc.h1 <| fun () -> doc.s <| LL g "散乱解析" "Scatter Analysis"

        doc.p "" <| fun () ->
            doc.s <| LL g
                "散乱シミュレーションとは、照射された光や電波が物体でどのように散乱されるかをコンピュータで計算することです。光学素子の設計や光計測技術、レーダー、無線通信技術の開発に必須の解析です。散乱体の形状やスケール、目的のデータなどに応じて、様々な解析手法が考案されています。"
                "Scatter simulation is a computer calculation of how irradiated light or radio waves are scattered by an object. This analysis is indispensable to the design of optical elements and the development of optical measurement technology, radar, and wireless communication technology."

        doc.p "" <| fun () ->
            doc.s <| LL g
                "微細構造を含む狭い範囲の解析や、微細構造がない素子の広範囲の解析については解析方法が確立しており、広く利用されています。しかし、大面積の素子全面に微細構造が加工されたような素子については、計算に時間がかかりすぎるため、スーパーコンピュータを使っても、解析は大変困難です。"
                "Methods have been established to analyze a narrow range which includes microstructures as well as a wide range of elements without microstructures. However, as an element with a microstructure processed on the entire surface of a large-area element takes considerable time to run calculations, analyzing it even using a supercomputer is very difficult."

        doc.image <| LL g "res_fig-08.svg" "res_fig_en-08.svg"

        doc.p "" <| fun () ->
            doc.s <| LL g
                "この研究室では、新たな計算アルゴリズムを多数考案し、これまで不可能であった規模のシミュレーションを可能にしました。以下の解析例は、すべてパソコン1台で計算したものです。"
                "We have devised many new calculation algorithms in our laboratory and made it possible to perform simulations on a scale that was not possible before. The following examples of analysis have all been calculated using a single PC."

        doc.image <| LL g "res_fig-09.svg" "res_fig_en-09.svg"

        doc.p "" <| fun () ->
            doc.s <| LL g
                "複雑な数式や計算プロセスを簡潔に記述でき、かつ高速に動作する独自のプログラミング言語「Aqualis」の開発も行っています。"
                "We are also developing our own programming language &quot;Aqualis&quot; that can describe complicated mathematical formulae and calculation processes in a simple manner and is capable of high-speed operations."

    //研究業績のページ
    contentsPage g "ach" (LL g "研究業績" "Achievements") <| fun doc ->
        doc.aside "bread" <| fun () ->
            doc.ol [
                fun () -> doc.page_ref <| LL g "index.html" "index_en.html" <| fun () -> doc.s <| LL g "トップ" "Top"
                fun () -> doc.page_ref <| LL g "ach.html" "ach_en.html"   <| fun () -> doc.s <| LL g "研究業績" "Research Achievements"
                ]
        doc.h1 <| fun () -> doc.s <| LL g "研究業績" "Research Achievements"

        doc.p "" <| fun () ->
            doc.s <| LL g
                "これまでに発表された主な研究成果を紹介します。その他の業績はResearchmapをご覧ください"
                "We introduce some of the main research results that we have published till date. Please refer to the Researchmap website for our other achievements."

        doc.p "" <| fun () ->
            doc.page_ref "https://researchmap.jp/j-sugisaka" <| fun () ->
                doc.s <| LL g
                    "Researchmap（論文：44報／講演・口頭発表：77件）"
                    "Researchmap (Publications: 44 / Lectures and oral presentations: 77)"
                    
        doc.h4 "Profile reconstruction of a local defect in a groove structure and the theoretical limit under the vector diffraction theory" <| fun () ->
            doc.div "author" <| fun () ->
                doc.s "Jun-ichiro Sugisaka, Takashi Yasui, Koichi Hirayama"
            doc.div "article" <| fun () ->
                doc.s <| "Optics Express, 28(21), 30908-30927 ("+(LL g "2020年10月" "October 2020")+")"
            doc.div "box8" <| fun () ->
                doc.div "box8-A" <| fun () ->
                    doc.image <| LL g "ach_fig-08.svg" "ach_fig_en-08.svg"
                doc.div "box8-B" <| fun () ->
                    doc.s <| LL g
                        "回折格子の表面にある微小な欠陥の断面形状を、照射した光の散乱波から推定する方法を提案しています。光学顕微鏡で見ることのできる物体の限界は、回折限界として知られていますが、欠陥とその周囲で生じる散乱現象を解析すると、回折限界を超えて欠陥形状を推定できます。推定可能な形状とその理論限界について解析を行い、何パーセントの制度で推定可能かを予測する方法を示しています。"
                        "We have proposed a method to estimate the cross-sectional shape of microdefects on the surface of the diffraction grating using the scattered waves of irradiated light. While the limit of an object that can be seen with an optical microscope is known as the diffraction limit, estimating the defected shape beyond the diffraction limit is possible by analyzing the defect and scattering phenomenon occurring around it. We have demonstrated how to analyze the estimable shape and its theoretical limits and predict what percentage of the system can be estimated."

        doc.h4 "Lensless computer-generated hologram with wavelength-order resolution consisting of photon sieves" <| fun () ->
            doc.div "author" <| fun () ->
                doc.s "Jun-ichiro Sugisaka, Ko Onishi"
            doc.div "article" <| fun () ->
                doc.s <| "Journal of Optics, 22, 105606 ("+(LL g "2020年9月" "September 2020")+")"
            doc.div "box8" <| fun () ->
                doc.div "box8-A" <| fun () ->
                    doc.image <| LL g "ach_fig-07.svg" "ach_fig_en-07.svg"
                doc.div "box8-B" <| fun () ->
                    doc.s <| LL g
                        "スパースフォトンシーブと呼ばれる穴あき薄膜を用いて、微細なライン像を投影するホログラム（フォトンシーブホログラム）を提案しています。従来のホログラムで微細な像を投影するためには、縮小投影光学系などのレンズが必要でした。フォトンシーブホログラムは微細な像を直接生成できるため、光学系の構成が困難な紫外線やX線でも像を作ることができます"
                        "We have proposed a hologram that projects a fine-line image using a perforated thin film known as sparse photon sieve (photon sieve hologram). Projecting a fine image with a conventional hologram required a lens such as a reduced projection optical system. As photon sieve holograms can directly generate fine images, they can also produce images even with UV rays and X-rays, with which constructing optical systems is difficult."

        doc.h4 "Reconstruction of scatterer shape from relative intensity of scattered field by using linearized boundary element method" <| fun () ->
            doc.div "author" <| fun () ->
                doc.s "Jun-ichiro Sugisaka, Takashi Yasui, Koichi Hirayama"
            doc.div "article" <| fun () ->
                doc.s <| "IEICE Transactions on Electronics, E103-C(2), 30-38 ("+(LL g "2020年2月" "February 2020")+")"
            doc.div "box8" <| fun () ->
                doc.div "box8-A" <| fun () ->
                    doc.image <| LL g "ach_fig-06.svg" "ach_fig_en-06.svg"
                doc.div "box8-B" <| fun () ->
                    doc.s <| LL g
                        "微粒子に光を照射し、その散乱波から微粒子表面の形状を推定する方法を提案しています。従来は微粒子に照射する光の強度（明るさ）をあらかじめ計測する等の下準備が必要でしたが、本論文では、そのような準備をすることなく、形状を推定する方法を提案しています。計測中に照明の明るさが変動しても結果に影響しにくく、安定した計測が可能になります。"
                        "We have proposed a method of irradiating fine particles with light and estimating the shape of the surface of fine particles from the scattered waves. Traditionally, making preliminary arrangements such as measuring the intensity (brightness) of light being irradiated on the fine particles was necessary, but in this paper, we proposed a method for estimating the particle shapes without making such preparations. Even if the brightness of the irradiated light fluctuates during measurement, it is possible to realize stable measurements without the results being affected."

        doc.h4 "Field-stitching boundary element method for accurate and rapid vectorial diffraction analysis of large-sized one-dimensional diffractive optical elements" <| fun () ->
            doc.div "author" <| fun () ->
                doc.s "Jun-ichiro Sugisaka, Takashi Yasui, Koichi Hirayama"
            doc.div "article" <| fun () ->
                doc.s <| "Optics Express, 26, 20023-20039 ("+(LL g "2018年8月" "August 2018")+")"
            doc.div "box8" <| fun () ->
                doc.div "box8-A" <| fun () ->
                    doc.image <| LL g "ach_fig-05.svg" "ach_fig_en-05.svg"
                doc.div "box8-B" <| fun () ->
                    doc.s <| LL g
                        "フォトマスクや回折光学素子などの表面には複雑な凹凸パターンが加工されています。これらの素子は、少ない種類の「小さなパターン」の組み合わせで構成されることがあります。本論文では、このような素子からの散乱波を効率的に計算するために、素子を構成する小さなパターンの散乱波を計算しておきます。目的の素子からの散乱波は、小さなパターンからの散乱波の組み合わせで計算できることになります。その際、小さなパターンからの散乱波をただ足し合わせただけでは、誤差が大きくなったり、パターンのつなぎ目で不整合が生じてしまいます。そこで、本研究ではstitching field(綴合波)という成分を付け加えて、不整合が生じないような工夫をしています。ちょうど鉄道模型の線路のパーツを組み合わせて多様で複雑なコースが作れるように、多様な凹凸パターンからの散乱波を簡単に計算できるようになります。"
                        "Complex uneven patterns are processed on the surface of photomasks and diffractive optical elements. These elements may comprise few &quot;Small pattern&quot; combinations. In this paper, we calculated the scattered waves of small patterns that make up the element to efficiently calculate the scattered waves from such an element. The scattered wave from the target element can be calculated by combining the scattered waves from small patterns. Meanwhile, simply adding up the scattered waves from small patterns will increase the error and cause irregularity at the pattern joints. Therefore, in this study, we added a component called stitching field to prevent inconsistencies. It will be possible to easily calculate scattered waves from various patterns of unevenness, just as diverse and complex courses can be created by combining railroad track parts of model railroads."

        doc.h4 "Fast actual-size vectorial simulation of concave diffraction gratings with structural randomness" <| fun () ->
            doc.div "author" <| fun () ->
                doc.s "Jun-ichiro Sugisaka, Takashi Yasui, Koichi Hirayama"
            doc.div "article" <| fun () ->
                doc.s <| "Journal of the Optical Society of America A, 34(12), 2157-2164 ("+(LL g "2017年12月" "December 2017")+")"
            doc.div "box8" <| fun () ->
                doc.div "box8-A" <| fun () ->
                    doc.image <| LL g "ach_fig-04.svg" "ach_fig_en-04.svg"
                doc.div "box8-B" <| fun () ->
                    doc.s <| LL g
                        "差分界境界要素法と計算手順の工夫により、実サイズ回折格子をそのまま解析できるようになりました。本論文では、凹面鏡の表面に加工された回折格子からの回折波を計算しています。応用例として、回折格子の溝の不規則性に応じて回折波が弱くなる特性を定量的に解析しています。"
                        "By devising the difference-field boundary element method (DFBEM) and the procedures of calculation, analyzing the real-size diffraction grating has become possible. In this paper, we calculated the diffracted waves from the diffraction grating processed on the surface of the concave mirror. As an example of application, we quantitatively analyzed the property where the diffracted wave attenuates depending on the irregularities in the grooves of the diffraction grating."

        doc.h4 "Efficient Analysis of Diffraction Grating with 10000 Random Grooves by Difference-Field Boundary Element Method" <| fun () ->
            doc.div "author" <| fun () ->
                doc.s "Jun-ichiro Sugisaka, Takashi Yasui, Koichi Hirayama"
            doc.div "article" <| fun () ->
                doc.s <| "IEICE Transactions on Electronics, E100C(1), 27-36 ("+(LL g "2017年1月" "January 2017")+")"
            doc.div "box8" <| fun () ->
                doc.div "box8-A" <| fun () ->
                    doc.image <| LL g "ach_fig-03.svg" "ach_fig_en-03.svg"
                doc.div "box8-B" <| fun () ->
                    doc.s <| LL g
                        "差分界境界要素法により、周期性が失われた回折格子からの散乱波を効率的に計算できるようになりました。本論文では計算手順を工夫し、不規則な溝が10000本加工された大規模な素子からの回折波を計算しています。通常、この規模の解析には大型計算機が必要ですが、本手法では一般的なパソコンでも大きな負荷をかけることなく解析ができるようになっています。"
                        "The differential-finite boundary element method has made it possible to efficiently calculate scattered waves from a diffraction grating that has lost its periodicity. In this paper, we devised a calculation procedure to calculate the diffracted waves from a large-scale element with 10,000 irregular grooves. Normally, a large computer is required for an analysis of this scale, but with this method, analysis can be performed even on a common PC without a heavy burden."

        doc.h4 "Efficient Scattering Analysis of Arbitrarily Shaped Local Defect in Diffraction Grating" <| fun () ->
            doc.div "author" <| fun () ->
                doc.s "Jun-ichiro Sugisaka, Takashi Yasui, Koichi Hirayama"
            doc.div "article" <| fun () ->
                doc.s <| "IEICE Transactions on Electronics, E99C(1), 76-80 ("+(LL g "2016年1月" "January 2016")+")"
            doc.div "box8" <| fun () ->
                doc.div "box8-A" <| fun () ->
                    doc.image <| LL g "ach_fig-02.svg" "ach_fig_en-02.svg"
                doc.div "box8-B" <| fun () ->
                    doc.s <| LL g
                        "差分界境界要素法は、欠陥付き回折格子による電磁波（光）の散乱を効率的に計算できる手法です。しかし、この手法で用いられる積分方程式は欠陥周囲の形状に依存し、形状が変わるたびに積分方程式を導出する必要がありました。本論文では、欠陥の領域を分割して計算することで、基本的な数パターンの積分方程式の組み合わせのみで、様々な欠陥形状の計算に対応できるようにしました。"
                        "The difference-finite boundary element method can efficiently calculate the scattering of electromagnetic waves (light) via a defective diffraction grating. However, the integral equation used in this method depended on the shape around the defect, and deriving the integral equation each time the shape changed was necessary. In this paper, we showed that by dividing the defect area, and calculating various defect shapes by only combining the integral equations of basic numerical patterns is possible."

        doc.h4 "Expansion of the difference-field boundary element method for numerical analyses of various local defects in periodic surface-relief structures" <| fun () ->
            doc.div "author" <| fun () ->
                doc.s "Jun-ichiro Sugisaka, Takashi Yasui, Koichi Hirayama"
            doc.div "article" <| fun () ->
                doc.s <| "Journal of the Optical Society of America A, 32(5), 751-763 ("+(LL g "2015年5月" "May 2015")+")"
            doc.div "box8" <| fun () ->
                doc.div "box8-A" <| fun () ->
                    doc.image <| LL g "ach_fig-01.svg" "ach_fig_en-01.svg"
                doc.div "box8-B" <| fun () ->
                    doc.s <| LL g
                        "欠陥のある回折格子からの光（電磁波）の散乱を効率よく計算する手法を提案しています。回折格子に欠陥が生じると、表面形状が周期的という前提が成り立たなくなり、必要とする計算資源が非常に多くなります。本論文では、差分界境界要素法という手法を用いて、演算量と消費メモリの双方を削減しています。(1)不完全な格子溝、(2)欠けた格子、(3)異物の埋め込み、の3種類の欠陥を具体例に挙げ、高精度な散乱波分布が計算できることを示しています。"
                        "We proposed a method for efficiently calculating the scattering of light (electromagnetic waves) from a defective diffraction grating. When there are defects on a diffraction grating, the assumption that the shape of its surface is periodic no longer holds, and the computational resources required will be extremely large. Here, we used a technique called the difference-finite boundary element method to reduce the amount of computation and the memory consumption. We raised three specific types of defects, namely, (1) incomplete grating grooves, (2) defective grating and (3) foreign matter embedding as examples and showed that highly precise scattered-wave distributions can be calculated."

    //リンクのページ
    //contentsPage g "lin" <| fun doc ->
    //    doc.aside "bread" <| fun () ->
    //        doc.ol [
    //            fun () -> doc.page_ref <| LL g "index.html" "index_en.html" <| fun () -> doc.s <| LL g "トップ" "Top"
    //            fun () -> doc.page_ref <| LL g "lin.html" "lin_en.html"   <| fun () -> doc.s <| LL g "リンク" "Links"
    //            ]
    //    doc.h1 <| fun () -> doc.s <| LL g "リンク" "Links"
