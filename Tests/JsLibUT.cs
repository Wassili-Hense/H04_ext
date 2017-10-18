///<remarks>This file is part of the <see cref="https://github.com/enviriot">Enviriot</see> project.<remarks>
using JSC = NiL.JS.Core;
using JSL = NiL.JS.BaseLibrary;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X13 {
  [TestClass]
  public class JsLibUT {
    [TestMethod]
    public void SetField01() {
      JSC.JSValue o=null, r, v=new JSL.Boolean(true);
      r = JsLib.SetField(o, null, v);
      Assert.AreEqual(v, r);
    }
    [TestMethod]
    public void SetField02() {
      JSC.JSValue o = null, r, v = new JSL.Boolean(true);
      r = JsLib.SetField(o, "a", v);
      Assert.AreNotEqual(o, r);
      Assert.AreEqual(JSC.JSValueType.Object, r.ValueType);
      Assert.AreEqual(v, r["a"]);
    }
    [TestMethod]
    public void SetField03() {
      JSC.JSValue o = JSC.JSObject.CreateObject(), o1 = new JSL.Boolean(false), r, v = new JSL.Boolean(true);
      o["b"] = o1;
      r = JsLib.SetField(o, "a", v);
      Assert.AreNotEqual(o, r);
      Assert.AreEqual(JSC.JSValueType.Object, r.ValueType);
      Assert.AreEqual(v, r["a"]);
      Assert.AreEqual(o1, r["b"]);
    }
    [TestMethod]
    public void SetField04() {
      JSC.JSValue o = JSC.JSObject.CreateObject(), o1 = new JSL.Boolean(false), r, v = new JSL.Boolean(true);
      o["a"] = new JSL.Number(3);
      o["b"] = o1;
      r = JsLib.SetField(o, "a", v);
      Assert.AreNotEqual(o, r);
      Assert.AreEqual(JSC.JSValueType.Object, r.ValueType);
      Assert.AreEqual(v, r["a"]);
      Assert.AreEqual(o1, r["b"]);
    }
    [TestMethod]
    public void SetField05() {
      JSC.JSValue o = null, r, r1, v = new JSL.Boolean(true);
      r = JsLib.SetField(o, "a.b", v);
      Assert.AreNotEqual(o, r);
      Assert.AreEqual(JSC.JSValueType.Object, r.ValueType);
      r1 = r["a"];
      Assert.AreEqual(JSC.JSValueType.Object, r1.ValueType);
      Assert.AreEqual(v, r1["b"]);
    }
    [TestMethod]
    public void SetField06() {
      JSC.JSValue o = JSC.JSObject.CreateObject(), o_a = JSC.JSObject.CreateObject(), o_b = new JSL.Number(3), o_ac = new JSL.Number(2), r, r_a, v = new JSL.Boolean(true);
      o_a["c"] = o_ac;
      o_a["d"] = new JSL.Boolean(false);
      o["a"] = o_a;
      o["b"] = o_b;
      r = JsLib.SetField(o, "a.d", v);
      Assert.AreNotEqual(o, r);
      Assert.AreEqual(JSC.JSValueType.Object, r.ValueType);
      r_a = r["a"];
      Assert.AreNotEqual(o_a, r_a);
      Assert.AreEqual(JSC.JSValueType.Object, r_a.ValueType);
      Assert.AreEqual(o_ac, r_a["c"]);
      Assert.AreEqual(v, r_a["d"]);
      Assert.AreEqual(o_b, r["b"]);
    }
  }
}
