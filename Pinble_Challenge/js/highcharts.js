
(function () {
    function N(a, b) { var c; a || (a = {}); for (c in b) a[c] = b[c]; return a } function Ya() { for (var a = 0, b = arguments, c = b.length, d = {}; a < c; a++) d[b[a++]] = b[a]; return d } function T(a, b) { return parseInt(a, b || 10) } function yb(a) { return typeof a === "string" } function lb(a) { return typeof a === "object" } function bc(a) { return Object.prototype.toString.call(a) === "[object Array]" } function mb(a) { return typeof a === "number" } function nb(a) { return na.log(a) / na.LN10 } function bb(a) { return na.pow(10, a) } function Eb(a, b) {
        for (var c =
a.length; c--; ) if (a[c] === b) { a.splice(c, 1); break } 
    } function u(a) { return a !== V && a !== null } function A(a, b, c) { var d, e; if (yb(b)) u(c) ? a.setAttribute(b, c) : a && a.getAttribute && (e = a.getAttribute(b)); else if (u(b) && lb(b)) for (d in b) a.setAttribute(d, b[d]); return e } function Fb(a) { return bc(a) ? a : [a] } function r() { var a = arguments, b, c, d = a.length; for (b = 0; b < d; b++) if (c = a[b], typeof c !== "undefined" && c !== null) return c } function Q(a, b) { if (ob && b && b.opacity !== V) b.filter = "alpha(opacity=" + b.opacity * 100 + ")"; N(a.style, b) } function xa(a,
b, c, d, e) { a = B.createElement(a); b && N(a, b); e && Q(a, { padding: 0, border: Ka, margin: 0 }); c && Q(a, c); d && d.appendChild(a); return a } function da(a, b) { var c = function () { }; c.prototype = new a; N(c.prototype, b); return c } function cc(a, b, c, d) { var e = Ba.lang, f = isNaN(b = ya(b)) ? 2 : b, b = c === void 0 ? e.decimalPoint : c, d = d === void 0 ? e.thousandsSep : d, e = a < 0 ? "-" : "", c = String(T(a = ya(+a || 0).toFixed(f))), g = c.length > 3 ? c.length % 3 : 0; return e + (g ? c.substr(0, g) + d : "") + c.substr(g).replace(/(\d{3})(?=\d)/g, "$1" + d) + (f ? b + ya(a - c).toFixed(f).slice(2) : "") }
    function Ca(a, b) { return Array((b || 2) + 1 - String(a).length).join(0) + a } function dc(a, b, c, d) { var e, c = r(c, 1); e = a / c; b || (b = [1, 2, 2.5, 5, 10], d && d.allowDecimals === !1 && (c === 1 ? b = [1, 2, 5, 10] : c <= 0.1 && (b = [1 / c]))); for (d = 0; d < b.length; d++) if (a = b[d], e <= (b[d] + (b[d + 1] || b[d])) / 2) break; a *= c; return a } function Kc(a, b) {
        var c = b || [[ec, [1, 2, 5, 10, 20, 25, 50, 100, 200, 500]], [pb, [1, 2, 5, 10, 15, 30]], [Pa, [1, 2, 5, 10, 15, 30]], [za, [1, 2, 3, 4, 6, 8, 12]], [Ra, [1, 2]], [oa, [1, 2]], [sa, [1, 2, 3, 4, 6]], [ba, null]], d = c[c.length - 1], e = y[d[0]], f = d[1], g; for (g = 0; g < c.length; g++) if (d =
c[g], e = y[d[0]], f = d[1], c[g + 1] && a <= (e * f[f.length - 1] + y[c[g + 1][0]]) / 2) break; e === y[ba] && a < 5 * e && (f = [1, 2, 5]); e === y[ba] && a < 5 * e && (f = [1, 2, 5]); c = dc(a / e, f); return { unitRange: e, count: c, unitName: d[0]}
    } function Lc(a, b, c, d) {
        var e = [], f = {}, g = Ba.global.useUTC, h, i = new Date(b), b = a.unitRange, k = a.count; b >= y[pb] && (i.setMilliseconds(0), i.setSeconds(b >= y[Pa] ? 0 : k * Sa(i.getSeconds() / k))); if (b >= y[Pa]) i[qc](b >= y[za] ? 0 : k * Sa(i[fc]() / k)); if (b >= y[za]) i[rc](b >= y[Ra] ? 0 : k * Sa(i[gc]() / k)); if (b >= y[Ra]) i[hc](b >= y[sa] ? 1 : k * Sa(i[Da]() / k)); b >=
y[sa] && (i[sc](b >= y[ba] ? 0 : k * Sa(i[qb]() / k)), h = i[rb]()); b >= y[ba] && (h -= h % k, i[tc](h)); if (b === y[oa]) i[hc](i[Da]() - i[ic]() + r(d, 1)); d = 1; h = i[rb](); for (var j = i.getTime(), l = i[qb](), i = i[Da](); j < c; ) e.push(j), b === y[ba] ? j = sb(h + d * k, 0) : b === y[sa] ? j = sb(h, l + d * k) : !g && (b === y[Ra] || b === y[oa]) ? j = sb(h, l, i + d * k * (b === y[Ra] ? 1 : 7)) : (j += b * k, b <= y[za] && j % y[Ra] === 0 && (f[j] = Ra)), d++; e.push(j); e.info = N(a, { higherRanks: f, totalRange: b * k }); return e
    } function uc() { this.symbol = this.color = 0 } function vc(a, b, c, d, e, f, g, h, i) {
        var k = g.x, g = g.y, i = k + c +
(i ? h : -a - h), j = g - b + d + 15, l; i < 7 && (i = c + k + h); i + a > c + e && (i -= i + a - (c + e), j = g - b + d - h, l = !0); j < d + 5 && (j = d + 5, l && g >= j && g <= j + b && (j = g + d + h)); j + b > d + f && (j = d + f - b - h); return { x: i, y: j}
    } function Mc(a, b) { var c = a.length, d, e; for (e = 0; e < c; e++) a[e].ss_i = e; a.sort(function (a, c) { d = b(a, c); return d === 0 ? a.ss_i - c.ss_i : d }); for (e = 0; e < c; e++) delete a[e].ss_i } function Rb(a) { for (var b = a.length, c = a[0]; b--; ) a[b] < c && (c = a[b]); return c } function Gb(a) { for (var b = a.length, c = a[0]; b--; ) a[b] > c && (c = a[b]); return c } function Hb(a) {
        for (var b in a) a[b] && a[b].destroy &&
a[b].destroy(), delete a[b]
    } function Sb(a) { zb || (zb = xa(Ea)); a && zb.appendChild(a); zb.innerHTML = "" } function jc(a, b) { var c = "Highcharts error #" + a + ": www.highcharts.com/errors/" + a; if (b) throw c; else U.console && console.log(c) } function Ab(a) { return parseFloat(a.toPrecision(14)) } function Ib(a, b) { Tb = r(a, b.animation) } function wc() {
        var a = Ba.global.useUTC, b = a ? "getUTC" : "get", c = a ? "setUTC" : "set"; sb = a ? Date.UTC : function (a, b, c, g, h, i) { return (new Date(a, b, r(c, 1), r(g, 0), r(h, 0), r(i, 0))).getTime() }; fc = b + "Minutes"; gc = b + "Hours";
        ic = b + "Day"; Da = b + "Date"; qb = b + "Month"; rb = b + "FullYear"; qc = c + "Minutes"; rc = c + "Hours"; hc = c + "Date"; sc = c + "Month"; tc = c + "FullYear"
    } function fb() { } function xc(a, b) {
        function c(a) {
            function b(a, c) { this.pos = a; this.type = c || ""; this.isNew = !0; c || this.addLabel() } function c(a) { if (a) this.options = a, this.id = a.id; return this } function d(a, b, c, e) {
                this.isNegative = b; this.options = a; this.x = c; this.stack = e; this.alignOptions = { align: a.align || (W ? b ? "left" : "right" : "center"), verticalAlign: a.verticalAlign || (W ? "middle" : b ? "bottom" : "top"),
                    y: r(a.y, W ? 4 : b ? 14 : -6), x: r(a.x, W ? b ? -6 : 6 : 0)
                }; this.textAlign = a.textAlign || (W ? b ? "right" : "left" : "center")
            } function e() {
                var a = [], b = [], c; E = M = null; o(x.series, function (e) {
                    if (e.visible || !s.ignoreHiddenSeries) {
                        var f = e.options, g, h, i, j, k, m, l, F, n, x = f.threshold, Bb, o = [], t = 0; if (Z && x <= 0) x = f.threshold = null; if (p) f = e.xData, f.length && (E = Ta(r(E, f[0]), Rb(f)), M = X(r(M, f[0]), Gb(f))); else {
                            var v, w, Jb, z = e.cropped, O = e.xAxis.getExtremes(), Y = !!e.modifyValue; g = f.stacking; Ha = g === "percent"; if (g) k = f.stack, j = e.type + r(k, ""), m = "-" + j, e.stackKey =
j, h = a[j] || [], a[j] = h, i = b[m] || [], b[m] = i; Ha && (E = 0, M = 99); f = e.processedXData; l = e.processedYData; Bb = l.length; for (c = 0; c < Bb; c++) if (F = f[c], n = l[c], n !== null && n !== V && (g ? (w = (v = n < x) ? i : h, Jb = v ? m : j, n = w[F] = u(w[F]) ? w[F] + n : n, ea[Jb] || (ea[Jb] = {}), ea[Jb][F] || (ea[Jb][F] = new d(q.stackLabels, v, F, k)), ea[Jb][F].setTotal(n)) : Y && (n = e.modifyValue(n)), z || (f[c + 1] || F) >= O.min && (f[c - 1] || F) <= O.max)) if (F = n.length) for (; F--; ) n[F] !== null && (o[t++] = n[F]); else o[t++] = n; !Ha && o.length && (E = Ta(r(E, o[0]), Rb(o)), M = X(r(M, o[0]), Gb(o))); u(x) && (E >= x ?
(E = x, Ja = !0) : M < x && (M = x, Ka = !0))
                        } 
                    } 
                })
            } function f(a, b, c) { for (var d, b = Ab(Sa(b / a) * a), c = Ab(Xb(c / a) * a), e = []; b <= c; ) { e.push(b); b = Ab(b + a); if (b === d) break; d = b } return e } function g(a, b, c, d) {
                var e = []; if (!d) x._minorAutoInterval = null; if (a >= 0.5) a = C(a), e = f(a, b, c); else if (a >= 0.08) { var h = Sa(b), i, j, k, m, l, F; for (i = a > 0.3 ? [1, 2, 4] : a > 0.15 ? [1, 2, 4, 6, 8] : [1, 2, 3, 4, 5, 6, 7, 8, 9]; h < c + 1 && !F; h++) { k = i.length; for (j = 0; j < k && !F; j++) m = nb(bb(h) * i[j]), m > b && e.push(l), l > c && (F = !0), l = m } } else if (b = bb(b), c = bb(c), a = q[d ? "minorTickInterval" : "tickInterval"],
a = r(a === "auto" ? null : a, x._minorAutoInterval, (c - b) * (q.tickPixelInterval / (d ? 5 : 1)) / ((d ? ia / P.length : ia) || 1)), a = dc(a, null, na.pow(10, Sa(na.log(a) / na.LN10))), e = Ub(f(a, b, c), nb), !d) x._minorAutoInterval = a / 5; d || (La = a); return e
            } function h() { var a = [], b, c; if (Z) { c = P.length; for (b = 1; b < c; b++) a = a.concat(g(Ga, P[b - 1], P[b], !0)) } else for (b = G + (P[0] - G) % Ga; b <= I; b += Ga) a.push(b); return a } function i() {
                var a, b = M - E >= U, c, d, e, f, g, h; if (p && U === V && !Z) u(q.min) || u(q.max) ? U = null : (o(x.series, function (a) {
                    f = a.xData; for (d = g = a.xIncrement ? 1 :
f.length - 1; d > 0; d--) if (e = f[d] - f[d - 1], c === V || e < c) c = e
                }), U = Ta(c * 5, M - E)), x.setMinRange = function (a) { U = a }; I - G < U && (a = (U - I + G) / 2, a = [G - a, r(q.min, G - a)], b && (a[2] = E), G = Gb(a), h = [G + U, r(q.max, G + U)], b && (h[2] = M), I = Rb(h), I - G < U && (a[0] = I - U, a[1] = r(q.min, I - U), G = Gb(a)))
            } function j(a) {
                var b, c = q.tickInterval, d = q.tickPixelInterval; ba ? (la = m[p ? "xAxis" : "yAxis"][q.linkedTo], b = la.getExtremes(), G = r(b.min, b.dataMin), I = r(b.max, b.dataMax), q.type !== la.options.type && jc(11, 1)) : (G = r(ca, q.min, E), I = r(da, q.max, M)); Z && (!a && Ta(G, E) <= 0 && jc(10,
1), G = nb(G), I = nb(I)); nc && (ca = G = X(G, I - nc), da = I, a && (nc = null)); i(); if (!Ua && !Ha && !ba && u(G) && u(I)) { b = I - G || 1; if (!u(q.min) && !u(ca) && Aa && (E < 0 || !Ja)) G -= b * Aa; if (!u(q.max) && !u(da) && Ba && (M > 0 || !Ka)) I += b * Ba } La = G === I || G === void 0 || I === void 0 ? 1 : ba && !c && d === la.options.tickPixelInterval ? la.tickInterval : r(c, Ua ? 1 : (I - G) * d / (ia || 1)); p && !a && o(x.series, function (a) { a.processData(G !== Pb || I !== va) }); Db(); x.beforeSetTickPositions && x.beforeSetTickPositions(); x.postProcessTickInterval && (La = x.postProcessTickInterval(La)); !Y && !Z && (Wa =
na.pow(10, Sa(na.log(La) / na.LN10)), u(q.tickInterval) || (La = dc(La, null, Wa, q))); x.tickInterval = La; Ga = q.minorTickInterval === "auto" && La ? La / 5 : q.minorTickInterval; (P = q.tickPositions || Xa && Xa.apply(x, [G, I])) || (P = Y ? (x.getNonLinearTimeTicks || Lc)(Kc(La, q.units), G, I, q.startOfWeek, x.ordinalPositions, x.closestPointRange, !0) : Z ? g(La, G, I) : f(La, G, I)); ba || (a = P[0], c = P[P.length - 1], q.startOnTick ? G = a : G > a && P.shift(), q.endOnTick ? I = c : I < c && P.pop())
            } function k(a) { a = (new c(a)).render(); oa.push(a); return a } function l() {
                var a = q.title,
d = q.stackLabels, e = q.alternateGridColor, f = q.lineWidth, g, i, j = m.hasRendered && u(Pb) && !isNaN(Pb), F = (g = x.series.length && u(G) && u(I)) || r(q.showEmpty, !0), n, p; if (g || ba) if (Ga && !Ua && o(h(), function (a) { ra[a] || (ra[a] = new b(a, "minor")); j && ra[a].isNew && ra[a].render(null, !0); ra[a].isActive = !0; ra[a].render() }), o(P.slice(1).concat([P[0]]), function (a, c) { c = c === P.length - 1 ? 0 : c + 1; if (!ba || a >= G && a <= I) Ma[a] || (Ma[a] = new b(a)), j && Ma[a].isNew && Ma[a].render(c, !0), Ma[a].isActive = !0, Ma[a].render(c) }), e && o(P, function (a, b) {
    if (b % 2 ===
0 && a < I) za[a] || (za[a] = new c), n = a, p = P[b + 1] !== V ? P[b + 1] : I, za[a].options = { from: Z ? bb(n) : n, to: Z ? bb(p) : p, color: e }, za[a].render(), za[a].isActive = !0
}), !x._addedPlotLB) o((q.plotLines || []).concat(q.plotBands || []), function (a) { k(a) }), x._addedPlotLB = !0; o([Ma, ra, za], function (a) { for (var b in a) a[b].isActive ? a[b].isActive = !1 : (a[b].destroy(), delete a[b]) }); f && (g = y + (t ? B : 0) + Ia, i = pa - Kb - (t ? gb : 0) + Ia, g = J.crispLine([ta, O ? y : g, O ? i : A, fa, O ? qa - Yb : g, O ? i : pa - Kb], f), $ ? $.animate({ d: g }) : $ = J.path(g).attr({ stroke: q.lineColor, "stroke-width": f,
    zIndex: 7
}).add(), $[F ? "show" : "hide"]()); if (w && F) F = O ? y : A, f = T(a.style.fontSize || 12), F = { low: F + (O ? 0 : ia), middle: F + ia / 2, high: F + (O ? ia : 0)}[a.align], f = (O ? A + gb : y) + (O ? 1 : -1) * (t ? -1 : 1) * Va + (v === 2 ? f : 0), w[w.isNew ? "attr" : "animate"]({ x: O ? F : f + (t ? B : 0) + Ia + (a.x || 0), y: O ? f - (t ? gb : 0) + Ia : F + (a.y || 0) }), w.isNew = !1; if (d && d.enabled) { var s, z, d = x.stackTotalGroup; if (!d) x.stackTotalGroup = d = J.g("stack-labels").attr({ visibility: cb, zIndex: 6 }).add(); d.translate(R, L); for (s in ea) for (z in a = ea[s], a) a[z].render(d) } x.isDirty = !1
            } function n(a) {
                for (var b =
oa.length; b--; ) oa[b].id === a && oa[b].destroy()
            } var p = a.isX, t = a.opposite, O = W ? !p : p, v = O ? t ? 0 : 2 : t ? 1 : 3, ea = {}, q = K(p ? Zb : kc, [Nc, Oc, yc, Pc][v], a), x = this, w, z = q.type, Y = z === "datetime", Z = z === "logarithmic", Ia = q.offset || 0, $a = p ? "x" : "y", ia = 0, D, H, Qa, jb, y, A, B, gb, Kb, Yb, Lb, Db, Q, S, eb, $, E, M, U = q.minRange || q.maxZoom, nc = q.range, ca, da, wa, xa, I = null, G = null, Pb, va, Aa = q.minPadding, Ba = q.maxPadding, Ca = 0, ba = u(q.linkedTo), la, Ja, Ka, Ha, z = q.events, Oa, oa = [], La, Ga, Wa, P, Xa = q.tickPositioner, Ma = {}, ra = {}, za = {}, Da, Fa, Va, Ua = q.categories, ab = q.labels.formatter ||
function () { var a = this.value, b = this.dateTimeLabelFormat; return b ? $b(b, a) : La % 1E6 === 0 ? a / 1E6 + "M" : La % 1E3 === 0 ? a / 1E3 + "k" : !Ua && a >= 1E3 ? cc(a, 0) : a }, Pa = O && q.labels.staggerLines, sa = q.reversed, Ea = Ua && q.tickmarkPlacement === "between" ? 0.5 : 0; b.prototype = { addLabel: function () {
    var a = this.pos, b = q.labels, c = Ua && O && Ua.length && !b.step && !b.staggerLines && !b.rotation && ja / Ua.length || !O && ja / 2, d = a === P[0], e = a === P[P.length - 1], f = Ua && u(Ua[a]) ? Ua[a] : a, g = this.label, h = P.info, i; Y && h && (i = q.dateTimeLabelFormats[h.higherRanks[a] || h.unitName]);
    this.isFirst = d; this.isLast = e; a = ab.call({ axis: x, chart: m, isFirst: d, isLast: e, dateTimeLabelFormat: i, value: Z ? Ab(bb(f)) : f }); c = c && { width: X(1, C(c - 2 * (b.padding || 10))) + ga }; c = N(c, b.style); u(g) ? g && g.attr({ text: a }).css(c) : this.label = u(a) && b.enabled ? J.text(a, 0, 0, b.useHTML).attr({ align: b.align, rotation: b.rotation }).css(c).add(S) : null
}, getLabelSize: function () { var a = this.label; return a ? (this.labelBBox = a.getBBox(!0))[O ? "height" : "width"] : 0 }, getLabelSides: function () {
    var a = q.labels, b = this.labelBBox.width, a = b * { left: 0,
        center: 0.5, right: 1
    }[a.align] - a.x; return [-a, b - a]
}, handleOverflow: function (a) { var b = !0, c = this.isFirst, d = this.isLast, e = this.label, f = e.x; if (c || d) { var g = this.getLabelSides(), h = g[0], g = g[1], i = m.plotLeft, j = i + x.len, k = (a = Ma[P[a + (c ? 1 : -1)]]) && a.label.x + a.getLabelSides()[c ? 0 : 1]; c && !sa || d && sa ? f + h < i && (f = i - h, a && f + g > k && (b = !1)) : f + g > j && (f = j - g, a && f + h < k && (b = !1)); e.x = f } return b }, render: function (a, b) {
    var c = this.type, d = this.label, e = this.pos, f = q.labels, g = this.gridLine, h = c ? c + "Grid" : "grid", i = c ? c + "Tick" : "tick", j = q[h + "LineWidth"],
k = q[h + "LineColor"], m = q[h + "LineDashStyle"], F = q[i + "Length"], h = q[i + "Width"] || 0, l = q[i + "Color"], n = q[i + "Position"], i = this.mark, p = f.step, x = b && Ra || pa, Bb = !0, ea; ea = O ? Lb(e + Ea, null, null, b) + Qa : y + Ia + (t ? (b && Ya || qa) - Yb - y : 0); x = O ? x - Kb + Ia - (t ? gb : 0) : x - Lb(e + Ea, null, null, b) - Qa; if (j) { e = Q(e + Ea, j, b); if (g === V) { g = { stroke: k, "stroke-width": j }; if (m) g.dashstyle = m; if (!c) g.zIndex = 1; this.gridLine = g = j ? J.path(e).attr(g).add(eb) : null } if (!b && g && e) g[this.isNew ? "attr" : "animate"]({ d: e }) } if (h) n === "inside" && (F = -F), t && (F = -F), c = J.crispLine([ta,
ea, x, fa, ea + (O ? 0 : -F), x + (O ? F : 0)], h), i ? i.animate({ d: c }) : this.mark = J.path(c).attr({ stroke: l, "stroke-width": h }).add(S); if (d && !isNaN(ea)) ea = ea + f.x - (Ea && O ? Ea * H * (sa ? -1 : 1) : 0), x = x + f.y - (Ea && !O ? Ea * H * (sa ? 1 : -1) : 0), u(f.y) || (x += T(d.styles.lineHeight) * 0.9 - d.getBBox().height / 2), Pa && (x += a / (p || 1) % Pa * 16), d.x = ea, d.y = x, this.isFirst && !r(q.showFirstLabel, 1) || this.isLast && !r(q.showLastLabel, 1) ? Bb = !1 : !Pa && O && f.overflow === "justify" && !this.handleOverflow(a) && (Bb = !1), p && a % p && (Bb = !1), Bb ? (d[this.isNew ? "attr" : "animate"]({ x: d.x, y: d.y }),
d.show(), this.isNew = !1) : d.hide()
}, destroy: function () { Hb(this) } 
}; c.prototype = { render: function () {
    var a = this, b = (x.pointRange || 0) / 2, c = a.options, d = c.label, e = a.label, f = c.width, g = c.to, h = c.from, i = c.value, j, k = c.dashStyle, m = a.svgElem, F = [], l, q, n = c.color; q = c.zIndex; var p = c.events; Z && (h = nb(h), g = nb(g), i = nb(i)); if (f) { if (F = Q(i, f), b = { stroke: n, "stroke-width": f }, k) b.dashstyle = k } else if (u(h) && u(g)) h = X(h, G - b), g = Ta(g, I + b), j = Q(g), (F = Q(h)) && j ? F.push(j[4], j[5], j[1], j[2]) : F = null, b = { fill: n }; else return; if (u(q)) b.zIndex = q; if (m) F ?
m.animate({ d: F }, null, m.onGetPath) : (m.hide(), m.onGetPath = function () { m.show() }); else if (F && F.length && (a.svgElem = m = J.path(F).attr(b).add(), p)) for (l in k = function (b) { m.on(b, function (c) { p[b].apply(a, [c]) }) }, p) k(l); if (d && u(d.text) && F && F.length && B > 0 && gb > 0) {
        d = K({ align: O && j && "center", x: O ? !j && 4 : 10, verticalAlign: !O && j && "middle", y: O ? j ? 16 : 10 : j ? 6 : -4, rotation: O && !j && 90 }, d); if (!e) a.label = e = J.text(d.text, 0, 0).attr({ align: d.textAlign || d.align, rotation: d.rotation, zIndex: q }).css(d.style).add(); j = [F[1], F[4], r(F[6], F[1])];
        F = [F[2], F[5], r(F[7], F[2])]; l = Rb(j); q = Rb(F); e.align(d, !1, { x: l, y: q, width: Gb(j) - l, height: Gb(F) - q }); e.show()
    } else e && e.hide(); return a
}, destroy: function () { Hb(this); Eb(oa, this) } 
}; d.prototype = { destroy: function () { Hb(this) }, setTotal: function (a) { this.cum = this.total = a }, render: function (a) { var b = this.options.formatter.call(this); this.label ? this.label.attr({ text: b, visibility: Za }) : this.label = m.renderer.text(b, 0, 0).css(this.options.style).attr({ align: this.textAlign, rotation: this.options.rotation, visibility: Za }).add(a) },
    setOffset: function (a, b) { var c = this.isNegative, d = x.translate(this.total, 0, 0, 0, 1), e = x.translate(0), e = ya(d - e), f = m.xAxis[0].translate(this.x) + a, g = m.plotHeight, c = { x: W ? c ? d : d - e : f, y: W ? g - f - b : c ? g - d - e : g - d, width: W ? e : b, height: W ? b : e }; this.label && this.label.align(this.alignOptions, null, c).attr({ visibility: cb }) } 
}; Lb = function (a, b, c, d, e) {
    var f = 1, g = 0, h = d ? jb : H, d = d ? Pb : G, e = q.ordinal || Z && e; h || (h = H); c && (f *= -1, g = ia); sa && (f *= -1, g -= f * ia); b ? (sa && (a = ia - a), a = a / h + d, e && (a = x.lin2val(a))) : (e && (a = x.val2lin(a)), a = f * (a - d) * h + g + f * Ca);
    return a
}; Q = function (a, b, c) { var d, e, f, a = Lb(a, null, null, c), g = c && Ra || pa, h = c && Ya || qa, i, c = e = C(a + Qa); d = f = C(g - a - Qa); if (isNaN(a)) i = !0; else if (O) { if (d = A, f = g - Kb, c < y || c > y + B) i = !0 } else if (c = y, e = h - Yb, d < A || d > A + gb) i = !0; return i ? null : J.crispLine([ta, c, d, fa, e, f], b || 0) }; x.setMaxTicks = function () { db || (db = { x: 0, y: 0 }); if (!ba && !Y && P.length > db[$a] && q.alignTicks !== !1) db[$a] = P.length }; Db = function () {
    var a = I - G, b = 0, c, d; if (p) ba ? b = la.pointRange : o(x.series, function (a) {
        b = X(b, a.pointRange); d = a.closestPointRange; !a.noSharedTooltip &&
u(d) && (c = u(c) ? Ta(c, d) : d)
    }), x.pointRange = b, x.closestPointRange = c; jb = H; x.translationSlope = H = ia / (a + b || 1); Qa = O ? y : Kb; Ca = H * (b / 2)
}; ua.push(x); m[p ? "xAxis" : "yAxis"].push(x); W && p && sa === V && (sa = !0); N(x, { addPlotBand: k, addPlotLine: k, adjustTickAmount: function () { if (db && db[$a] && !Y && !Ua && !ba && q.alignTicks !== !1) { var a = Da, b = P.length; Da = db[$a]; if (b < Da) { for (; P.length < Da; ) P.push(Ab(P[P.length - 1] + La)); H *= (b - 1) / (Da - 1); I = P[P.length - 1] } if (u(a) && Da !== a) x.isDirty = !0 } }, categories: Ua, getExtremes: function () {
    return { min: Z ? Ab(bb(G)) :
G, max: Z ? Ab(bb(I)) : I, dataMin: E, dataMax: M, userMin: ca, userMax: da
    }
}, getPlotLinePath: Q, getThreshold: function (a) { var b = Z ? bb(G) : G, c = Z ? bb(I) : I; b > a || a === null ? a = b : c < a && (a = c); return Lb(a, 0, 1, 0, 1) }, isXAxis: p, options: q, plotLinesAndBands: oa, getOffset: function () {
    var a = x.series.length && u(G) && u(I), c = a || r(q.showEmpty, !0), d = 0, e, f = 0, g = q.title, h = q.labels, i = [-1, 1, 1, -1][v], j; S || (S = J.g("axis").attr({ zIndex: 7 }).add(), eb = J.g("grid").attr({ zIndex: q.gridZIndex || 1 }).add()); Fa = 0; if (a || ba) o(P, function (a) {
        Ma[a] ? Ma[a].addLabel() :
Ma[a] = new b(a)
    }), o(P, function (a) { if (v === 0 || v === 2 || { 1: "left", 3: "right"}[v] === h.align) Fa = X(Ma[a].getLabelSize(), Fa) }), Pa && (Fa += (Pa - 1) * 16); else for (j in Ma) Ma[j].destroy(), delete Ma[j]; if (g && g.text) { if (!w) w = x.axisTitle = J.text(g.text, 0, 0, g.useHTML).attr({ zIndex: 7, rotation: g.rotation || 0, align: g.textAlign || { low: "left", middle: "center", high: "right"}[g.align] }).css(g.style).add(), w.isNew = !0; if (c) d = w.getBBox()[O ? "height" : "width"], f = r(g.margin, O ? 5 : 10), e = g.offset; w[c ? "show" : "hide"]() } Ia = i * r(q.offset, ma[v]); Va =
r(e, Fa + f + (v !== 2 && Fa && i * q.labels[O ? "y" : "x"])); ma[v] = X(ma[v], Va + d + i * Ia)
}, render: l, setAxisSize: function () { var a = q.offsetLeft || 0, b = q.offsetRight || 0; y = r(q.left, R + a); A = r(q.top, L); B = r(q.width, ja - a + b); gb = r(q.height, ha); Kb = pa - gb - A; Yb = qa - B - y; ia = X(O ? B : gb, 0); x.left = y; x.top = A; x.len = ia }, setAxisTranslation: Db, setCategories: function (b, c) { x.categories = a.categories = Ua = b; o(x.series, function (a) { a.translate(); a.setTooltipPoints(!0) }); x.isDirty = !0; r(c, !0) && m.redraw() }, setExtremes: function (a, b, c, d, e) {
    c = r(c, !0); e = N(e, { min: a,
        max: b
    }); aa(x, "setExtremes", e, function () { ca = a; da = b; x.isDirtyExtremes = !0; c && m.redraw(d) })
}, setScale: function () { var a, b, c, d; Pb = G; va = I; D = ia; x.setAxisSize(); d = ia !== D; o(x.series, function (a) { if (a.isDirtyData || a.isDirty || a.xAxis.isDirty) c = !0 }); if (d || c || ba || ca !== wa || da !== xa) { e(); j(); wa = ca; xa = da; if (!p) for (a in ea) for (b in ea[a]) ea[a][b].cum = ea[a][b].total; if (!x.isDirty) x.isDirty = d || G !== Pb || I !== va } x.setMaxTicks() }, setTickPositions: j, translate: Lb, redraw: function () {
    tb.resetTracker && tb.resetTracker(!0); l(); o(oa,
function (a) { a.render() }); o(x.series, function (a) { a.isDirty = !0 })
}, removePlotBand: n, removePlotLine: n, reversed: sa, setTitle: function (a, b) { q.title = K(q.title, a); w = w.destroy(); x.isDirty = !0; r(b, !0) && m.redraw() }, series: [], stacks: ea, destroy: function () { var a; Na(x); for (a in ea) Hb(ea[a]), ea[a] = null; if (x.stackTotalGroup) x.stackTotalGroup = x.stackTotalGroup.destroy(); o([Ma, ra, za, oa], function (a) { Hb(a) }); o([$, S, eb, w], function (a) { a && a.destroy() }); $ = S = eb = w = null } 
}); for (Oa in z) ka(x, Oa, z[Oa]); if (Z) x.val2lin = nb, x.lin2val =
bb
        } function d(a) {
            function b() { var c = this.points || Fb(this), d = c[0].series, e; e = [d.tooltipHeaderFormatter(c[0].key)]; o(c, function (a) { d = a.series; e.push(d.tooltipFormatter && d.tooltipFormatter(a) || a.point.tooltipFormatter(d.tooltipOptions.pointFormat)) }); e.push(a.footerFormat || ""); return e.join("") } function c(a, b) { n = l ? a : (2 * n + a) / 3; p = l ? b : (p + b) / 2; s.attr({ x: n, y: p }); kb = ya(a - n) > 1 || ya(b - p) > 1 ? function () { c(a, b) } : null } function d() {
                if (!l) {
                    var a = m.hoverPoints; s.hide(); a && o(a, function (a) { a.setState() }); m.hoverPoints =
null; l = !0
                } 
            } var e, f = a.borderWidth, g = a.crosshairs, h = [], i = a.style, j = a.shared, k = T(i.padding), l = !0, n = 0, p = 0; i.padding = 0; var s = J.label("", 0, 0, null, null, null, a.useHTML, null, "tooltip").attr({ padding: k, fill: a.backgroundColor, "stroke-width": f, r: a.borderRadius, zIndex: 8 }).css(i).hide().add(); Fa || s.shadow(a.shadow); return { shared: j, refresh: function (f) {
                var i, k, q, n, p = {}, w = []; q = f.tooltipPos; i = a.formatter || b; var p = m.hoverPoints, t; j && (!f.series || !f.series.noSharedTooltip) ? (n = 0, p && o(p, function (a) { a.setState() }), m.hoverPoints =
f, o(f, function (a) { a.setState(Ga); n += a.plotY; w.push(a.getLabelConfig()) }), k = f[0].plotX, n = C(n) / f.length, p = { x: f[0].category }, p.points = w, f = f[0]) : p = f.getLabelConfig(); p = i.call(p); e = f.series; k = r(k, f.plotX); n = r(n, f.plotY); i = C(q ? q[0] : W ? ja - n : k); k = C(q ? q[1] : W ? ha - k : n); q = j || !e.isCartesian || e.tooltipOutsidePlot || va(i, k); p === !1 || !q ? d() : (l && (s.show(), l = !1), s.attr({ text: p }), t = a.borderColor || f.color || e.color || "#606060", s.attr({ stroke: t }), q = vc(s.width, s.height, R, L, ja, ha, { x: i, y: k }, r(a.distance, 12), W), c(C(q.x), C(q.y)));
                if (g) { g = Fb(g); var v; q = g.length; for (var z; q--; ) if (v = f.series[q ? "yAxis" : "xAxis"], g[q] && v) if (v = v.getPlotLinePath(q ? r(f.stackY, f.y) : f.x, 1), h[q]) h[q].attr({ d: v, visibility: cb }); else { z = { "stroke-width": g[q].width || 1, stroke: g[q].color || "#C0C0C0", zIndex: g[q].zIndex || 2 }; if (g[q].dashStyle) z.dashstyle = g[q].dashStyle; h[q] = J.path(v).attr(z).add() } } aa(m, "tooltipRefresh", { text: p, x: i + R, y: k + L, borderColor: t })
            }, hide: d, hideCrosshairs: function () { o(h, function (a) { a && a.hide() }) }, destroy: function () {
                o(h, function (a) { a && a.destroy() });
                s && (s = s.destroy())
            } 
            }
        } function e(a) {
            function b(a) { var c, d, a = a || U.event; if (!a.target) a.target = a.srcElement; if (a.originalEvent) a = a.originalEvent; if (a.event) a = a.event; c = a.touches ? a.touches.item(0) : a; hb = zc(H); c.pageX === V ? (d = a.x, c = a.y) : (d = c.pageX - hb.left, c = c.pageY - hb.top); return N(a, { chartX: C(d), chartY: C(c) }) } function c(a) { var b = { xAxis: [], yAxis: [] }; o(ua, function (c) { var d = c.translate, e = c.isXAxis; b[e ? "xAxis" : "yAxis"].push({ axis: c, value: d((W ? !e : e) ? a.chartX - R : ha - a.chartY + L, !0) }) }); return b } function e(a) {
                var b =
m.hoverSeries, c = m.hoverPoint, d = m.hoverPoints || c; if (a && Va && d) Va.refresh(d); else { if (c) c.onMouseOut(); if (b) b.onMouseOut(); Va && (Va.hide(), Va.hideCrosshairs()); mb = null } 
            } function f() {
                if (l) {
                    var a = { xAxis: [], yAxis: [] }, b = l.getBBox(), c = b.x - R, d = b.y - L, e; k && (o(ua, function (f) { if (f.options.zoomEnabled !== !1) { var g = f.translate, h = f.isXAxis, i = W ? !h : h, j = g(i ? c : ha - d - b.height, !0, 0, 0, 1), g = g(i ? c + b.width : ha - d, !0, 0, 0, 1); !isNaN(j) && !isNaN(g) && (a[h ? "xAxis" : "yAxis"].push({ axis: f, min: Ta(j, g), max: X(j, g) }), e = !0) } }), e && aa(m, "selection",
a, sb)); l = l.destroy()
                } if (m) Q(H, { cursor: "auto" }), m.cancelClick = k, m.mouseIsDown = za = k = !1; Na(B, Wa ? "touchend" : "mouseup", f)
            } function g(a) { Ac(a); hb && !va(a.pageX - hb.left - R, a.pageY - hb.top - L) && e() } function h() { e(); hb = null } var i, j, k, l, n = Fa ? "" : s.zoomType, p = /x/.test(n), v = /y/.test(n), t = p && !W || v && W, w = v && !W || p && W; if (!Pa) m.trackerGroup = Pa = J.g("tracker").attr({ zIndex: 9 }).add(); if (a.enabled) m.tooltip = Va = d(a), xb = setInterval(function () { kb && kb() }, 32); (function () {
                H.onmousedown = function (a) {
                    a = b(a); !Wa && a.preventDefault && a.preventDefault();
                    m.mouseIsDown = za = !0; m.cancelClick = !1; m.mouseDownX = i = a.chartX; j = a.chartY; ka(B, Wa ? "touchend" : "mouseup", f)
                }; var d = function (c) {
                    if (!c || !(c.touches && c.touches.length > 1)) {
                        c = b(c); if (!Wa) c.returnValue = !1; var d = c.chartX, e = c.chartY, f = !va(d - R, e - L); Wa && c.type === "touchstart" && (A(c.target, "isTracker") ? m.runTrackerClick || c.preventDefault() : !fb && !f && c.preventDefault()); f && (d < R ? d = R : d > R + ja && (d = R + ja), e < L ? e = L : e > L + ha && (e = L + ha)); if (za && c.type !== "touchstart") {
                            if (k = Math.sqrt(Math.pow(i - d, 2) + Math.pow(j - e, 2)), k > 10) {
                                var g = va(i -
R, j - L); if (Mb && (p || v) && g) l || (l = J.rect(R, L, t ? 1 : ja, w ? 1 : ha, 0).attr({ fill: s.selectionMarkerFill || "rgba(69,114,167,0.25)", zIndex: 7 }).add()); l && t && (c = d - i, l.attr({ width: ya(c), x: (c > 0 ? 0 : c) + i })); l && w && (e -= j, l.attr({ height: ya(e), y: (e > 0 ? 0 : e) + j })); g && !l && s.panning && m.pan(d)
                            } 
                        } else if (!f) {
                            var h, d = m.hoverPoint, e = m.hoverSeries, n, o, g = qa, z = W ? ha + L - c.chartY : c.chartX - R; if (Va && a.shared && (!e || !e.noSharedTooltip)) {
                                h = []; n = S.length; for (o = 0; o < n; o++) if (S[o].visible && S[o].options.enableMouseTracking !== !1 && !S[o].noSharedTooltip &&
S[o].tooltipPoints.length) c = S[o].tooltipPoints[z], c._dist = ya(z - c.plotX), g = Ta(g, c._dist), h.push(c); for (n = h.length; n--; ) h[n]._dist > g && h.splice(n, 1); if (h.length && h[0].plotX !== mb) Va.refresh(h), mb = h[0].plotX
                            } if (e && e.tracker && (c = e.tooltipPoints[z]) && c !== d) c.onMouseOver()
                        } return f || !Mb
                    } 
                }; H.onmousemove = d; ka(H, "mouseleave", h); ka(B, "mousemove", g); H.ontouchstart = function (a) { if (p || v) H.onmousedown(a); d(a) }; H.ontouchmove = d; H.ontouchend = function () { k && e() }; H.onclick = function (a) {
                    var d = m.hoverPoint, a = b(a); a.cancelBubble =
!0; if (!m.cancelClick) if (d && (A(a.target, "isTracker") || A(a.target.parentNode, "isTracker"))) { var e = d.plotX, f = d.plotY; N(d, { pageX: hb.left + R + (W ? ja - f : e), pageY: hb.top + L + (W ? ha - e : f) }); aa(d.series, "click", N(a, { point: d })); d.firePointEvent("click", a) } else N(a, c(a)), va(a.chartX - R, a.chartY - L) && aa(m, "click", a)
                } 
            })(); N(this, { zoomX: p, zoomY: v, resetTracker: e, normalizeMouseEvent: b, destroy: function () {
                if (m.trackerGroup) m.trackerGroup = Pa = m.trackerGroup.destroy(); Na(H, "mouseleave", h); Na(B, "mousemove", g); H.onclick = H.onmousedown =
H.onmousemove = H.ontouchstart = H.ontouchend = H.ontouchmove = null
            } 
            })
        } function f(a) { var b = a.type || s.type || s.defaultSeriesType, c = Ha[b], d = m.hasRendered; if (d) if (W && b === "column") c = Ha.bar; else if (!W && b === "bar") c = Ha.column; b = new c; b.init(m, a); !d && b.inverted && (W = !0); if (b.isCartesian) Mb = b.isCartesian; S.push(b); return b } function g() { s.alignTicks !== !1 && o(ua, function (a) { a.adjustTickAmount() }); db = null } function h(a) {
            var b = m.isDirtyLegend, c, d = m.isDirtyBox, e = S.length, f = e, h = m.clipRect; for (Ib(a, m); f--; ) if (a = S[f], a.isDirty &&
a.options.stacking) { c = !0; break } if (c) for (f = e; f--; ) if (a = S[f], a.options.stacking) a.isDirty = !0; o(S, function (a) { a.isDirty && a.options.legendType === "point" && (b = !0) }); if (b && oa.renderLegend) oa.renderLegend(), m.isDirtyLegend = !1; Mb && (Da || (db = null, o(ua, function (a) { a.setScale() })), g(), Vb(), o(ua, function (a) { if (a.isDirtyExtremes) a.isDirtyExtremes = !1, aa(a, "afterSetExtremes", a.getExtremes()); if (a.isDirty || d || c) a.redraw(), d = !0 })); d && (ob(), h && (Nb(h), h.animate({ width: m.plotSizeX, height: m.plotSizeY + 1 }))); o(S, function (a) {
    a.isDirty &&
a.visible && (!a.isCartesian || a.xAxis) && a.redraw()
}); tb && tb.resetTracker && tb.resetTracker(!0); J.draw(); aa(m, "redraw")
        } function i() { var a = t.xAxis || {}, b = t.yAxis || {}, a = Fb(a); o(a, function (a, b) { a.index = b; a.isX = !0 }); b = Fb(b); o(b, function (a, b) { a.index = b }); a = a.concat(b); o(a, function (a) { new c(a) }); g() } function k() {
            var a = Ba.lang, b = s.resetZoomButton, c = b.theme, d = c.states, e = b.relativeTo === "chart" ? null : { x: R, y: L, width: ja, height: ha }; m.resetZoomButton = J.button(a.resetZoom, null, null, zb, c, d && d.hover).attr({ align: b.position.align,
                title: a.resetZoomTitle
            }).add().align(b.position, !1, e)
        } function j(a, b) { Qa = K(t.title, a); eb = K(t.subtitle, b); o([["title", a, Qa], ["subtitle", b, eb]], function (a) { var b = a[0], c = m[b], d = a[1], a = a[2]; c && d && (c = c.destroy()); a && a.text && !c && (m[b] = J.text(a.text, 0, 0, a.useHTML).attr({ align: a.align, "class": ib + b, zIndex: a.zIndex || 4 }).css(a.style).add().align(a, !1, Ia)) }) } function l() {
            function a(c) {
                var d = s.width || la.offsetWidth, e = s.height || la.offsetHeight, c = c ? c.target : U; if (d && e && (c === U || c === B)) {
                    if (d !== da || e !== ca) clearTimeout(b),
b = setTimeout(function () { rb(d, e, !1) }, 100); da = d; ca = e
                } 
            } var b; ka(U, "resize", a); ka(m, "destroy", function () { Na(U, "resize", a) })
        } function n() { m && aa(m, "endResize", null, function () { Da -= 1 }) } function p() { for (var a = W || s.inverted || s.type === "bar" || s.defaultSeriesType === "bar", b = t.series, c = b && b.length; !a && c--; ) b[c].type === "bar" && (a = !0); m.inverted = W = a } function v() {
            var a = t.labels, b = t.credits, c; j(); oa = m.legend = new Qb; o(ua, function (a) { a.setScale() }); Vb(); db = null; o(ua, function (a) { a.setTickPositions(!0); a.setMaxTicks() });
            g(); Vb(); ob(); Mb && o(ua, function (a) { a.render() }); if (!m.seriesGroup) m.seriesGroup = J.g("series-group").attr({ zIndex: 3 }).add(); o(S, function (a) { a.translate(); a.setTooltipPoints(); a.render() }); a.items && o(a.items, function () { var b = N(a.style, this.style), c = T(b.left) + R, d = T(b.top) + L + 12; delete b.left; delete b.top; J.text(this.html, c, d).attr({ zIndex: 2 }).css(b).add() }); if (b.enabled && !m.credits) c = b.href, m.credits = J.text(b.text, 0, 0).on("click", function () { if (c) location.href = c }).attr({ align: b.position.align, zIndex: 8 }).css(b.style).add().align(b.position);
            m.hasRendered = !0
        } function Z() {
            if (!Ob && U == U.top && B.readyState !== "complete" || Fa && !U.canvg) Fa ? Bc.push(Z, t.global.canvasToolsURL) : B.attachEvent("onreadystatechange", function () { B.detachEvent("onreadystatechange", Z); B.readyState === "complete" && Z() }); else {
                la = s.renderTo; Aa = ib + lc++; yb(la) && (la = B.getElementById(la)); la || jc(13, !0); la.innerHTML = ""; la.offsetWidth || (E = la.cloneNode(0), Q(E, { position: ub, top: "-9999px", display: "block" }), B.body.appendChild(E)); da = (E || la).offsetWidth; ca = (E || la).offsetHeight; m.chartWidth =
qa = s.width || da || 600; m.chartHeight = pa = s.height || (ca > 19 ? ca : 400); m.container = H = xa(Ea, { className: ib + "container" + (s.className ? " " + s.className : ""), id: Aa }, N({ position: mc, overflow: Za, width: qa + ga, height: pa + ga, textAlign: "left", lineHeight: "normal" }, s.style), E || la); m.renderer = J = s.forExport ? new Cb(H, qa, pa, !0) : new Wb(H, qa, pa); Fa && J.create(m, H, qa, pa); aa(m, "init"); if (Highcharts.RangeSelector && t.rangeSelector.enabled) m.rangeSelector = new Highcharts.RangeSelector(m); pb(); qb(); p(); i(); o(t.series || [], function (a) { f(a) });
                if (Highcharts.Scroller && (t.navigator.enabled || t.scrollbar.enabled)) m.scroller = new Highcharts.Scroller(m); m.render = v; m.tracker = tb = new e(t.tooltip); v(); J.draw(); b && b.apply(m, [m]); o(m.callbacks, function (a) { a.apply(m, [m]) }); E && (la.appendChild(H), Sb(E)); aa(m, "load")
            } 
        } var t, w = a.series; a.series = null; t = K(Ba, a); t.series = a.series = w; var s = t.chart, w = s.margin, w = lb(w) ? w : [w, w, w, w], Y = r(s.marginTop, w[0]), z = r(s.marginRight, w[1]), ia = r(s.marginBottom, w[2]), D = r(s.marginLeft, w[3]), jb = s.spacingTop, Db = s.spacingRight, $a =
s.spacingBottom, y = s.spacingLeft, Ia, Qa, eb, L, M, $, R, ma, la, E, H, Aa, da, ca, qa, pa, Ya, Ra, wa, ba, Oa, Ca, m = this, fb = (w = s.events) && !!w.click, ra, va, Va, za, vb, sa, ab, ha, ja, tb, Pa, oa, Xa, wb, hb, Mb = s.showAxes, Da = 0, ua = [], db, S = [], W, J, kb, xb, mb, ob, Vb, pb, qb, rb, sb, zb, Qb = function () {
    function a(b, c) { var d = b.legendItem, e = b.legendLine, g = b.legendSymbol, h = p.color, i = c ? f.itemStyle.color : h, h = c ? b.color : h; d && d.css({ fill: i }); e && e.attr({ stroke: h }); g && g.attr({ stroke: h, fill: h }) } function b(a) {
        var c = a.legendItem, d = a.legendLine, e = a._legendItemPos,
f = e[0], e = e[1], g = a.legendSymbol, a = a.checkbox; c && c.attr({ x: v ? f : Xa - f, y: e }); d && d.translate(v ? f : Xa - f, e - 4); g && (c = f + g.xOff, g.attr({ x: v ? c : Xa - c, y: e + g.yOff })); if (a) a.x = f, a.y = e
    } function c() { o(j, function (a) { var b = a.checkbox, c = A.alignAttr; b && Q(b, { left: c.translateX + a.legendItemWidth + b.x - 40 + ga, top: c.translateY + b.y - 11 + ga }) }) } function d(b) {
        var c, e, j, k, m = b.legendItem; k = b.series || b; var q = k.options, o = q && q.borderWidth || 0; if (!m) {
            k = /^(bar|pie|area|column)$/.test(k.type); b.legendItem = m = J.text(f.labelFormatter.call(b), 0,
0, f.useHTML).css(b.visible ? l : p).on("mouseover", function () { b.setState(Ga); m.css(n) }).on("mouseout", function () { m.css(b.visible ? l : p); b.setState() }).on("click", function () { var a = function () { b.setVisible() }; b.firePointEvent ? b.firePointEvent("legendItemClick", null, a) : aa(b, "legendItemClick", null, a) }).attr({ align: v ? "left" : "right", zIndex: 2 }).add(A); if (!k && q && q.lineWidth) {
                var Ia = { "stroke-width": q.lineWidth, zIndex: 2 }; if (q.dashStyle) Ia.dashstyle = q.dashStyle; b.legendLine = J.path([ta, (-h - i) * (v ? 1 : -1), 0, fa, -i * (v ? 1 :
-1), 0]).attr(Ia).add(A)
            } if (k) j = J.rect(c = -h - i, e = -11, h, 12, 2).attr({ zIndex: 3 }).add(A), v || (c += h); else if (q && q.marker && q.marker.enabled) j = q.marker.radius, j = J.symbol(b.symbol, c = -h / 2 - i - j, e = -4 - j, 2 * j, 2 * j).attr(b.pointAttr[Ja]).attr({ zIndex: 3 }).add(A), v || (c += h / 2); if (j) j.xOff = c + o % 2 / 2, j.yOff = e + o % 2 / 2; b.legendSymbol = j; a(b, b.visible); if (q && q.showCheckbox) b.checkbox = xa("input", { type: "checkbox", checked: b.selected, defaultChecked: b.selected }, f.itemCheckboxStyle, H), ka(b.checkbox, "click", function (a) {
                aa(b, "checkboxClick",
{ checked: a.target.checked }, function () { b.select() })
            })
        } c = m.getBBox(); e = b.legendItemWidth = f.itemWidth || h + i + c.width + s; C = c.height; if (g && Y - r + e > (B || qa - 2 * s - r)) Y = r, u += t + C + w; !g && u + f.y + C > pa - jb - $a && (u = Z, Y += z, z = 0); z = X(z, e); ia = X(ia, u + w); b._legendItemPos = [Y, u]; g ? Y += e : u += t + C + w; E = B || X(Y - r + (g ? 0 : e), E)
    } function e() {
        Y = r; u = Z; ia = E = 0; A || (A = J.g("legend").attr({ zIndex: 7 }).add()); j = []; o(L, function (a) { var b = a.options; b.showInLegend && (j = j.concat(a.legendItems || (b.legendType === "point" ? a.data : a))) }); Mc(j, function (a, b) {
            return (a.options.legendIndex ||
0) - (b.options.legendIndex || 0)
        }); M && j.reverse(); o(j, d); Xa = B || E; wb = ia - q + C; if (D || Qa) { Xa += 2 * s; wb += 2 * s; if (y) { if (Xa > 0 && wb > 0) y[y.isNew ? "attr" : "animate"](y.crisp(null, null, null, Xa, wb)), y.isNew = !1 } else y = J.rect(0, 0, Xa, wb, f.borderRadius, D || 0).attr({ stroke: f.borderColor, "stroke-width": D || 0, fill: Qa || Ka }).add(A).shadow(f.shadow), y.isNew = !0; y[j.length ? "show" : "hide"]() } o(j, b); for (var a = ["left", "right", "top", "bottom"], g, h = 4; h--; ) g = a[h], k[g] && k[g] !== "auto" && (f[h < 2 ? "align" : "verticalAlign"] = g, f[h < 2 ? "x" : "y"] = T(k[g]) *
(h % 2 ? -1 : 1)); j.length && A.align(N(f, { width: Xa, height: wb }), !0, Ia); Da || c()
    } var f = m.options.legend; if (f.enabled) {
        var g = f.layout === "horizontal", h = f.symbolWidth, i = f.symbolPadding, j, k = f.style, l = f.itemStyle, n = f.itemHoverStyle, p = K(l, f.itemHiddenStyle), s = f.padding || T(k.padding), v = !f.rtl, t = f.itemMarginTop || 0, w = f.itemMarginBottom || 0, q = 18, z = 0, r = 4 + s + h + i, Z = s + t + q - 5, Y, u, ia, C = 0, y, D = f.borderWidth, Qa = f.backgroundColor, A, E, B = f.width, L = m.series, M = f.reversed; e(); ka(m, "endResize", c); return { colorizeItem: a, destroyItem: function (a) {
            var b =
a.checkbox; o(["legendItem", "legendLine", "legendSymbol"], function (b) { a[b] && a[b].destroy() }); b && Sb(a.checkbox)
        }, renderLegend: e, destroy: function () { y && (y = y.destroy()); A && (A = A.destroy()) } 
        }
    } 
}; va = function (a, b) { return a >= 0 && a <= ja && b >= 0 && b <= ha }; zb = function () { var a = m.resetZoomButton; aa(m, "selection", { resetSelection: !0 }, sb); if (a) m.resetZoomButton = a.destroy() }; sb = function (a) {
    var b; m.resetZoomEnabled !== !1 && !m.resetZoomButton && k(); !a || a.resetSelection ? o(ua, function (a) {
        a.options.zoomEnabled !== !1 && (a.setExtremes(null,
null, !1), b = !0)
    }) : o(a.xAxis.concat(a.yAxis), function (a) { var c = a.axis; if (m.tracker[c.isXAxis ? "zoomX" : "zoomY"]) c.setExtremes(a.min, a.max, !1), b = !0 }); b && h(r(s.animation, m.pointCount < 100))
}; m.pan = function (a) { var b = m.xAxis[0], c = m.mouseDownX, d = b.pointRange / 2, e = b.getExtremes(), f = b.translate(c - a, !0) + d, c = b.translate(c + ja - a, !0) - d; (d = m.hoverPoints) && o(d, function (a) { a.setState() }); f > Ta(e.dataMin, e.min) && c < X(e.dataMax, e.max) && b.setExtremes(f, c, !0, !1); m.mouseDownX = a; Q(H, { cursor: "move" }) }; Vb = function () {
    var a = t.legend,
b = r(a.margin, 10), c = a.x, d = a.y, e = a.align, f = a.verticalAlign, g; pb(); if ((m.title || m.subtitle) && !u(Y)) (g = X(m.title && !Qa.floating && !Qa.verticalAlign && Qa.y || 0, m.subtitle && !eb.floating && !eb.verticalAlign && eb.y || 0)) && (L = X(L, g + r(Qa.margin, 15) + jb)); a.enabled && !a.floating && (e === "right" ? u(z) || (M = X(M, Xa - c + b + Db)) : e === "left" ? u(D) || (R = X(R, Xa + c + b + y)) : f === "top" ? u(Y) || (L = X(L, wb + d + b + jb)) : f === "bottom" && (u(ia) || ($ = X($, wb - d + b + $a)))); m.extraBottomMargin && ($ += m.extraBottomMargin); m.extraTopMargin && (L += m.extraTopMargin); Mb &&
o(ua, function (a) { a.getOffset() }); u(D) || (R += ma[3]); u(Y) || (L += ma[0]); u(ia) || ($ += ma[2]); u(z) || (M += ma[1]); qb()
}; rb = function (a, b, c) {
    var d = m.title, e = m.subtitle; Da += 1; Ib(c, m); Ra = pa; Ya = qa; if (u(a)) m.chartWidth = qa = C(a); if (u(b)) m.chartHeight = pa = C(b); Q(H, { width: qa + ga, height: pa + ga }); J.setSize(qa, pa, c); ja = qa - R - M; ha = pa - L - $; db = null; o(ua, function (a) { a.isDirty = !0; a.setScale() }); o(S, function (a) { a.isDirty = !0 }); m.isDirtyLegend = !0; m.isDirtyBox = !0; Vb(); d && d.align(null, null, Ia); e && e.align(null, null, Ia); h(c); Ra = null; aa(m,
"resize"); Tb === !1 ? n() : setTimeout(n, Tb && Tb.duration || 500)
}; qb = function () { m.plotLeft = R = C(R); m.plotTop = L = C(L); m.plotWidth = ja = C(qa - R - M); m.plotHeight = ha = C(pa - L - $); m.plotSizeX = W ? ha : ja; m.plotSizeY = W ? ja : ha; Ia = { x: y, y: jb, width: qa - y - Db, height: pa - jb - $a }; o(ua, function (a) { a.setAxisSize(); a.setAxisTranslation() }) }; pb = function () { L = r(Y, jb); M = r(z, Db); $ = r(ia, $a); R = r(D, y); ma = [0, 0, 0, 0] }; ob = function () {
    var a = s.borderWidth || 0, b = s.backgroundColor, c = s.plotBackgroundColor, d = s.plotBackgroundImage, e, f = { x: R, y: L, width: ja, height: ha };
    e = a + (s.shadow ? 8 : 0); if (a || b) wa ? wa.animate(wa.crisp(null, null, null, qa - e, pa - e)) : wa = J.rect(e / 2, e / 2, qa - e, pa - e, s.borderRadius, a).attr({ stroke: s.borderColor, "stroke-width": a, fill: b || Ka }).add().shadow(s.shadow); c && (ba ? ba.animate(f) : ba = J.rect(R, L, ja, ha, 0).attr({ fill: c }).add().shadow(s.plotShadow)); d && (Oa ? Oa.animate(f) : Oa = J.image(d, R, L, ja, ha).add()); s.plotBorderWidth && (Ca ? Ca.animate(Ca.crisp(null, R, L, ja, ha)) : Ca = J.rect(R, L, ja, ha, 0, s.plotBorderWidth).attr({ stroke: s.plotBorderColor, "stroke-width": s.plotBorderWidth,
        zIndex: 4
    }).add()); m.isDirtyBox = !1
}; s.reflow !== !1 && ka(m, "load", l); if (w) for (ra in w) ka(m, ra, w[ra]); m.options = t; m.series = S; m.xAxis = []; m.yAxis = []; m.addSeries = function (a, b, c) { var d; a && (Ib(c, m), b = r(b, !0), aa(m, "addSeries", { options: a }, function () { d = f(a); d.isDirty = !0; m.isDirtyLegend = !0; b && m.redraw() })); return d }; m.animation = Fa ? !1 : r(s.animation, !0); m.Axis = c; m.destroy = function () {
    var a, b = H && H.parentNode; if (m !== null) {
        aa(m, "destroy"); Na(m); for (a = ua.length; a--; ) ua[a] = ua[a].destroy(); for (a = S.length; a--; ) S[a] = S[a].destroy();
        o("title,subtitle,seriesGroup,clipRect,credits,tracker,scroller,rangeSelector".split(","), function (a) { var b = m[a]; b && (m[a] = b.destroy()) }); o([wa, Ca, ba, oa, Va, J, tb], function (a) { a && a.destroy && a.destroy() }); wa = Ca = ba = oa = Va = J = tb = null; if (H) H.innerHTML = "", Na(H), b && Sb(H), H = null; clearInterval(xb); for (a in m) delete m[a]; t = m = null
    } 
}; m.get = function (a) {
    var b, c, d; for (b = 0; b < ua.length; b++) if (ua[b].options.id === a) return ua[b]; for (b = 0; b < S.length; b++) if (S[b].options.id === a) return S[b]; for (b = 0; b < S.length; b++) {
        d = S[b].points ||
[]; for (c = 0; c < d.length; c++) if (d[c].id === a) return d[c]
    } return null
}; m.getSelectedPoints = function () { var a = []; o(S, function (b) { a = a.concat(oc(b.points, function (a) { return a.selected })) }); return a }; m.getSelectedSeries = function () { return oc(S, function (a) { return a.selected }) }; m.hideLoading = function () { vb && ac(vb, { opacity: 0 }, { duration: t.loading.hideDuration || 100, complete: function () { Q(vb, { display: Ka }) } }); ab = !1 }; m.initSeries = f; m.isInsidePlot = va; m.redraw = h; m.setSize = rb; m.setTitle = j; m.showLoading = function (a) {
    var b =
t.loading; vb || (vb = xa(Ea, { className: ib + "loading" }, N(b.style, { left: R + ga, top: L + ga, width: ja + ga, height: ha + ga, zIndex: 10, display: Ka }), H), sa = xa("span", null, b.labelStyle, vb)); sa.innerHTML = a || t.lang.loading; ab || (Q(vb, { opacity: 0, display: "" }), ac(vb, { opacity: b.style.opacity }, { duration: b.showDuration || 0 }), ab = !0)
}; m.pointCount = 0; m.counters = new uc; Z()
    } var V, B = document, U = window, na = Math, C = na.round, Sa = na.floor, Xb = na.ceil, X = na.max, Ta = na.min, ya = na.abs, $ = na.cos, ca = na.sin, ra = na.PI, Cc = ra * 2 / 360, va = navigator.userAgent, ob =
/msie/i.test(va) && !U.opera, ab = B.documentMode === 8, Dc = /AppleWebKit/.test(va), Ec = /Firefox/.test(va), Ob = !!B.createElementNS && !!B.createElementNS("http://www.w3.org/2000/svg", "svg").createSVGRect, Qc = Ec && parseInt(va.split("Firefox/")[1], 10) < 4, Fa = !Ob && !ob && !!B.createElement("canvas").getContext, Wb, Wa = B.documentElement.ontouchstart !== V, Fc = {}, lc = 0, zb, Ba, $b, Tb, kb, y, Ea = "div", ub = "absolute", mc = "relative", Za = "hidden", ib = "highcharts-", cb = "visible", ga = "px", Ka = "none", ta = "M", fa = "L", Gc = "rgba(192,192,192," + (Ob ? 1.0E-6 :
0.0020) + ")", Ja = "", Ga = "hover", ec = "millisecond", pb = "second", Pa = "minute", za = "hour", Ra = "day", oa = "week", sa = "month", ba = "year", sb, fc, gc, ic, Da, qb, rb, qc, rc, hc, sc, tc, D = U.HighchartsAdapter, ma = D || {}, Hc = ma.getScript, o = ma.each, oc = ma.grep, zc = ma.offset, Ub = ma.map, K = ma.merge, ka = ma.addEvent, Na = ma.removeEvent, aa = ma.fireEvent, Ac = ma.washMouseEvent, ac = ma.animate, Nb = ma.stop, Ha = {}; U.Highcharts = {}; $b = function (a, b, c) {
    if (!u(b) || isNaN(b)) return "Invalid date"; var a = r(a, "%Y-%m-%d %H:%M:%S"), d = new Date(b), e, f = d[gc](), g = d[ic](),
h = d[Da](), i = d[qb](), k = d[rb](), j = Ba.lang, l = j.weekdays, b = { a: l[g].substr(0, 3), A: l[g], d: Ca(h), e: h, b: j.shortMonths[i], B: j.months[i], m: Ca(i + 1), y: k.toString().substr(2, 2), Y: k, H: Ca(f), I: Ca(f % 12 || 12), l: f % 12 || 12, M: Ca(d[fc]()), p: f < 12 ? "AM" : "PM", P: f < 12 ? "am" : "pm", S: Ca(d.getSeconds()), L: Ca(C(b % 1E3), 3) }; for (e in b) a = a.replace("%" + e, b[e]); return c ? a.substr(0, 1).toUpperCase() + a.substr(1) : a
}; uc.prototype = { wrapColor: function (a) { if (this.color >= a) this.color = 0 }, wrapSymbol: function (a) { if (this.symbol >= a) this.symbol = 0 } }; y =
Ya(ec, 1, pb, 1E3, Pa, 6E4, za, 36E5, Ra, 864E5, oa, 6048E5, sa, 2592E6, ba, 31556952E3); kb = { init: function (a, b, c) {
    var b = b || "", d = a.shift, e = b.indexOf("C") > -1, f = e ? 7 : 3, g, b = b.split(" "), c = [].concat(c), h, i, k = function (a) { for (g = a.length; g--; ) a[g] === ta && a.splice(g + 1, 0, a[g + 1], a[g + 2], a[g + 1], a[g + 2]) }; e && (k(b), k(c)); a.isArea && (h = b.splice(b.length - 6, 6), i = c.splice(c.length - 6, 6)); if (d <= c.length / f) for (; d--; ) c = [].concat(c).splice(0, f).concat(c); a.shift = 0; if (b.length) for (a = c.length; b.length < a; ) d = [].concat(b).splice(b.length - f, f),
e && (d[f - 6] = d[f - 2], d[f - 5] = d[f - 1]), b = b.concat(d); h && (b = b.concat(h), c = c.concat(i)); return [b, c]
}, step: function (a, b, c, d) { var e = [], f = a.length; if (c === 1) e = d; else if (f === b.length && c < 1) for (; f--; ) d = parseFloat(a[f]), e[f] = isNaN(d) ? a[f] : c * parseFloat(b[f] - d) + d; else e = b; return e } 
}; D && D.init && D.init(kb); if (!D && U.jQuery) {
        var E = jQuery, Hc = E.getScript, o = function (a, b) { for (var c = 0, d = a.length; c < d; c++) if (b.call(a[c], a[c], c, a) === !1) return c }, oc = E.grep, Ub = function (a, b) {
            for (var c = [], d = 0, e = a.length; d < e; d++) c[d] = b.call(a[d], a[d],
d, a); return c
        }, K = function () { var a = arguments; return E.extend(!0, null, a[0], a[1], a[2], a[3]) }, zc = function (a) { return E(a).offset() }, ka = function (a, b, c) { E(a).bind(b, c) }, Na = function (a, b, c) { var d = B.removeEventListener ? "removeEventListener" : "detachEvent"; B[d] && !a[d] && (a[d] = function () { }); E(a).unbind(b, c) }, aa = function (a, b, c, d) {
            var e = E.Event(b), f = "detached" + b, g; N(e, c); a[b] && (a[f] = a[b], a[b] = null); o(["preventDefault", "stopPropagation"], function (a) {
                var b = e[a]; e[a] = function () {
                    try { b.call(e) } catch (c) {
                        a === "preventDefault" &&
(g = !0)
                    } 
                } 
            }); E(a).trigger(e); a[f] && (a[b] = a[f], a[f] = null); d && !e.isDefaultPrevented() && !g && d(e)
        }, Ac = function (a) { return a }, ac = function (a, b, c) { var d = E(a); if (b.d) a.toD = b.d, b.d = 1; d.stop(); d.animate(b, c) }, Nb = function (a) { E(a).stop() }; E.extend(E.easing, { easeOutQuad: function (a, b, c, d, e) { return -d * (b /= e) * (b - 2) + c } }); var Ic = jQuery.fx, Jc = Ic.step; o(["cur", "_default", "width", "height"], function (a, b) {
            var c = b ? Jc : Ic.prototype, d = c[a], e; d && (c[a] = function (a) {
                a = b ? a : this; e = a.elem; return e.attr ? e.attr(a.prop, a.now) : d.apply(this,
arguments)
            })
        }); Jc.d = function (a) { var b = a.elem; if (!a.started) { var c = kb.init(b, b.d, b.toD); a.start = c[0]; a.end = c[1]; a.started = !0 } b.attr("d", kb.step(a.start, a.end, a.pos, b.toD)) }
    } D = { enabled: !0, align: "center", x: 0, y: 15, style: { color: "#666", fontSize: "11px", lineHeight: "14px"} }; Ba = { colors: "#ff0000,#0000FF,#89A54E,#80699B,#3D96AE,#DB843D,#92A8CD,#A47D7C,#B5CA92".split(","), symbols: ["circle", "diamond", "square", "triangle", "triangle-down"], lang: { loading: "Loading...", months: "January,February,March,April,May,June,July,August,September,October,November,December".split(","),
        shortMonths: "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec".split(","), weekdays: "Sunday,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday".split(","), decimalPoint: ".", resetZoom: "Reset zoom", resetZoomTitle: "Reset zoom level 1:1", thousandsSep: ","
    }, global: { useUTC: !0, canvasToolsURL: "http://code.highcharts.com/2.2.3/modules/canvas-tools.js" }, chart: { borderColor: "#4572A7", borderRadius: 5, defaultSeriesType: "line", ignoreHiddenSeries: !0, spacingTop: 10, spacingRight: 10, spacingBottom: 15, spacingLeft: 10, style: { fontFamily: '"Lucida Grande", "Lucida Sans Unicode", Verdana, Arial, Helvetica, sans-serif',
        fontSize: "12px"
    }, backgroundColor: "#FFFFFF", plotBorderColor: "#C0C0C0", resetZoomButton: { theme: { zIndex: 20 }, position: { align: "right", x: -10, y: 10}}
    }, title: { text: "Chart title", align: "center", y: 15, style: { color: "#3E576F", fontSize: "16px"} }, subtitle: { text: "", align: "center", y: 30, style: { color: "#6D869F"} }, plotOptions: { line: { allowPointSelect: !1, showCheckbox: !1, animation: { duration: 1E3 }, events: {}, lineWidth: 2, shadow: !0, marker: { enabled: !0, lineWidth: 0, radius: 4, lineColor: "#FFFFFF", states: { hover: {}, select: { fillColor: "#FFFFFF",
        lineColor: "#000000", lineWidth: 2
    }
    }
    }, point: { events: {} }, dataLabels: K(D, { enabled: !1, y: -6, formatter: function () { return this.y } }), cropThreshold: 300, pointRange: 0, showInLegend: !0, states: { hover: { marker: {} }, select: { marker: {}} }, stickyTracking: !0
    }
    }, labels: { style: { position: ub, color: "#3E576F"} }, legend: { enabled: !0, align: "center", layout: "horizontal", labelFormatter: function () { return this.name }, borderWidth: 1, borderColor: "#909090", borderRadius: 5, shadow: !1, style: { padding: "5px" }, itemStyle: { cursor: "pointer", color: "#3E576F" },
        itemHoverStyle: { color: "#000000" }, itemHiddenStyle: { color: "#C0C0C0" }, itemCheckboxStyle: { position: ub, width: "13px", height: "13px" }, symbolWidth: 16, symbolPadding: 5, verticalAlign: "bottom", x: 0, y: 0
    }, loading: { labelStyle: { fontWeight: "bold", position: mc, top: "1em" }, style: { position: ub, backgroundColor: "white", opacity: 0.5, textAlign: "center"} }, tooltip: { enabled: !0, backgroundColor: "rgba(255, 255, 255, .85)", borderWidth: 2, borderRadius: 5, headerFormat: '<span style="font-size: 10px">{point.key}</span><br/>', pointFormat: '<span style="color:{series.color}">{series.name}</span>: <b>{point.y}</b><br/>',
        shadow: !0, shared: Fa, snap: Wa ? 25 : 10, style: { color: "#333333", fontSize: "12px", padding: "5px", whiteSpace: "nowrap"}
    }, credits: { enabled: !0, text: "pinble.com", href: "http://www.pinble.com", position: { align: "right", x: -10, verticalAlign: "bottom", y: -5 }, style: { cursor: "pointer", color: "#909090", fontSize: "10px"}}
    }; var Zb = { dateTimeLabelFormats: Ya(ec, "%H:%M:%S.%L", pb, "%H:%M:%S", Pa, "%H:%M", za, "%H:%M", Ra, "%e. %b", oa, "%e. %b", sa, "%b '%y", ba, "%Y"), endOnTick: !1, gridLineColor: "#C0C0C0", labels: D, lineColor: "#C0D0E0", lineWidth: 1,
        max: null, min: null, minPadding: 0.01, maxPadding: 0.01, minorGridLineColor: "#E0E0E0", minorGridLineWidth: 1, minorTickColor: "#A0A0A0", minorTickLength: 2, minorTickPosition: "outside", startOfWeek: 1, startOnTick: !1, tickColor: "#C0D0E0", tickLength: 5, tickmarkPlacement: "between", tickPixelInterval: 100, tickPosition: "outside", tickWidth: 1, title: { align: "middle", style: { color: "#6D869F", fontWeight: "bold"} }, type: "linear"
    }, kc = K(Zb, { endOnTick: !0, gridLineWidth: 1, tickPixelInterval: 72, showLastLabel: !0, labels: { align: "right", x: -8,
        y: 3
    }, lineWidth: 0, maxPadding: 0.05, minPadding: 0.05, startOnTick: !0, tickWidth: 0, title: { rotation: 270, text: "Y-values" }, stackLabels: { enabled: !1, formatter: function () { return this.total }, style: D.style}
    }), Pc = { labels: { align: "right", x: -8, y: null }, title: { rotation: 270} }, Oc = { labels: { align: "left", x: 8, y: null }, title: { rotation: 90} }, yc = { labels: { align: "center", x: 0, y: 14 }, title: { rotation: 0} }, Nc = K(yc, { labels: { y: -5, overflow: "justify"} }), Aa = Ba.plotOptions, D = Aa.line; Aa.spline = K(D); Aa.scatter = K(D, { lineWidth: 0, states: { hover: { lineWidth: 0} },
        tooltip: { headerFormat: '<span style="font-size: 10px; color:{series.color}">{series.name}</span><br/>', pointFormat: "x: <b>{point.x}</b><br/>y: <b>{point.y}</b><br/>"}
    }); Aa.area = K(D, { threshold: 0 }); Aa.areaspline = K(Aa.area); Aa.column = K(D, { borderColor: "#FFFFFF", borderWidth: 1, borderRadius: 0, groupPadding: 0.2, marker: null, pointPadding: 0.1, minPointLength: 0, cropThreshold: 50, pointRange: null, states: { hover: { brightness: 0.1, shadow: !1 }, select: { color: "#C0C0C0", borderColor: "#000000", shadow: !1} }, dataLabels: { y: null, verticalAlign: null },
        threshold: 0
    }); Aa.bar = K(Aa.column, { dataLabels: { align: "left", x: 5, y: null, verticalAlign: "middle"} }); Aa.pie = K(D, { borderColor: "#FFFFFF", borderWidth: 1, center: ["50%", "50%"], colorByPoint: !0, dataLabels: { distance: 30, enabled: !0, formatter: function () { return this.point.name }, y: 5 }, legendType: "point", marker: null, size: "75%", showInLegend: !1, slicedOffset: 10, states: { hover: { brightness: 0.1, shadow: !1}} }); wc(); var Oa = function (a) {
        var b = [], c; (function (a) {
            (c = /rgba\(\s*([0-9]{1,3})\s*,\s*([0-9]{1,3})\s*,\s*([0-9]{1,3})\s*,\s*([0-9]?(?:\.[0-9]+)?)\s*\)/.exec(a)) ?
b = [T(c[1]), T(c[2]), T(c[3]), parseFloat(c[4], 10)] : (c = /#([a-fA-F0-9]{2})([a-fA-F0-9]{2})([a-fA-F0-9]{2})/.exec(a)) && (b = [T(c[1], 16), T(c[2], 16), T(c[3], 16), 1])
        })(a); return { get: function (c) { return b && !isNaN(b[0]) ? c === "rgb" ? "rgb(" + b[0] + "," + b[1] + "," + b[2] + ")" : c === "a" ? b[3] : "rgba(" + b.join(",") + ")" : a }, brighten: function (a) { if (mb(a) && a !== 0) { var c; for (c = 0; c < 3; c++) b[c] += T(a * 255), b[c] < 0 && (b[c] = 0), b[c] > 255 && (b[c] = 255) } return this }, setOpacity: function (a) { b[3] = a; return this } }
    }; fb.prototype = { init: function (a, b) {
        this.element =
b === "span" ? xa(b) : B.createElementNS("http://www.pinble.com", b); this.renderer = a; this.attrSetters = {}
    }, animate: function (a, b, c) { b = r(b, Tb, !0); Nb(this); if (b) { b = K(b); if (c) b.complete = c; ac(this, a, b) } else this.attr(a), c && c() }, attr: function (a, b) {
        var c, d, e, f, g = this.element, h = g.nodeName, i = this.renderer, k, j = this.attrSetters, l = this.shadows, n, p = this; yb(a) && u(b) && (c = a, a = {}, a[c] = b); if (yb(a)) c = a, h === "circle" ? c = { x: "cx", y: "cy"}[c] || c : c === "strokeWidth" && (c = "stroke-width"), p = A(g, c) || this[c] || 0, c !== "d" && c !== "visibility" &&
(p = parseFloat(p)); else for (c in a) if (k = !1, d = a[c], e = j[c] && j[c](d, c), e !== !1) {
            e !== V && (d = e); if (c === "d") d && d.join && (d = d.join(" ")), /(NaN| {2}|^$)/.test(d) && (d = "M 0 0"), this.d = d; else if (c === "x" && h === "text") { for (e = 0; e < g.childNodes.length; e++) f = g.childNodes[e], A(f, "x") === A(g, "x") && A(f, "x", d); this.rotation && A(g, "transform", "rotate(" + this.rotation + " " + d + " " + T(a.y || A(g, "y")) + ")") } else if (c === "fill") d = i.color(d, g, c); else if (h === "circle" && (c === "x" || c === "y")) c = { x: "cx", y: "cy"}[c] || c; else if (h === "rect" && c === "r") A(g,
{ rx: d, ry: d }), k = !0; else if (c === "translateX" || c === "translateY" || c === "rotation" || c === "verticalAlign") this[c] = d, this.updateTransform(), k = !0; else if (c === "stroke") d = i.color(d, g, c); else if (c === "dashstyle") if (c = "stroke-dasharray", d = d && d.toLowerCase(), d === "solid") d = Ka; else {
                if (d) {
                    d = d.replace("shortdashdotdot", "3,1,1,1,1,1,").replace("shortdashdot", "3,1,1,1").replace("shortdot", "1,1,").replace("shortdash", "3,1,").replace("longdash", "8,3,").replace(/dot/g, "1,3,").replace("dash", "4,3,").replace(/,$/, "").split(",");
                    for (e = d.length; e--; ) d[e] = T(d[e]) * a["stroke-width"]; d = d.join(",")
                } 
            } else if (c === "isTracker") this[c] = d; else if (c === "width") d = T(d); else if (c === "align") c = "text-anchor", d = { left: "start", center: "middle", right: "end"}[d]; else if (c === "title") e = g.getElementsByTagName("title")[0], e || (e = B.createElementNS("http://www.w3.org/2000/svg", "title"), g.appendChild(e)), e.textContent = d; c === "strokeWidth" && (c = "stroke-width"); Dc && c === "stroke-width" && d === 0 && (d = 1.0E-6); this.symbolName && /^(x|y|width|height|r|start|end|innerR|anchorX|anchorY)/.test(c) &&
(n || (this.symbolAttr(a), n = !0), k = !0); if (l && /^(width|height|visibility|x|y|d|transform)$/.test(c)) for (e = l.length; e--; ) A(l[e], c, d); if ((c === "width" || c === "height") && h === "rect" && d < 0) d = 0; c === "text" ? (this.textStr = d, this.added && i.buildText(this)) : k || A(g, c, d)
        } if (Dc && /Chrome\/(18|19)/.test(va) && h === "text" && (a.x !== V || a.y !== V)) c = g.parentNode, d = g.nextSibling, c && (c.removeChild(g), d ? c.insertBefore(g, d) : c.appendChild(g)); return p
    }, symbolAttr: function (a) {
        var b = this; o("x,y,r,start,end,width,height,innerR,anchorX,anchorY".split(","),
function (c) { b[c] = r(a[c], b[c]) }); b.attr({ d: b.renderer.symbols[b.symbolName](b.x, b.y, b.width, b.height, b) })
    }, clip: function (a) { return this.attr("clip-path", "url(" + this.renderer.url + "#" + a.id + ")") }, crisp: function (a, b, c, d, e) { var f, g = {}, h = {}, i, a = a || this.strokeWidth || this.attr && this.attr("stroke-width") || 0; i = C(a) % 2 / 2; h.x = Sa(b || this.x || 0) + i; h.y = Sa(c || this.y || 0) + i; h.width = Sa((d || this.width || 0) - 2 * i); h.height = Sa((e || this.height || 0) - 2 * i); h.strokeWidth = a; for (f in h) this[f] !== h[f] && (this[f] = g[f] = h[f]); return g },
        css: function (a) { var b = this.element, b = a && a.width && b.nodeName === "text", c, d = "", e = function (a, b) { return "-" + b.toLowerCase() }; if (a && a.color) a.fill = a.color; this.styles = a = N(this.styles, a); if (ob && !Ob) b && delete a.width, Q(this.element, a); else { for (c in a) d += c.replace(/([A-Z])/g, e) + ":" + a[c] + ";"; this.attr({ style: d }) } b && this.added && this.renderer.buildText(this); return this }, on: function (a, b) { var c = b; Wa && a === "click" && (a = "touchstart", c = function (a) { a.preventDefault(); b() }); this.element["on" + a] = c; return this }, translate: function (a,
b) { return this.attr({ translateX: a, translateY: b }) }, invert: function () { this.inverted = !0; this.updateTransform(); return this }, htmlCss: function (a) { var b = this.element; if (b = a && b.tagName === "SPAN" && a.width) delete a.width, this.textWidth = b, this.updateTransform(); this.styles = N(this.styles, a); Q(this.element, a); return this }, htmlGetBBox: function (a) { var b = this.element, c = this.bBox; if (!c || a) { if (b.nodeName === "text") b.style.position = ub; c = this.bBox = { x: b.offsetLeft, y: b.offsetTop, width: b.offsetWidth, height: b.offsetHeight} } return c },
        htmlUpdateTransform: function () {
            if (this.added) {
                var a = this.renderer, b = this.element, c = this.translateX || 0, d = this.translateY || 0, e = this.x || 0, f = this.y || 0, g = this.textAlign || "left", h = { left: 0, center: 0.5, right: 1}[g], i = g && g !== "left", k = this.shadows; if (c || d) Q(b, { marginLeft: c, marginTop: d }), k && o(k, function (a) { Q(a, { marginLeft: c + 1, marginTop: d + 1 }) }); this.inverted && o(b.childNodes, function (c) { a.invertChild(c, b) }); if (b.tagName === "SPAN") {
                    var j, l, k = this.rotation, n; j = 0; var p = 1, v = 0, Z; n = T(this.textWidth); var t = this.xCorr ||
0, w = this.yCorr || 0, s = [k, g, b.innerHTML, this.textWidth].join(","); if (s !== this.cTT) u(k) && (j = k * Cc, p = $(j), v = ca(j), Q(b, { filter: k ? ["progid:DXImageTransform.Microsoft.Matrix(M11=", p, ", M12=", -v, ", M21=", v, ", M22=", p, ", sizingMethod='auto expand')"].join("") : Ka })), j = r(this.elemWidth, b.offsetWidth), l = r(this.elemHeight, b.offsetHeight), j > n && (Q(b, { width: n + ga, display: "block", whiteSpace: "normal" }), j = n), n = a.fontMetrics(b.style.fontSize).b, t = p < 0 && -j, w = v < 0 && -l, Z = p * v < 0, t += v * n * (Z ? 1 - h : h), w -= p * n * (k ? Z ? h : 1 - h : 1), i && (t -= j *
h * (p < 0 ? -1 : 1), k && (w -= l * h * (v < 0 ? -1 : 1)), Q(b, { textAlign: g })), this.xCorr = t, this.yCorr = w; Q(b, { left: e + t + ga, top: f + w + ga }); this.cTT = s
                } 
            } else this.alignOnAdd = !0
        }, updateTransform: function () { var a = this.translateX || 0, b = this.translateY || 0, c = this.inverted, d = this.rotation, e = []; c && (a += this.attr("width"), b += this.attr("height")); (a || b) && e.push("translate(" + a + "," + b + ")"); c ? e.push("rotate(90) scale(-1,1)") : d && e.push("rotate(" + d + " " + this.x + " " + this.y + ")"); e.length && A(this.element, "transform", e.join(" ")) }, toFront: function () {
            var a =
this.element; a.parentNode.appendChild(a); return this
        }, align: function (a, b, c) {
            a ? (this.alignOptions = a, this.alignByTranslate = b, c || this.renderer.alignedObjects.push(this)) : (a = this.alignOptions, b = this.alignByTranslate); var c = r(c, this.renderer), d = a.align, e = a.verticalAlign, f = (c.x || 0) + (a.x || 0), g = (c.y || 0) + (a.y || 0), h = {}; /^(right|center)$/.test(d) && (f += (c.width - (a.width || 0)) / { right: 1, center: 2}[d]); h[b ? "translateX" : "x"] = C(f); /^(bottom|middle)$/.test(e) && (g += (c.height - (a.height || 0)) / ({ bottom: 1, middle: 2}[e] || 1));
            h[b ? "translateY" : "y"] = C(g); this[this.placed ? "animate" : "attr"](h); this.placed = !0; this.alignAttr = h; return this
        }, getBBox: function (a) { var b, c, d = this.rotation; c = this.element; var e = d * Cc; if (c.namespaceURI === "http://www.w3.org/2000/svg") { try { b = c.getBBox ? N({}, c.getBBox()) : { width: c.offsetWidth, height: c.offsetHeight} } catch (f) { } if (!b || b.width < 0) b = { width: 0, height: 0 }; a = b.width; c = b.height; if (d) b.width = ya(c * ca(e)) + ya(a * $(e)), b.height = ya(c * $(e)) + ya(a * ca(e)) } else b = this.htmlGetBBox(a); return b }, show: function () { return this.attr({ visibility: cb }) },
        hide: function () { return this.attr({ visibility: Za }) }, add: function (a) { var b = this.renderer, c = a || b, d = c.element || b.box, e = d.childNodes, f = this.element, g = A(f, "zIndex"), h; this.parentInverted = a && a.inverted; this.textStr !== void 0 && b.buildText(this); if (g) c.handleZ = !0, g = T(g); if (c.handleZ) for (c = 0; c < e.length; c++) if (a = e[c], b = A(a, "zIndex"), a !== f && (T(b) > g || !u(g) && u(b))) { d.insertBefore(f, a); h = !0; break } h || d.appendChild(f); this.added = !0; aa(this, "add"); return this }, safeRemoveChild: function (a) { var b = a.parentNode; b && b.removeChild(a) },
        destroy: function () { var a = this, b = a.element || {}, c = a.shadows, d = a.box, e, f; b.onclick = b.onmouseout = b.onmouseover = b.onmousemove = null; Nb(a); if (a.clipPath) a.clipPath = a.clipPath.destroy(); if (a.stops) { for (f = 0; f < a.stops.length; f++) a.stops[f] = a.stops[f].destroy(); a.stops = null } a.safeRemoveChild(b); c && o(c, function (b) { a.safeRemoveChild(b) }); d && d.destroy(); Eb(a.renderer.alignedObjects, a); for (e in a) delete a[e]; return null }, empty: function () { for (var a = this.element, b = a.childNodes, c = b.length; c--; ) a.removeChild(b[c]) },
        shadow: function (a, b) { var c = [], d, e, f = this.element, g = this.parentInverted ? "(-1,-1)" : "(1,1)"; if (a) { for (d = 1; d <= 3; d++) e = f.cloneNode(0), A(e, { isShadow: "true", stroke: "rgb(0, 0, 0)", "stroke-opacity": 0.05 * d, "stroke-width": 7 - 2 * d, transform: "translate" + g, fill: Ka }), b ? b.element.appendChild(e) : f.parentNode.insertBefore(e, f), c.push(e); this.shadows = c } return this } 
    }; var Cb = function () { this.init.apply(this, arguments) }; Cb.prototype = { Element: fb, init: function (a, b, c, d) {
        var e = location, f; f = this.createElement("svg").attr({ xmlns: "http://www.w3.org/2000/svg",
            version: "1.1"
        }); a.appendChild(f.element); this.isSVG = !0; this.box = f.element; this.boxWrapper = f; this.alignedObjects = []; this.url = ob ? "" : e.href.replace(/#.*?$/, "").replace(/([\('\)])/g, "\\$1"); this.defs = this.createElement("defs").add(); this.forExport = d; this.gradients = {}; this.setSize(b, c, !1); var g; if (Ec && a.getBoundingClientRect) this.subPixelFix = b = function () { Q(a, { left: 0, top: 0 }); g = a.getBoundingClientRect(); Q(a, { left: -(g.left - T(g.left)) + ga, top: -(g.top - T(g.top)) + ga }) }, b(), ka(U, "resize", b)
    }, destroy: function () {
        var a =
this.defs; this.box = null; this.boxWrapper = this.boxWrapper.destroy(); Hb(this.gradients || {}); this.gradients = null; if (a) this.defs = a.destroy(); Na(U, "resize", this.subPixelFix); return this.alignedObjects = null
    }, createElement: function (a) { var b = new this.Element; b.init(this, a); return b }, draw: function () { }, buildText: function (a) {
        for (var b = a.element, c = r(a.textStr, "").toString().replace(/<(b|strong)>/g, '<span style="font-weight:bold">').replace(/<(i|em)>/g, '<span style="font-style:italic">').replace(/<a/g, "<span").replace(/<\/(b|strong|i|em|a)>/g,
"</span>").split(/<br.*?>/g), d = b.childNodes, e = /style="([^"]+)"/, f = /href="([^"]+)"/, g = A(b, "x"), h = a.styles, i = h && T(h.width), k = h && h.lineHeight, j, h = d.length, l = []; h--; ) b.removeChild(d[h]); i && !a.added && this.box.appendChild(b); c[c.length - 1] === "" && c.pop(); o(c, function (c, d) {
    var h, r = 0, t, c = c.replace(/<span/g, "|||<span").replace(/<\/span>/g, "</span>|||"); h = c.split("|||"); o(h, function (c) {
        if (c !== "" || h.length === 1) {
            var n = {}, o = B.createElementNS("http://www.w3.org/2000/svg", "tspan"); e.test(c) && A(o, "style", c.match(e)[1].replace(/(;| |^)color([ :])/,
"$1fill$2")); f.test(c) && (A(o, "onclick", 'location.href="' + c.match(f)[1] + '"'), Q(o, { cursor: "pointer" })); c = (c.replace(/<(.|\n)*?>/g, "") || " ").replace(/&lt;/g, "<").replace(/&gt;/g, ">"); o.appendChild(B.createTextNode(c)); r ? n.dx = 3 : n.x = g; if (!r) {
                if (d) { !Ob && a.renderer.forExport && Q(o, { display: "block" }); t = U.getComputedStyle && T(U.getComputedStyle(j, null).getPropertyValue("line-height")); if (!t || isNaN(t)) { var z; if (!(z = k)) if (!(z = j.offsetHeight)) l[d] = b.getBBox().height, z = C(l[d] - (l[d - 1] || 0)) || 18; t = z } A(o, "dy", t) } j =
o
            } A(o, n); b.appendChild(o); r++; if (i) for (var c = c.replace(/-/g, "- ").split(" "), u = []; c.length || u.length; ) z = a.getBBox().width, n = z > i, !n || c.length === 1 ? (c = u, u = [], c.length && (o = B.createElementNS("http://www.w3.org/2000/svg", "tspan"), A(o, { dy: k || 16, x: g }), b.appendChild(o), z > i && (i = z))) : (o.removeChild(o.firstChild), u.unshift(c.pop())), c.length && o.appendChild(B.createTextNode(c.join(" ").replace(/- /g, "-")))
        } 
    })
})
    }, button: function (a, b, c, d, e, f, g) {
        var h = this.label(a, b, c), i = 0, k, j, l, n, p, a = { x1: 0, y1: 0, x2: 0, y2: 1 }, e = K(Ya("stroke-width",
1, "stroke", "#999", "fill", Ya("linearGradient", a, "stops", [[0, "#FFF"], [1, "#DDD"]]), "r", 3, "padding", 3, "style", Ya("color", "black")), e); l = e.style; delete e.style; f = K(e, Ya("stroke", "#68A", "fill", Ya("linearGradient", a, "stops", [[0, "#FFF"], [1, "#ACF"]])), f); n = f.style; delete f.style; g = K(e, Ya("stroke", "#68A", "fill", Ya("linearGradient", a, "stops", [[0, "#9BD"], [1, "#CDF"]])), g); p = g.style; delete g.style; ka(h.element, "mouseenter", function () { h.attr(f).css(n) }); ka(h.element, "mouseleave", function () {
    k = [e, f, g][i]; j = [l, n, p][i];
    h.attr(k).css(j)
}); h.setState = function (a) { (i = a) ? a === 2 && h.attr(g).css(p) : h.attr(e).css(l) }; return h.on("click", function () { d.call(h) }).attr(e).css(N({ cursor: "default" }, l))
    }, crispLine: function (a, b) { a[1] === a[4] && (a[1] = a[4] = C(a[1]) + b % 2 / 2); a[2] === a[5] && (a[2] = a[5] = C(a[2]) + b % 2 / 2); return a }, path: function (a) { return this.createElement("path").attr({ d: a, fill: Ka }) }, circle: function (a, b, c) { a = lb(a) ? a : { x: a, y: b, r: c }; return this.createElement("circle").attr(a) }, arc: function (a, b, c, d, e, f) {
        if (lb(a)) b = a.y, c = a.r, d = a.innerR,
e = a.start, f = a.end, a = a.x; return this.symbol("arc", a || 0, b || 0, c || 0, c || 0, { innerR: d || 0, start: e || 0, end: f || 0 })
    }, rect: function (a, b, c, d, e, f) { if (lb(a)) b = a.y, c = a.width, d = a.height, e = a.r, f = a.strokeWidth, a = a.x; e = this.createElement("rect").attr({ rx: e, ry: e, fill: Ka }); return e.attr(e.crisp(f, a, b, X(c, 0), X(d, 0))) }, setSize: function (a, b, c) { var d = this.alignedObjects, e = d.length; this.width = a; this.height = b; for (this.boxWrapper[r(c, !0) ? "animate" : "attr"]({ width: a, height: b }); e--; ) d[e].align() }, g: function (a) {
        var b = this.createElement("g");
        return u(a) ? b.attr({ "class": ib + a }) : b
    }, image: function (a, b, c, d, e) { var f = { preserveAspectRatio: Ka }; arguments.length > 1 && N(f, { x: b, y: c, width: d, height: e }); f = this.createElement("image").attr(f); f.element.setAttributeNS ? f.element.setAttributeNS("http://www.w3.org/1999/xlink", "href", a) : f.element.setAttribute("hc-svg-href", a); return f }, symbol: function (a, b, c, d, e, f) {
        var g, h = this.symbols[a], h = h && h(C(b), C(c), d, e, f), i = /^url\((.*?)\)$/, k, j; h ? (g = this.path(h), N(g, { symbolName: a, x: b, y: c, width: d, height: e }), f && N(g, f)) : i.test(a) &&
(j = function (a, b) { a.attr({ width: b[0], height: b[1] }); a.alignByTranslate || a.translate(-C(b[0] / 2), -C(b[1] / 2)) }, k = a.match(i)[1], a = Fc[k], g = this.image(k).attr({ x: b, y: c }), a ? j(g, a) : (g.attr({ width: 0, height: 0 }), xa("img", { onload: function () { j(g, Fc[k] = [this.width, this.height]) }, src: k }))); return g
    }, symbols: { circle: function (a, b, c, d) { var e = 0.166 * c; return [ta, a + c / 2, b, "C", a + c + e, b, a + c + e, b + d, a + c / 2, b + d, "C", a - e, b + d, a - e, b, a + c / 2, b, "Z"] }, square: function (a, b, c, d) { return [ta, a, b, fa, a + c, b, a + c, b + d, a, b + d, "Z"] }, triangle: function (a,
b, c, d) { return [ta, a + c / 2, b, fa, a + c, b + d, a, b + d, "Z"] }, "triangle-down": function (a, b, c, d) { return [ta, a, b, fa, a + c, b, a + c / 2, b + d, "Z"] }, diamond: function (a, b, c, d) { return [ta, a + c / 2, b, fa, a + c, b + d / 2, a + c / 2, b + d, a, b + d / 2, "Z"] }, arc: function (a, b, c, d, e) { var f = e.start, c = e.r || c || d, g = e.end - 1.0E-6, d = e.innerR, h = $(f), i = ca(f), k = $(g), g = ca(g), e = e.end - f < ra ? 0 : 1; return [ta, a + c * h, b + c * i, "A", c, c, 0, e, 1, a + c * k, b + c * g, fa, a + d * k, b + d * g, "A", d, d, 0, e, 0, a + d * h, b + d * i, "Z"] } 
    }, clipRect: function (a, b, c, d) {
        var e = ib + lc++, f = this.createElement("clipPath").attr({ id: e }).add(this.defs),
a = this.rect(a, b, c, d, 0).add(f); a.id = e; a.clipPath = f; return a
    }, color: function (a, b, c) {
        var d, e = /^rgba/; if (a && a.linearGradient) {
            var f = this, g = a.linearGradient, b = !bc(g), c = f.gradients, h, i = g.x1 || g[0] || 0, k = g.y1 || g[1] || 0, j = g.x2 || g[2] || 0, l = g.y2 || g[3] || 0, n, p, v = [b, i, k, j, l, a.stops.join(",")].join(","); c[v] ? g = A(c[v].element, "id") : (g = ib + lc++, h = f.createElement("linearGradient").attr(N({ id: g, x1: i, y1: k, x2: j, y2: l }, b ? null : { gradientUnits: "userSpaceOnUse" })).add(f.defs), h.stops = [], o(a.stops, function (a) {
                e.test(a[1]) ? (d = Oa(a[1]),
n = d.get("rgb"), p = d.get("a")) : (n = a[1], p = 1); a = f.createElement("stop").attr({ offset: a[0], "stop-color": n, "stop-opacity": p }).add(h); h.stops.push(a)
            }), c[v] = h); return "url(" + this.url + "#" + g + ")"
        } else return e.test(a) ? (d = Oa(a), A(b, c + "-opacity", d.get("a")), d.get("rgb")) : (b.removeAttribute(c + "-opacity"), a)
    }, text: function (a, b, c, d) {
        var e = Ba.chart.style; if (d && !this.forExport) return this.html(a, b, c); b = C(r(b, 0)); c = C(r(c, 0)); a = this.createElement("text").attr({ x: b, y: c, text: a }).css({ fontFamily: e.fontFamily, fontSize: e.fontSize });
        a.x = b; a.y = c; return a
    }, html: function (a, b, c) {
        var d = Ba.chart.style, e = this.createElement("span"), f = e.attrSetters, g = e.element, h = e.renderer; f.text = function (a) { g.innerHTML = a; return !1 }; f.x = f.y = f.align = function (a, b) { b === "align" && (b = "textAlign"); e[b] = a; e.htmlUpdateTransform(); return !1 }; e.attr({ text: a, x: C(b), y: C(c) }).css({ position: ub, whiteSpace: "nowrap", fontFamily: d.fontFamily, fontSize: d.fontSize }); e.css = e.htmlCss; if (h.isSVG) e.add = function (a) {
            var b, c, d = h.box.parentNode; if (a) {
                if (b = a.div, !b) b = a.div = xa(Ea, { className: A(a.element,
"class")
                }, { position: ub, left: a.attr("translateX") + ga, top: a.attr("translateY") + ga }, d), c = b.style, N(a.attrSetters, { translateX: function (a) { c.left = a + ga }, translateY: function (a) { c.top = a + ga }, visibility: function (a, b) { c[b] = a } })
            } else b = d; b.appendChild(g); e.added = !0; e.alignOnAdd && e.htmlUpdateTransform(); return e
        }; return e
    }, fontMetrics: function (a) { var a = T(a || 11), a = a < 24 ? a + 4 : C(a * 1.2), b = C(a * 0.8); return { h: a, b: b} }, label: function (a, b, c, d, e, f, g, h, i) {
        function k() {
            var a = p.styles, a = a && a.textAlign, b = s * (1 - w), c; c = h ? 0 : $a; if (u(Y) &&
(a === "center" || a === "right")) b += { center: 0.5, right: 1}[a] * (Y - t.width); (b !== v.x || c !== v.y) && v.attr({ x: b, y: c }); v.x = b; v.y = c
        } function j(a, b) { r ? r.attr(a, b) : E[a] = b } function l() { p.attr({ text: a, x: b, y: c, anchorX: e, anchorY: f }) } var n = this, p = n.g(i), v = n.text("", 0, 0, g).attr({ zIndex: 1 }).add(p), r, t, w = 0, s = 3, Y, z, y, A, D = 0, E = {}, $a, g = p.attrSetters; ka(p, "add", l); g.width = function (a) { Y = a; return !1 }; g.height = function (a) { z = a; return !1 }; g.padding = function (a) { u(a) && a !== s && (s = a, k()); return !1 }; g.align = function (a) {
            w = { left: 0, center: 0.5,
                right: 1
            }[a]; return !1
        }; g.text = function (a, b) { v.attr(b, a); var c; c = v.element.style; t = (Y === void 0 || z === void 0 || p.styles.textAlign) && v.getBBox(!0); p.width = (Y || t.width || 0) + 2 * s; p.height = (z || t.height || 0) + 2 * s; $a = s + n.fontMetrics(c && c.fontSize).b; if (!r) c = h ? -$a : 0, p.box = r = d ? n.symbol(d, -w * s, c, p.width, p.height) : n.rect(-w * s, c, p.width, p.height, 0, E["stroke-width"]), r.add(p); r.attr(K({ width: p.width, height: p.height }, E)); E = null; k(); return !1 }; g["stroke-width"] = function (a, b) { D = a % 2 / 2; j(b, a); return !1 }; g.stroke = g.fill = g.r =
function (a, b) { j(b, a); return !1 }; g.anchorX = function (a, b) { e = a; j(b, a + D - y); return !1 }; g.anchorY = function (a, b) { f = a; j(b, a - A); return !1 }; g.x = function (a) { p.x = a; a -= w * ((Y || t.width) + s); y = C(a); p.attr("translateX", y); return !1 }; g.y = function (a) { A = p.y = C(a); p.attr("translateY", a); return !1 }; var B = p.css; return N(p, { css: function (a) { if (a) { var b = {}, a = K({}, a); o("fontSize,fontWeight,fontFamily,color,lineHeight,width".split(","), function (c) { a[c] !== V && (b[c] = a[c], delete a[c]) }); v.css(b) } return B.call(p, a) }, getBBox: function () { return r.getBBox() },
    shadow: function (a) { r.shadow(a); return p }, destroy: function () { Na(p, "add", l); Na(p.element, "mouseenter"); Na(p.element, "mouseleave"); v && (v = v.destroy()); fb.prototype.destroy.call(p) } 
})
    } 
    }; Wb = Cb; var wa; if (!Ob && !Fa) wa = { init: function (a, b) {
        var c = ["<", b, ' filled="f" stroked="f"'], d = ["position: ", ub, ";"]; (b === "shape" || b === Ea) && d.push("left:0;top:0;width:10px;height:10px;"); ab && d.push("visibility: ", b === Ea ? Za : cb); c.push(' style="', d.join(""), '"/>'); if (b) c = b === Ea || b === "span" || b === "img" ? c.join("") : a.prepVML(c), this.element =
xa(c); this.renderer = a; this.attrSetters = {}
    }, add: function (a) { var b = this.renderer, c = this.element, d = b.box, d = a ? a.element || a : d; a && a.inverted && b.invertChild(c, d); ab && d.gVis === Za && Q(c, { visibility: Za }); d.appendChild(c); this.added = !0; this.alignOnAdd && !this.deferUpdateTransform && this.updateTransform(); aa(this, "add"); return this }, toggleChildren: function (a, b) { for (var c = a.childNodes, d = c.length; d--; ) Q(c[d], { visibility: b }), c[d].nodeName === "DIV" && this.toggleChildren(c[d], b) }, updateTransform: fb.prototype.htmlUpdateTransform,
        attr: function (a, b) {
            var c, d, e, f = this.element || {}, g = f.style, h = f.nodeName, i = this.renderer, k = this.symbolName, j, l = this.shadows, n, p = this.attrSetters, o = this; yb(a) && u(b) && (c = a, a = {}, a[c] = b); if (yb(a)) c = a, o = c === "strokeWidth" || c === "stroke-width" ? this.strokeweight : this[c]; else for (c in a) if (d = a[c], n = !1, e = p[c] && p[c](d, c), e !== !1 && d !== null) {
                e !== V && (d = e); if (k && /^(x|y|r|start|end|width|height|innerR|anchorX|anchorY)/.test(c)) j || (this.symbolAttr(a), j = !0), n = !0; else if (c === "d") {
                    d = d || []; this.d = d.join(" "); e = d.length; for (n =
[]; e--; ) n[e] = mb(d[e]) ? C(d[e] * 10) - 5 : d[e] === "Z" ? "x" : d[e]; d = n.join(" ") || "x"; f.path = d; if (l) for (e = l.length; e--; ) l[e].path = d; n = !0
                } else if (c === "zIndex" || c === "visibility") { if (ab && c === "visibility" && h === "DIV") f.gVis = d, this.toggleChildren(f, d), d === cb && (d = null); d && (g[c] = d); n = !0 } else if (c === "width" || c === "height") d = X(0, d), this[c] = d, this.updateClipping ? (this[c] = d, this.updateClipping()) : g[c] = d, n = !0; else if (c === "x" || c === "y") this[c] = d, g[{ x: "left", y: "top"}[c]] = d; else if (c === "class") f.className = d; else if (c === "stroke") d =
i.color(d, f, c), c = "strokecolor"; else if (c === "stroke-width" || c === "strokeWidth") f.stroked = d ? !0 : !1, c = "strokeweight", this[c] = d, mb(d) && (d += ga); else if (c === "dashstyle") (f.getElementsByTagName("stroke")[0] || xa(i.prepVML(["<stroke/>"]), null, null, f))[c] = d || "solid", this.dashstyle = d, n = !0; else if (c === "fill") h === "SPAN" ? g.color = d : (f.filled = d !== Ka ? !0 : !1, d = i.color(d, f, c), c = "fillcolor"); else if (c === "translateX" || c === "translateY" || c === "rotation") this[c] = d, this.updateTransform(), n = !0; else if (c === "text") this.bBox = null,
f.innerHTML = d, n = !0; if (l && c === "visibility") for (e = l.length; e--; ) l[e].style[c] = d; n || (ab ? f[c] = d : A(f, c, d))
            } return o
        }, clip: function (a) { var b = this, c = a.members, d = b.element; c.push(b); b.destroyClip = function () { Eb(c, b) }; d.parentNode.className === "highcharts-tracker" && !ab && Q(d, { visibility: Za }); return b.css(a.getCSS(b.inverted)) }, css: fb.prototype.htmlCss, safeRemoveChild: function (a) { a.parentNode && Sb(a) }, destroy: function () { this.destroyClip && this.destroyClip(); return fb.prototype.destroy.apply(this) }, empty: function () {
            for (var a =
this.element.childNodes, b = a.length, c; b--; ) c = a[b], c.parentNode.removeChild(c)
        }, on: function (a, b) { this.element["on" + a] = function () { var a = U.event; a.target = a.srcElement; b(a) }; return this }, shadow: function (a, b) {
            var c = [], d, e = this.element, f = this.renderer, g, h = e.style, i, k = e.path; k && typeof k.value !== "string" && (k = "x"); if (a) {
                for (d = 1; d <= 3; d++) i = ['<shape isShadow="true" strokeweight="', 7 - 2 * d, '" filled="false" path="', k, '" coordsize="100,100" style="', e.style.cssText, '" />'], g = xa(f.prepVML(i), null, { left: T(h.left) +
1, top: T(h.top) + 1
                }), i = ['<stroke color="black" opacity="', 0.05 * d, '"/>'], xa(f.prepVML(i), null, null, g), b ? b.element.appendChild(g) : e.parentNode.insertBefore(g, e), c.push(g); this.shadows = c
            } return this
        } 
    }, wa = da(fb, wa), D = { Element: wa, isIE8: va.indexOf("MSIE 8.0") > -1, init: function (a, b, c) {
        var d, e; this.alignedObjects = []; d = this.createElement(Ea); e = d.element; e.style.position = mc; a.appendChild(d.element); this.box = e; this.boxWrapper = d; this.setSize(b, c, !1); if (!B.namespaces.hcv) B.namespaces.add("hcv", "urn:schemas-microsoft-com:vml"),
B.createStyleSheet().cssText = "hcv\\:fill, hcv\\:path, hcv\\:shape, hcv\\:stroke{ behavior:url(#default#VML); display: inline-block; } "
    }, clipRect: function (a, b, c, d) { var e = this.createElement(); return N(e, { members: [], left: a, top: b, width: c, height: d, getCSS: function (a) { var b = this.top, c = this.left, d = c + this.width, e = b + this.height, b = { clip: "rect(" + C(a ? c : b) + "px," + C(a ? e : d) + "px," + C(a ? d : e) + "px," + C(a ? b : c) + "px)" }; !a && ab && N(b, { width: d + ga, height: e + ga }); return b }, updateClipping: function () { o(e.members, function (a) { a.css(e.getCSS(a.inverted)) }) } }) },
        color: function (a, b, c) {
            var d, e = /^rgba/; if (a && a.linearGradient) { var f, g, h = a.linearGradient, i = h.x1 || h[0] || 0, k = h.y1 || h[1] || 0, j = h.x2 || h[2] || 0, h = h.y2 || h[3] || 0, l, n, p, r; o(a.stops, function (a, b) { e.test(a[1]) ? (d = Oa(a[1]), f = d.get("rgb"), g = d.get("a")) : (f = a[1], g = 1); b ? (p = f, r = g) : (l = f, n = g) }); if (c === "fill") a = 90 - na.atan((h - k) / (j - i)) * 180 / ra, a = ['<fill colors="0% ', l, ",100% ", p, '" angle="', a, '" opacity="', r, '" o:opacity2="', n, '" type="gradient" focus="100%" method="sigma" />'], xa(this.prepVML(a), null, null, b); else return f } else if (e.test(a) &&
b.tagName !== "IMG") return d = Oa(a), a = ["<", c, ' opacity="', d.get("a"), '"/>'], xa(this.prepVML(a), null, null, b), d.get("rgb"); else { b = b.getElementsByTagName(c); if (b.length) b[0].opacity = 1; return a } 
        }, prepVML: function (a) {
            var b = this.isIE8, a = a.join(""); b ? (a = a.replace("/>", ' xmlns="urn:schemas-microsoft-com:vml" />'), a = a.indexOf('style="') === -1 ? a.replace("/>", ' style="display:inline-block;behavior:url(#default#VML);" />') : a.replace('style="', 'style="display:inline-block;behavior:url(#default#VML);')) : a = a.replace("<",
"<hcv:"); return a
        }, text: Cb.prototype.html, path: function (a) { return this.createElement("shape").attr({ coordsize: "100 100", d: a }) }, circle: function (a, b, c) { return this.symbol("circle").attr({ x: a - c, y: b - c, width: 2 * c, height: 2 * c }) }, g: function (a) { var b; a && (b = { className: ib + a, "class": ib + a }); return this.createElement(Ea).attr(b) }, image: function (a, b, c, d, e) { var f = this.createElement("img").attr({ src: a }); arguments.length > 1 && f.css({ left: b, top: c, width: d, height: e }); return f }, rect: function (a, b, c, d, e, f) {
            if (lb(a)) b = a.y, c =
a.width, d = a.height, f = a.strokeWidth, a = a.x; var g = this.symbol("rect"); g.r = e; return g.attr(g.crisp(f, a, b, X(c, 0), X(d, 0)))
        }, invertChild: function (a, b) { var c = b.style; Q(a, { flip: "x", left: T(c.width) - 10, top: T(c.height) - 10, rotation: -90 }) }, symbols: { arc: function (a, b, c, d, e) {
            var f = e.start, g = e.end, c = e.r || c || d, d = $(f), h = ca(f), i = $(g), k = ca(g), e = e.innerR, j = 0.08 / c, l = e && 0.25 / e || 0; if (g - f === 0) return ["x"]; else 2 * ra - g + f < j ? i = -j : g - f < l && (i = $(f + l)); return ["wa", a - c, b - c, a + c, b + c, a + c * d, b + c * h, a + c * i, b + c * k, "at", a - e, b - e, a + e, b + e, a + e * i, b +
e * k, a + e * d, b + e * h, "x", "e"]
        }, circle: function (a, b, c, d) { return ["wa", a, b, a + c, b + d, a + c, b + d / 2, a + c, b + d / 2, "e"] }, rect: function (a, b, c, d, e) { if (!u(e)) return []; var f = a + c, g = b + d, c = Ta(e.r || 0, c, d); return [ta, a + c, b, fa, f - c, b, "wa", f - 2 * c, b, f, b + 2 * c, f - c, b, f, b + c, fa, f, g - c, "wa", f - 2 * c, g - 2 * c, f, g, f, g - c, f - c, g, fa, a + c, g, "wa", a, g - 2 * c, a + 2 * c, g, a + c, g, a, g - c, fa, a, b + c, "wa", a, b, a + 2 * c, b + 2 * c, a, b + c, a + c, b, "x", "e"] } 
        }
    }, wa = function () { this.init.apply(this, arguments) }, wa.prototype = K(Cb.prototype, D), Wb = wa; var pc, Bc; Fa && (pc = function () { }, Bc = function () {
        function a() {
            var a =
b.length, d; for (d = 0; d < a; d++) b[d](); b = []
        } var b = []; return { push: function (c, d) { b.length === 0 && Hc(d, a); b.push(c) } }
    } ()); Wb = wa || pc || Cb; xc.prototype.callbacks = []; var xb = function () { }; xb.prototype = { init: function (a, b, c) { var d = a.chart.counters; this.series = a; this.applyOptions(b, c); this.pointAttr = {}; if (a.options.colorByPoint) { b = a.chart.options.colors; if (!this.options) this.options = {}; this.color = this.options.color = this.color || b[d.color++]; d.wrapColor(b.length) } a.chart.pointCount++; return this }, applyOptions: function (a,
b) { var c = this.series, d = typeof a; this.config = a; if (d === "number" || a === null) this.y = a; else if (typeof a[0] === "number") this.x = a[0], this.y = a[1]; else if (d === "object" && typeof a.length !== "number") { if (N(this, a), this.options = a, a.dataLabels) c._hasPointLabels = !0 } else if (typeof a[0] === "string") this.name = a[0], this.y = a[1]; if (this.x === V) this.x = b === V ? c.autoIncrement() : b }, destroy: function () {
    var a = this.series.chart, b = a.hoverPoints, c; a.pointCount--; if (b && (this.setState(), Eb(b, this), !b.length)) a.hoverPoints = null; if (this ===
a.hoverPoint) this.onMouseOut(); if (this.graphic || this.dataLabel) Na(this), this.destroyElements(); this.legendItem && a.legend.destroyItem(this); for (c in this) this[c] = null
}, destroyElements: function () { for (var a = "graphic,tracker,dataLabel,group,connector,shadowGroup".split(","), b, c = 6; c--; ) b = a[c], this[b] && (this[b] = this[b].destroy()) }, getLabelConfig: function () { return { x: this.category, y: this.y, key: this.name || this.category, series: this.series, point: this, percentage: this.percentage, total: this.total || this.stackTotal} },
        select: function (a, b) { var c = this, d = c.series.chart, a = r(a, !c.selected); c.firePointEvent(a ? "select" : "unselect", { accumulate: b }, function () { c.selected = a; c.setState(a && "select"); b || o(d.getSelectedPoints(), function (a) { if (a.selected && a !== c) a.selected = !1, a.setState(Ja), a.firePointEvent("unselect") }) }) }, onMouseOver: function () {
            var a = this.series, b = a.chart, c = b.tooltip, d = b.hoverPoint; if (d && d !== this) d.onMouseOut(); this.firePointEvent("mouseOver"); c && (!c.shared || a.noSharedTooltip) && c.refresh(this); this.setState(Ga);
            b.hoverPoint = this
        }, onMouseOut: function () { this.firePointEvent("mouseOut"); this.setState(); this.series.chart.hoverPoint = null }, tooltipFormatter: function (a) {
            var b = this.series, c = b.tooltipOptions, d = String(this.y).split("."), d = d[1] ? d[1].length : 0, e = a.match(/\{(series|point)\.[a-zA-Z]+\}/g), f = /[{\.}]/, g, h, i, k; for (k in e) h = e[k], yb(h) && h !== a && (i = (" " + h).split(f), g = { point: this, series: b}[i[1]], i = i[2], g = g === this && (i === "y" || i === "open" || i === "high" || i === "low" || i === "close") ? (c.valuePrefix || c.yPrefix || "") + cc(this[i],
r(c.valueDecimals, c.yDecimals, d)) + (c.valueSuffix || c.ySuffix || "") : g[i], a = a.replace(h, g)); return a
        }, update: function (a, b, c) { var d = this, e = d.series, f = d.graphic, g, h = e.data, i = h.length, k = e.chart, b = r(b, !0); d.firePointEvent("update", { options: a }, function () { d.applyOptions(a); lb(a) && (e.getAttribs(), f && f.attr(d.pointAttr[e.state])); for (g = 0; g < i; g++) if (h[g] === d) { e.xData[g] = d.x; e.yData[g] = d.y; e.options.data[g] = a; break } e.isDirty = !0; e.isDirtyData = !0; b && k.redraw(c) }) }, remove: function (a, b) {
            var c = this, d = c.series, e = d.chart,
f, g = d.data, h = g.length; Ib(b, e); a = r(a, !0); c.firePointEvent("remove", null, function () { for (f = 0; f < h; f++) if (g[f] === c) { g.splice(f, 1); d.options.data.splice(f, 1); d.xData.splice(f, 1); d.yData.splice(f, 1); break } c.destroy(); d.isDirty = !0; d.isDirtyData = !0; a && e.redraw() })
        }, firePointEvent: function (a, b, c) {
            var d = this, e = this.series.options; (e.point.events[a] || d.options && d.options.events && d.options.events[a]) && this.importEvents(); a === "click" && e.allowPointSelect && (c = function (a) { d.select(null, a.ctrlKey || a.metaKey || a.shiftKey) });
            aa(this, a, b, c)
        }, importEvents: function () { if (!this.hasImportedEvents) { var a = K(this.series.options.point, this.options).events, b; this.events = a; for (b in a) ka(this, b, a[b]); this.hasImportedEvents = !0 } }, setState: function (a) {
            var b = this.plotX, c = this.plotY, d = this.series, e = d.options.states, f = Aa[d.type].marker && d.options.marker, g = f && !f.enabled, h = f && f.states[a], i = h && h.enabled === !1, k = d.stateMarkerGraphic, j = d.chart, l = this.pointAttr, a = a || Ja; if (!(a === this.state || this.selected && a !== "select" || e[a] && e[a].enabled === !1 ||
a && (i || g && !h.enabled))) { if (this.graphic) e = f && this.graphic.symbolName && l[a].r, this.graphic.attr(K(l[a], e ? { x: b - e, y: c - e, width: 2 * e, height: 2 * e} : {})); else { if (a) { if (!k) e = f.radius, d.stateMarkerGraphic = k = j.renderer.symbol(d.symbol, -e, -e, 2 * e, 2 * e).attr(l[a]).add(d.group); k.translate(b, c) } if (k) k[a ? "show" : "hide"]() } this.state = a } 
        } 
    }; var M = function () { }; M.prototype = { isCartesian: !0, type: "line", pointClass: xb, sorted: !0, pointAttrToOptions: { stroke: "lineColor", "stroke-width": "lineWidth", fill: "fillColor", r: "radius" }, init: function (a,
b) { var c, d; d = a.series.length; this.chart = a; this.options = b = this.setOptions(b); this.bindAxes(); N(this, { index: d, name: b.name || "Series " + (d + 1), state: Ja, pointAttr: {}, visible: b.visible !== !1, selected: b.selected === !0 }); if (Fa) b.animation = !1; d = b.events; for (c in d) ka(this, c, d[c]); if (d && d.click || b.point && b.point.events && b.point.events.click || b.allowPointSelect) a.runTrackerClick = !0; this.getColor(); this.getSymbol(); this.setData(b.data, !1) }, bindAxes: function () {
    var a = this, b = a.options, c = a.chart, d; a.isCartesian && o(["xAxis",
"yAxis"], function (e) { o(c[e], function (c) { d = c.options; if (b[e] === d.index || b[e] === V && d.index === 0) c.series.push(a), a[e] = c, c.isDirty = !0 }) })
}, autoIncrement: function () { var a = this.options, b = this.xIncrement, b = r(b, a.pointStart, 0); this.pointInterval = r(this.pointInterval, a.pointInterval, 1); this.xIncrement = b + this.pointInterval; return b }, getSegments: function () {
    var a = -1, b = [], c, d = this.points, e = d.length; if (e) if (this.options.connectNulls) { for (c = e; c--; ) d[c].y === null && d.splice(c, 1); d.length && (b = [d]) } else o(d, function (c,
g) { c.y === null ? (g > a + 1 && b.push(d.slice(a + 1, g)), a = g) : g === e - 1 && b.push(d.slice(a + 1, g + 1)) }); this.segments = b
}, setOptions: function (a) { var b = this.chart.options, c = b.plotOptions, d = a.data; a.data = null; c = K(c[this.type], c.series, a); c.data = a.data = d; this.tooltipOptions = K(b.tooltip, c.tooltip); return c }, getColor: function () { var a = this.chart.options.colors, b = this.chart.counters; this.color = this.options.color || a[b.color++] || "#0000ff"; b.wrapColor(a.length) }, getSymbol: function () {
    var a = this.options.marker, b = this.chart, c = b.options.symbols,
b = b.counters; this.symbol = a.symbol || c[b.symbol++]; if (/^url/.test(this.symbol)) a.radius = 0; b.wrapSymbol(c.length)
}, addPoint: function (a, b, c, d) {
    var e = this.data, f = this.graph, g = this.area, h = this.chart, i = this.xData, k = this.yData, j = f && f.shift || 0, l = this.options.data; Ib(d, h); if (f && c) f.shift = j + 1; if (g) { if (c) g.shift = j + 1; g.isArea = !0 } b = r(b, !0); d = { series: this }; this.pointClass.prototype.applyOptions.apply(d, [a]); i.push(d.x); k.push(this.valueCount === 4 ? [d.open, d.high, d.low, d.close] : d.y); l.push(a); c && (e[0] && e[0].remove ?
e[0].remove(!1) : (e.shift(), i.shift(), k.shift(), l.shift())); this.getAttribs(); this.isDirtyData = this.isDirty = !0; b && h.redraw()
}, setData: function (a, b) {
    var c = this.points, d = this.options, e = this.initialColor, f = this.chart, g = null, h = this.xAxis; this.xIncrement = null; this.pointRange = h && h.categories && 1 || d.pointRange; if (u(e)) f.counters.color = e; var i = [], k = [], j = a ? a.length : [], l = this.valueCount === 4; if (j > (d.turboThreshold || 1E3)) {
        for (e = 0; g === null && e < j; ) g = a[e], e++; if (mb(g)) {
            g = r(d.pointStart, 0); d = r(d.pointInterval, 1); for (e =
0; e < j; e++) i[e] = g, k[e] = a[e], g += d; this.xIncrement = g
        } else if (bc(g)) if (l) for (e = 0; e < j; e++) d = a[e], i[e] = d[0], k[e] = d.slice(1, 5); else for (e = 0; e < j; e++) d = a[e], i[e] = d[0], k[e] = d[1]
    } else for (e = 0; e < j; e++) d = { series: this }, this.pointClass.prototype.applyOptions.apply(d, [a[e]]), i[e] = d.x, k[e] = l ? [d.open, d.high, d.low, d.close] : d.y; this.data = []; this.options.data = a; this.xData = i; this.yData = k; for (e = c && c.length || 0; e--; ) c[e] && c[e].destroy && c[e].destroy(); h && h.setMinRange && h.setMinRange(); this.isDirty = this.isDirtyData = f.isDirtyBox =
!0; r(b, !0) && f.redraw(!1)
}, remove: function (a, b) { var c = this, d = c.chart, a = r(a, !0); if (!c.isRemoving) c.isRemoving = !0, aa(c, "remove", null, function () { c.destroy(); d.isDirtyLegend = d.isDirtyBox = !0; a && d.redraw(b) }); c.isRemoving = !1 }, processData: function (a) {
    var b = this.xData, c = this.yData, d = b.length, e = 0, f = d, g, h, i = this.xAxis, k = this.options, j = k.cropThreshold, l = this.isCartesian; if (l && !this.isDirty && !i.isDirty && !this.yAxis.isDirty && !a) return !1; if (l && this.sorted && (!j || d > j || this.forceCrop)) if (a = i.getExtremes(), i = a.min,
j = a.max, b[d - 1] < i || b[0] > j) b = [], c = []; else if (b[0] < i || b[d - 1] > j) { for (a = 0; a < d; a++) if (b[a] >= i) { e = X(0, a - 1); break } for (; a < d; a++) if (b[a] > j) { f = a + 1; break } b = b.slice(e, f); c = c.slice(e, f); g = !0 } for (a = b.length - 1; a > 0; a--) if (d = b[a] - b[a - 1], d > 0 && (h === V || d < h)) h = d; this.cropped = g; this.cropStart = e; this.processedXData = b; this.processedYData = c; if (k.pointRange === null) this.pointRange = h || 1; this.closestPointRange = h
}, generatePoints: function () {
    var a = this.options.data, b = this.data, c, d = this.processedXData, e = this.processedYData, f = this.pointClass,
g = d.length, h = this.cropStart || 0, i, k = this.hasGroupedData, j, l = [], n; if (!b && !k) b = [], b.length = a.length, b = this.data = b; for (n = 0; n < g; n++) i = h + n, k ? l[n] = (new f).init(this, [d[n]].concat(Fb(e[n]))) : (b[i] ? j = b[i] : b[i] = j = (new f).init(this, a[i], d[n]), l[n] = j); if (b && (g !== (c = b.length) || k)) for (n = 0; n < c; n++) n === h && !k && (n += g), b[n] && b[n].destroyElements(); this.data = b; this.points = l
}, translate: function () {
    this.processedXData || this.processData(); this.generatePoints(); for (var a = this.chart, b = this.options, c = b.stacking, d = this.xAxis,
e = d.categories, f = this.yAxis, g = this.points, h = g.length, i = !!this.modifyValue, k, j = f.series, l = j.length; l--; ) if (j[l].visible) { l === this.index && (k = !0); break } for (l = 0; l < h; l++) {
        var j = g[l], n = j.x, p = j.y, o = j.low, r = f.stacks[(p < b.threshold ? "-" : "") + this.stackKey]; j.plotX = C(d.translate(n, 0, 0, 0, 1) * 10) / 10; if (c && this.visible && r && r[n]) { o = r[n]; n = o.total; o.cum = o = o.cum - p; p = o + p; if (k) o = b.threshold; c === "percent" && (o = n ? o * 100 / n : 0, p = n ? p * 100 / n : 0); j.percentage = n ? j.y * 100 / n : 0; j.stackTotal = n; j.stackY = p } j.yBottom = u(o) ? f.translate(o, 0,
1, 0, 1) : null; i && (p = this.modifyValue(p, j)); j.plotY = typeof p === "number" ? C(f.translate(p, 0, 1, 0, 1) * 10) / 10 : V; j.clientX = a.inverted ? a.plotHeight - j.plotX : j.plotX; j.category = e && e[j.x] !== V ? e[j.x] : j.x
    } this.getSegments()
}, setTooltipPoints: function (a) {
    var b = [], c = this.chart.plotSizeX, d, e; d = this.xAxis; var f, g, h = []; if (this.options.enableMouseTracking !== !1) {
        if (a) this.tooltipPoints = null; o(this.segments || this.points, function (a) { b = b.concat(a) }); d && d.reversed && (b = b.reverse()); a = b.length; for (g = 0; g < a; g++) {
            f = b[g]; d = b[g - 1] ?
b[g - 1]._high + 1 : 0; for (e = f._high = b[g + 1] ? Sa((f.plotX + (b[g + 1] ? b[g + 1].plotX : c)) / 2) : c; d <= e; ) h[d++] = f
        } this.tooltipPoints = h
    } 
}, tooltipHeaderFormatter: function (a) { var b = this.tooltipOptions, c = b.xDateFormat || "%A, %b %e, %Y", d = this.xAxis; return b.headerFormat.replace("{point.key}", d && d.options.type === "datetime" ? $b(c, a) : a).replace("{series.name}", this.name).replace("{series.color}", this.color) }, onMouseOver: function () {
    var a = this.chart, b = a.hoverSeries; if (Wa || !a.mouseIsDown) {
        if (b && b !== this) b.onMouseOut(); this.options.events.mouseOver &&
aa(this, "mouseOver"); this.setState(Ga); a.hoverSeries = this
    } 
}, onMouseOut: function () { var a = this.options, b = this.chart, c = b.tooltip, d = b.hoverPoint; if (d) d.onMouseOut(); this && a.events.mouseOut && aa(this, "mouseOut"); c && !a.stickyTracking && !c.shared && c.hide(); this.setState(); b.hoverSeries = null }, animate: function (a) { var b = this.chart, c = this.clipRect, d = this.options.animation; d && !lb(d) && (d = {}); if (a) { if (!c.isAnimating) c.attr("width", 0), c.isAnimating = !0 } else c.animate({ width: b.plotSizeX }, d), this.animate = null }, drawPoints: function () {
    var a,
b = this.points, c = this.chart, d, e, f, g, h, i, k, j; if (this.options.marker.enabled) for (f = b.length; f--; ) if (g = b[f], d = g.plotX, e = g.plotY, j = g.graphic, e !== V && !isNaN(e)) if (a = g.pointAttr[g.selected ? "select" : Ja], h = a.r, i = r(g.marker && g.marker.symbol, this.symbol), k = i.indexOf("url") === 0, j) j.animate(N({ x: d - h, y: e - h }, j.symbolName ? { width: 2 * h, height: 2 * h} : {})); else if (h > 0 || k) g.graphic = c.renderer.symbol(i, d - h, e - h, 2 * h, 2 * h).attr(a).add(this.group)
}, convertAttribs: function (a, b, c, d) {
    var e = this.pointAttrToOptions, f, g, h = {}, a = a || {},
b = b || {}, c = c || {}, d = d || {}; for (f in e) g = e[f], h[f] = r(a[g], b[f], c[f], d[f]); return h
}, getAttribs: function () {
    var a = this, b = Aa[a.type].marker ? a.options.marker : a.options, c = b.states, d = c[Ga], e, f = a.color, g = { stroke: f, fill: f }, h = a.points, i = [], k, j = a.pointAttrToOptions, l; a.options.marker ? (d.radius = d.radius || b.radius + 2, d.lineWidth = d.lineWidth || b.lineWidth + 1) : d.color = d.color || Oa(d.color || f).brighten(d.brightness).get(); i[Ja] = a.convertAttribs(b, g); o([Ga, "select"], function (b) { i[b] = a.convertAttribs(c[b], i[Ja]) }); a.pointAttr =
i; for (f = h.length; f--; ) { g = h[f]; if ((b = g.options && g.options.marker || g.options) && b.enabled === !1) b.radius = 0; e = !1; if (g.options) for (l in j) u(b[j[l]]) && (e = !0); if (e) { k = []; c = b.states || {}; e = c[Ga] = c[Ga] || {}; if (!a.options.marker) e.color = Oa(e.color || g.options.color).brighten(e.brightness || d.brightness).get(); k[Ja] = a.convertAttribs(b, i[Ja]); k[Ga] = a.convertAttribs(c[Ga], i[Ga], k[Ja]); k.select = a.convertAttribs(c.select, i.select, k[Ja]) } else k = i; g.pointAttr = k } 
}, destroy: function () {
    var a = this, b = a.chart, c = a.clipRect, d =
/AppleWebKit\/533/.test(va), e, f, g = a.data || [], h, i, k; aa(a, "destroy"); Na(a); o(["xAxis", "yAxis"], function (b) { if (k = a[b]) Eb(k.series, a), k.isDirty = !0 }); a.legendItem && a.chart.legend.destroyItem(a); for (f = g.length; f--; ) (h = g[f]) && h.destroy && h.destroy(); a.points = null; if (c && c !== b.clipRect) a.clipRect = c.destroy(); o(["area", "graph", "dataLabelsGroup", "group", "tracker"], function (b) { a[b] && (e = d && b === "group" ? "hide" : "destroy", a[b][e]()) }); if (b.hoverSeries === a) b.hoverSeries = null; Eb(b.series, a); for (i in a) delete a[i]
}, drawDataLabels: function () {
    var a =
this, b = a.options, c = b.dataLabels; if (c.enabled || a._hasPointLabels) {
        var d, e, f = a.points, g, h, i, k = a.dataLabelsGroup, j = a.chart, l = a.xAxis, l = l ? l.left : j.plotLeft, n = a.yAxis, n = n ? n.top : j.plotTop, p = j.renderer, v = j.inverted, y = a.type, t = b.stacking, w = y === "column" || y === "bar", s = c.verticalAlign === null, Y = c.y === null, z = p.fontMetrics(c.style.fontSize), A = z.h, D = z.b, E, B; w && (z = { top: D, middle: D - A / 2, bottom: -A + D }, t ? (s && (c = K(c, { verticalAlign: "middle" })), Y && (c = K(c, { y: z[c.verticalAlign] }))) : s ? c = K(c, { verticalAlign: "top" }) : Y && (c = K(c, { y: z[c.verticalAlign] })));
        k ? k.translate(l, n) : k = a.dataLabelsGroup = p.g("data-labels").attr({ visibility: a.visible ? cb : Za, zIndex: 6 }).translate(l, n).add(); h = c; o(f, function (f) {
            E = f.dataLabel; c = h; (g = f.options) && g.dataLabels && (c = K(c, g.dataLabels)); if (B = c.enabled) { var l = f.barX && f.barX + f.barW / 2 || r(f.plotX, -999), n = r(f.plotY, -999), o = c.y === null ? f.y >= b.threshold ? -A + D : D : c.y; d = (v ? j.plotWidth - n : l) + c.x; e = C((v ? j.plotHeight - l : n) + o) } if (E && a.isCartesian && (!j.isInsidePlot(d, e) || !B)) f.dataLabel = E.destroy(); else if (B) {
                l = c.align; i = c.formatter.call(f.getLabelConfig(),
c); y === "column" && (d += { left: -1, right: 1}[l] * f.barW / 2 || 0); !t && v && f.y < 0 && (l = "right", d -= 10); c.style.color = r(c.color, c.style.color, a.color, "black"); if (E) E.attr({ text: i }).animate({ x: d, y: e }); else if (u(i)) E = f.dataLabel = p[c.rotation ? "text" : "label"](i, d, e, null, null, null, c.useHTML, !0).attr({ align: l, fill: c.backgroundColor, stroke: c.borderColor, "stroke-width": c.borderWidth, r: c.borderRadius || 0, rotation: c.rotation, padding: c.padding, zIndex: 1 }).css(c.style).add(k).shadow(c.shadow); if (w && b.stacking && E) l = f.barX, n = f.barY,
o = f.barW, f = f.barH, E.align(c, null, { x: v ? j.plotWidth - n - f : l, y: v ? j.plotHeight - l - o : n, width: v ? f : o, height: v ? o : f })
            } 
        })
    } 
}, drawGraph: function () {
    var a = this, b = a.options, c = a.graph, d = [], e, f = a.area, g = a.group, h = b.lineColor || a.color, i = b.lineWidth, k = b.dashStyle, j, l = a.chart.renderer, n = a.yAxis.getThreshold(b.threshold), p = /^area/.test(a.type), v = [], u = []; o(a.segments, function (c) {
        j = []; o(c, function (d, e) {
            a.getPointSpline ? j.push.apply(j, a.getPointSpline(c, d, e)) : (j.push(e ? fa : ta), e && b.step && j.push(d.plotX, c[e - 1].plotY), j.push(d.plotX,
d.plotY))
        }); c.length > 1 ? d = d.concat(j) : v.push(c[0]); if (p) { var e = [], f, g = j.length; for (f = 0; f < g; f++) e.push(j[f]); g === 3 && e.push(fa, j[1], j[2]); if (b.stacking && a.type !== "areaspline") for (f = c.length - 1; f >= 0; f--) f < c.length - 1 && b.step && e.push(c[f + 1].plotX, c[f].yBottom), e.push(c[f].plotX, c[f].yBottom); else e.push(fa, c[c.length - 1].plotX, n, fa, c[0].plotX, n); u = u.concat(e) } 
    }); a.graphPath = d; a.singlePoints = v; if (p) e = r(b.fillColor, Oa(a.color).setOpacity(b.fillOpacity || 0.75).get()), f ? f.animate({ d: u }) : a.area = a.chart.renderer.path(u).attr({ fill: e }).add(g);
    if (c) Nb(c), c.animate({ d: d }); else if (i) { c = { stroke: h, "stroke-width": i }; if (k) c.dashstyle = k; a.graph = l.path(d).attr(c).add(g).shadow(b.shadow) } 
}, invertGroups: function () { function a() { var a = { width: b.yAxis.len, height: b.xAxis.len }; c.attr(a).invert(); d && d.attr(a).invert() } var b = this, c = b.group, d = b.trackerGroup, e = b.chart; ka(e, "resize", a); ka(b, "destroy", function () { Na(e, "resize", a) }); a(); b.invertGroups = a }, render: function () {
    var a = this, b = a.chart, c, d = a.options, e = d.clip !== !1, f = d.animation, g = f && a.animate, f = g ? f && f.duration ||
500 : 0, h = a.clipRect, i = b.renderer; if (!h && (h = a.clipRect = !b.hasRendered && b.clipRect ? b.clipRect : i.clipRect(0, 0, b.plotSizeX, b.plotSizeY + 1), !b.clipRect)) b.clipRect = h; if (!a.group) c = a.group = i.g("series"), c.attr({ visibility: a.visible ? cb : Za, zIndex: d.zIndex }).translate(a.xAxis.left, a.yAxis.top).add(b.seriesGroup); a.drawDataLabels(); g && a.animate(!0); a.getAttribs(); a.drawGraph && a.drawGraph(); a.drawPoints(); a.options.enableMouseTracking !== !1 && a.drawTracker(); b.inverted && a.invertGroups(); e && !a.hasRendered && (c.clip(h),
a.trackerGroup && a.trackerGroup.clip(b.clipRect)); g && a.animate(); setTimeout(function () { h.isAnimating = !1; if ((c = a.group) && h !== b.clipRect && h.renderer) { if (e) c.clip(a.clipRect = b.clipRect); h.destroy() } }, f); a.isDirty = a.isDirtyData = !1; a.hasRendered = !0
}, redraw: function () {
    var a = this.chart, b = this.isDirtyData, c = this.group; c && (a.inverted && c.attr({ width: a.plotWidth, height: a.plotHeight }), c.animate({ translateX: this.xAxis.left, translateY: this.yAxis.top })); this.translate(); this.setTooltipPoints(!0); this.render(); b &&
aa(this, "updatedData")
}, setState: function (a) { var b = this.options, c = this.graph, d = b.states, b = b.lineWidth, a = a || Ja; if (this.state !== a) this.state = a, d[a] && d[a].enabled === !1 || (a && (b = d[a].lineWidth || b + 1), c && !c.dashstyle && c.attr({ "stroke-width": b }, a ? 0 : 500)) }, setVisible: function (a, b) {
    var c = this.chart, d = this.legendItem, e = this.group, f = this.tracker, g = this.dataLabelsGroup, h, i = this.points, k = c.options.chart.ignoreHiddenSeries; h = this.visible; h = (this.visible = a = a === V ? !h : a) ? "show" : "hide"; if (e) e[h](); if (f) f[h](); else if (i) for (e =
i.length; e--; ) if (f = i[e], f.tracker) f.tracker[h](); if (g) g[h](); d && c.legend.colorizeItem(this, a); this.isDirty = !0; this.options.stacking && o(c.series, function (a) { if (a.options.stacking && a.visible) a.isDirty = !0 }); if (k) c.isDirtyBox = !0; b !== !1 && c.redraw(); aa(this, h)
}, show: function () { this.setVisible(!0) }, hide: function () { this.setVisible(!1) }, select: function (a) { this.selected = a = a === V ? !this.selected : a; if (this.checkbox) this.checkbox.checked = a; aa(this, a ? "select" : "unselect") }, drawTrackerGroup: function () {
    var a = this.trackerGroup,
b = this.chart; if (this.isCartesian) { if (!a) this.trackerGroup = a = b.renderer.g().attr({ zIndex: this.options.zIndex || 1 }).add(b.trackerGroup); a.translate(this.xAxis.left, this.yAxis.top) } return a
}, drawTracker: function () {
    var a = this, b = a.options, c = [].concat(a.graphPath), d = c.length, e = a.chart, f = e.renderer, g = e.options.tooltip.snap, h = a.tracker, i = b.cursor, i = i && { cursor: i }, k = a.singlePoints, j = a.drawTrackerGroup(), l; if (d) for (l = d + 1; l--; ) c[l] === ta && c.splice(l + 1, 0, c[l + 1] - g, c[l + 2], fa), (l && c[l] === ta || l === d) && c.splice(l, 0, fa,
c[l - 2] + g, c[l - 1]); for (l = 0; l < k.length; l++) d = k[l], c.push(ta, d.plotX - g, d.plotY, fa, d.plotX + g, d.plotY); h ? h.attr({ d: c }) : a.tracker = f.path(c).attr({ isTracker: !0, stroke: Gc, fill: Ka, "stroke-linejoin": "bevel", "stroke-width": b.lineWidth + 2 * g, visibility: a.visible ? cb : Za }).on(Wa ? "touchstart" : "mouseover", function () { if (e.hoverSeries !== a) a.onMouseOver() }).on("mouseout", function () { if (!b.stickyTracking) a.onMouseOut() }).css(i).add(j)
} 
    }; D = da(M); Ha.line = D; D = da(M, { type: "area" }); Ha.area = D; D = da(M, { type: "spline", getPointSpline: function (a,
b, c) { var d = b.plotX, e = b.plotY, f = a[c - 1], g = a[c + 1], h, i, k, j; if (c && c < a.length - 1) { a = f.plotY; k = g.plotX; var g = g.plotY, l; h = (1.5 * d + f.plotX) / 2.5; i = (1.5 * e + a) / 2.5; k = (1.5 * d + k) / 2.5; j = (1.5 * e + g) / 2.5; l = (j - i) * (k - d) / (k - h) + e - j; i += l; j += l; i > a && i > e ? (i = X(a, e), j = 2 * e - i) : i < a && i < e && (i = Ta(a, e), j = 2 * e - i); j > g && j > e ? (j = X(g, e), i = 2 * e - j) : j < g && j < e && (j = Ta(g, e), i = 2 * e - j); b.rightContX = k; b.rightContY = j } c ? (b = ["C", f.rightContX || f.plotX, f.rightContY || f.plotY, h || d, i || e, d, e], f.rightContX = f.rightContY = null) : b = [ta, d, e]; return b } 
    }); Ha.spline = D; D = da(D,
{ type: "areaspline" }); Ha.areaspline = D; var Qb = da(M, { type: "column", tooltipOutsidePlot: !0, pointAttrToOptions: { stroke: "borderColor", "stroke-width": "borderWidth", fill: "color", r: "borderRadius" }, init: function () { M.prototype.init.apply(this, arguments); var a = this, b = a.chart; b.hasRendered && o(b.series, function (b) { if (b.type === a.type) b.isDirty = !0 }) }, translate: function () {
    var a = this, b = a.chart, c = a.options, d = c.stacking, e = c.borderWidth, f = 0, g = a.xAxis, h = g.reversed, i = {}, k, j; M.prototype.translate.apply(a); o(b.series, function (b) {
        if (b.type ===
a.type && b.visible && a.options.group === b.options.group) b.options.stacking ? (k = b.stackKey, i[k] === V && (i[k] = f++), j = i[k]) : j = f++, b.columnIndex = j
    }); var b = a.points, g = ya(g.translationSlope) * (g.ordinalSlope || g.closestPointRange || 1), l = g * c.groupPadding, n = (g - 2 * l) / f, p = c.pointWidth, v = u(p) ? (n - p) / 2 : n * c.pointPadding, y = Xb(X(r(p, n - 2 * v), 1 + 2 * e)), t = v + (l + ((h ? f - a.columnIndex : a.columnIndex) || 0) * n - g / 2) * (h ? -1 : 1), w = a.yAxis.getThreshold(c.threshold), s = r(c.minPointLength, 5); o(b, function (b) {
        var f = b.plotY, g = r(b.yBottom, w), h = b.plotX +
t, i = Xb(Ta(f, g)), j = Xb(X(f, g) - i), k = a.yAxis.stacks[(b.y < 0 ? "-" : "") + a.stackKey]; d && a.visible && k && k[b.x] && k[b.x].setOffset(t, y); ya(j) < s && s && (j = s, i = ya(i - w) > s ? g - s : w - (f <= w ? s : 0)); N(b, { barX: h, barY: i, barW: y, barH: j }); b.shapeType = "rect"; f = { x: h, y: i, width: y, height: j, r: c.borderRadius, strokeWidth: e }; e % 2 && (f.y -= 1, f.height += 1); b.shapeArgs = f; b.trackerArgs = ya(j) < 3 && K(b.shapeArgs, { height: 6, y: i - 3 })
    })
}, getSymbol: function () { }, drawGraph: function () { }, drawPoints: function () {
    var a = this, b = a.options, c = a.chart.renderer, d, e; o(a.points,
function (f) { var g = f.plotY; if (g !== V && !isNaN(g) && f.y !== null) d = f.graphic, e = f.shapeArgs, d ? (Nb(d), d.animate(c.Element.prototype.crisp.apply({}, [e.strokeWidth, e.x, e.y, e.width, e.height]))) : f.graphic = d = c[f.shapeType](e).attr(f.pointAttr[f.selected ? "select" : Ja]).add(a.group).shadow(b.shadow) })
}, drawTracker: function () {
    var a = this, b = a.chart, c = b.renderer, d, e, f = +new Date, g = a.options, h = g.cursor, i = h && { cursor: h }, k = a.drawTrackerGroup(), j, l, n; o(a.points, function (h) {
        e = h.tracker; d = h.trackerArgs || h.shapeArgs; l = h.plotY;
        n = !a.isCartesian || l !== V && !isNaN(l); delete d.strokeWidth; if (h.y !== null && n) e ? e.attr(d) : h.tracker = c[h.shapeType](d).attr({ isTracker: f, fill: Gc, visibility: a.visible ? cb : Za }).on(Wa ? "touchstart" : "mouseover", function (c) { j = c.relatedTarget || c.fromElement; if (b.hoverSeries !== a && A(j, "isTracker") !== f) a.onMouseOver(); h.onMouseOver() }).on("mouseout", function (b) { if (!g.stickyTracking && (j = b.relatedTarget || b.toElement, A(j, "isTracker") !== f)) a.onMouseOut() }).css(i).add(h.group || k)
    })
}, animate: function (a) {
    var b = this, c = b.points,
d = b.options; if (!a) o(c, function (a) { var c = a.graphic, a = a.shapeArgs, g = b.yAxis, h = d.threshold; c && (c.attr({ height: 0, y: u(h) ? g.getThreshold(h) : g.translate(g.getExtremes().min, 0, 1, 0, 1) }), c.animate({ height: a.height, y: a.y }, d.animation)) }), b.animate = null
}, remove: function () { var a = this, b = a.chart; b.hasRendered && o(b.series, function (b) { if (b.type === a.type) b.isDirty = !0 }); M.prototype.remove.apply(a, arguments) } 
}); Ha.column = Qb; D = da(Qb, { type: "bar", init: function () { this.inverted = !0; Qb.prototype.init.apply(this, arguments) } });
    Ha.bar = D; D = da(M, { type: "scatter", sorted: !1, translate: function () { var a = this; M.prototype.translate.apply(a); o(a.points, function (b) { b.shapeType = "circle"; b.shapeArgs = { x: b.plotX, y: b.plotY, r: a.chart.options.tooltip.snap} }) }, drawTracker: function () {
        for (var a = this, b = a.options.cursor, b = b && { cursor: b }, c = a.points, d = c.length, e; d--; ) if (e = c[d].graphic) e.element._i = d; a._hasTracking ? a._hasTracking = !0 : a.group.attr({ isTracker: !0 }).on(Wa ? "touchstart" : "mouseover", function (b) { a.onMouseOver(); if (b.target._i !== V) c[b.target._i].onMouseOver() }).on("mouseout",
function () { if (!a.options.stickyTracking) a.onMouseOut() }).css(b)
    } 
    }); Ha.scatter = D; D = da(xb, { init: function () { xb.prototype.init.apply(this, arguments); var a = this, b; N(a, { visible: a.visible !== !1, name: r(a.name, "Slice") }); b = function () { a.slice() }; ka(a, "select", b); ka(a, "unselect", b); return a }, setVisible: function (a) {
        var b = this.series.chart, c = this.tracker, d = this.dataLabel, e = this.connector, f = this.shadowGroup, g; g = (this.visible = a = a === V ? !this.visible : a) ? "show" : "hide"; this.group[g](); if (c) c[g](); if (d) d[g](); if (e) e[g]();
        if (f) f[g](); this.legendItem && b.legend.colorizeItem(this, a)
    }, slice: function (a, b, c) { var d = this.series.chart, e = this.slicedTranslation; Ib(c, d); r(b, !0); a = this.sliced = u(a) ? a : !this.sliced; a = { translateX: a ? e[0] : d.plotLeft, translateY: a ? e[1] : d.plotTop }; this.group.animate(a); this.shadowGroup && this.shadowGroup.animate(a) } 
    }); D = da(M, { type: "pie", isCartesian: !1, pointClass: D, pointAttrToOptions: { stroke: "borderColor", "stroke-width": "borderWidth", fill: "color" }, getColor: function () { this.initialColor = this.chart.counters.color },
        animate: function () { var a = this; o(a.points, function (b) { var c = b.graphic, b = b.shapeArgs, d = -ra / 2; c && (c.attr({ r: 0, start: d, end: d }), c.animate({ r: b.r, start: b.start, end: b.end }, a.options.animation)) }); a.animate = null }, setData: function (a, b) { M.prototype.setData.call(this, a, !1); this.processData(); this.generatePoints(); r(b, !0) && this.chart.redraw() }, translate: function () {
            this.generatePoints(); var a = 0, b = -0.25, c = this.options, d = c.slicedOffset, e = d + c.borderWidth, f = c.center.concat([c.size, c.innerSize || 0]), g = this.chart, h =
g.plotWidth, i = g.plotHeight, k, j, l, n = this.points, p = 2 * ra, r, u = Ta(h, i), t, w, s, y = c.dataLabels.distance, f = Ub(f, function (a, b) { return (t = /%$/.test(a)) ? [h, i, u, u][b] * T(a) / 100 : a }); this.getX = function (a, b) { l = na.asin((a - f[1]) / (f[2] / 2 + y)); return f[0] + (b ? -1 : 1) * $(l) * (f[2] / 2 + y) }; this.center = f; o(n, function (b) { a += b.y }); o(n, function (c) {
    r = a ? c.y / a : 0; k = C(b * p * 1E3) / 1E3; b += r; j = C(b * p * 1E3) / 1E3; c.shapeType = "arc"; c.shapeArgs = { x: f[0], y: f[1], r: f[2] / 2, innerR: f[3] / 2, start: k, end: j }; l = (j + k) / 2; c.slicedTranslation = Ub([$(l) * d + g.plotLeft, ca(l) *
d + g.plotTop], C); w = $(l) * f[2] / 2; s = ca(l) * f[2] / 2; c.tooltipPos = [f[0] + w * 0.7, f[1] + s * 0.7]; c.labelPos = [f[0] + w + $(l) * y, f[1] + s + ca(l) * y, f[0] + w + $(l) * e, f[1] + s + ca(l) * e, f[0] + w, f[1] + s, y < 0 ? "center" : l < p / 4 ? "left" : "right", l]; c.percentage = r * 100; c.total = a
}); this.setTooltipPoints()
        }, render: function () { this.getAttribs(); this.drawPoints(); this.options.enableMouseTracking !== !1 && this.drawTracker(); this.drawDataLabels(); this.options.animation && this.animate && this.animate(); this.isDirty = !1 }, drawPoints: function () {
            var a = this.chart,
b = a.renderer, c, d, e, f = this.options.shadow, g, h; o(this.points, function (i) { d = i.graphic; h = i.shapeArgs; e = i.group; g = i.shadowGroup; if (f && !g) g = i.shadowGroup = b.g("shadow").attr({ zIndex: 4 }).add(); if (!e) e = i.group = b.g("point").attr({ zIndex: 5 }).add(); c = i.sliced ? i.slicedTranslation : [a.plotLeft, a.plotTop]; e.translate(c[0], c[1]); g && g.translate(c[0], c[1]); d ? d.animate(h) : i.graphic = b.arc(h).attr(N(i.pointAttr[Ja], { "stroke-linejoin": "round" })).add(i.group).shadow(f, g); i.visible === !1 && i.setVisible(!1) })
        }, drawDataLabels: function () {
            var a =
this.data, b, c = this.chart, d = this.options.dataLabels, e = r(d.connectorPadding, 10), f = r(d.connectorWidth, 1), g, h, i = r(d.softConnector, !0), k = d.distance, j = this.center, l = j[2] / 2, n = j[1], p = k > 0, v = [[], []], u, t, w, s, y = 2, z; if (d.enabled) {
                M.prototype.drawDataLabels.apply(this); o(a, function (a) { a.dataLabel && v[a.labelPos[7] < ra / 2 ? 0 : 1].push(a) }); v[1].reverse(); s = function (a, b) { return b.y - a.y }; for (a = v[0][0] && v[0][0].dataLabel && v[0][0].dataLabel.getBBox().height; y--; ) {
                    var A = [], E = [], D = v[y], C = D.length, B; if (k > 0) {
                        for (z = n - l - k; z <= n +
l + k; z += a) A.push(z); w = A.length; if (C > w) { h = [].concat(D); h.sort(s); for (z = C; z--; ) h[z].rank = z; for (z = C; z--; ) D[z].rank >= w && D.splice(z, 1); C = D.length } for (z = 0; z < C; z++) { b = D[z]; h = b.labelPos; b = 9999; for (t = 0; t < w; t++) g = ya(A[t] - h[1]), g < b && (b = g, B = t); if (B < z && A[z] !== null) B = z; else for (w < C - z + B && A[z] !== null && (B = w - C + z); A[B] === null; ) B++; E.push({ i: B, y: A[B] }); A[B] = null } E.sort(s)
                    } for (z = 0; z < C; z++) {
                        b = D[z]; h = b.labelPos; g = b.dataLabel; w = b.visible === !1 ? Za : cb; u = h[1]; if (k > 0) {
                            if (t = E.pop(), B = t.i, t = t.y, u > t && A[B + 1] !== null || u < t && A[B - 1] !==
null) t = u
                        } else t = u; u = d.justify ? j[0] + (y ? -1 : 1) * (l + k) : this.getX(B === 0 || B === A.length - 1 ? u : t, y); g.attr({ visibility: w, align: h[6] })[g.moved ? "animate" : "attr"]({ x: u + d.x + ({ left: e, right: -e}[h[6]] || 0), y: t + d.y }); g.moved = !0; if (p && f) g = b.connector, h = i ? [ta, u + (h[6] === "left" ? 5 : -5), t, "C", u, t, 2 * h[2] - h[4], 2 * h[3] - h[5], h[2], h[3], fa, h[4], h[5]] : [ta, u + (h[6] === "left" ? 5 : -5), t, fa, h[2], h[3], fa, h[4], h[5]], g ? (g.animate({ d: h }), g.attr("visibility", w)) : b.connector = g = this.chart.renderer.path(h).attr({ "stroke-width": f, stroke: d.connectorColor ||
b.color || "#606060", visibility: w, zIndex: 3
                        }).translate(c.plotLeft, c.plotTop).add()
                    } 
                } 
            } 
        }, drawTracker: Qb.prototype.drawTracker, getSymbol: function () { } 
    }); Ha.pie = D; N(Highcharts, { Chart: xc, dateFormat: $b, pathAnim: kb, getOptions: function () { return Ba }, hasBidiBug: Qc, numberFormat: cc, Point: xb, Color: Oa, Renderer: Wb, SVGRenderer: Cb, VMLRenderer: wa, CanVGRenderer: pc, seriesTypes: Ha, setOptions: function (a) { Zb = K(Zb, a.xAxis); kc = K(kc, a.yAxis); a.xAxis = a.yAxis = V; Ba = K(Ba, a); wc(); return Ba }, Series: M, addEvent: ka, removeEvent: Na, createElement: xa,
        discardElement: Sb, css: Q, each: o, extend: N, map: Ub, merge: K, pick: r, splat: Fb, extendClass: da, placeBox: vc, product: "Highcharts", version: "2.2.3"
    })
})();
