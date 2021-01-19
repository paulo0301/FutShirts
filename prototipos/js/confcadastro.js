
function jumpto(campoatual, proxcampo)
{
   var tamanho_max = eval("document.F1." + campoatual + ".maxLength;");
   var tamanho_atual = eval("document.F1."+ campoatual +".value.length;");
   if (tamanho_atual = tamanho_max)
      { 
         eval("document.F1."+ proxcampo +".focus();");
      }
}
