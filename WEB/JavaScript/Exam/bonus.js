function a(n){c;function d(n){return n?1:(c[n]?c[n]:c[n]=(4*n-2)*d(n-1)/(n+1))/2}}

console.log(a(7));