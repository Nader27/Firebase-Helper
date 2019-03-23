using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireBase_Helper
{
    class Print_Class
    {
        private static Dictionary<int, Table> Database;

        private FileStream stream;
        private StreamWriter writer;

        private readonly string Location;

        public Print_Class(string location)
        {
            Location = location;
        }

        public void DoPrint(Dictionary<int, Table> database)
        {
            Database = database;

            CreateClassFile();

            PrintImport();

            PrintClassHeader();

            PrintClasses();

            writer.Close();
            stream.Close();

        }

        private void PrintClasses()
        {
            foreach (Table table in Database.Values)
            {
                PrintTableHeader(table.Name);
                PrintTableHeaderColumns(table.Columns);
                PrintTableHeaderRelations(table.Relations);
                PrintTableConstructor(table.Name, table.Relations);
                PrintTableGetter_Setter(table);
                if (table.properites.has_Add)
                    PrintTableAdd();
                if (table.properites.has_Update)
                    PrintTableUpdate();
                if (table.properites.has_Remove)
                    PrintTableRemove();
                if (table.properites.has_Find)
                    PrintTableFind(table);
                if (table.properites.has_Where)
                {
                    PrintTableWhere(table);
                    PrintTableWhereWithQuery(table);
                }
                if (table.properites.has_ToList)
                    PrintTableToList(table);
                PrintTableFooter(table.Name);
                PrintTableFooterEnum(table);
            }
        }

        private void CreateClassFile()
        {
            stream = new FileStream(Location, FileMode.Create, FileAccess.Write);
            writer = new StreamWriter(stream);
        }

        private void PrintImport()
        {
            writer.WriteLine("import android.util.Log;");
            writer.WriteLine("");
            writer.WriteLine("import com.google.firebase.database.DataSnapshot;");
            writer.WriteLine("import com.google.firebase.database.DatabaseError;");
            writer.WriteLine("import com.google.firebase.database.DatabaseReference;");
            writer.WriteLine("import com.google.firebase.database.FirebaseDatabase;");
            writer.WriteLine("import com.google.firebase.database.Query;");
            writer.WriteLine("import com.google.firebase.database.ValueEventListener;");
            writer.WriteLine("");
            writer.WriteLine("import java.lang.reflect.InvocationTargetException;");
            writer.WriteLine("import java.lang.reflect.Method;");
            writer.WriteLine("import java.util.ArrayList;");
            writer.WriteLine("import java.util.HashMap;");
            writer.WriteLine("import java.util.Iterator;");
            writer.WriteLine("import java.util.List;");
            writer.WriteLine("import java.util.Map;");
            writer.WriteLine("");
            writer.Flush();
        }

        private void PrintClassHeader()
        {
            writer.WriteLine("public class FireBaseHelper {");
            writer.WriteLine("private static final FirebaseDatabase database = FirebaseDatabase.getInstance();");
            writer.WriteLine("private static final DatabaseReference myRootRef = database.getReference();");
            writer.WriteLine("private static final String TAG = \"FirebaseHelper\";");
            writer.WriteLine("");
            writer.WriteLine("public interface OnGetDataListener<T> { void onSuccess(T Data); }" + writer.NewLine);
            writer.WriteLine("public interface OnGetDataListListener<T> { void onSuccess(List<T> Data); }" + writer.NewLine);
            writer.Flush();
        }

        private void PrintTableHeader(string name)
        {
            writer.WriteLine("public static class " + name + " {");
            writer.WriteLine("public static final DatabaseReference Ref = myRootRef.child(\"" + name + "\");");
            writer.WriteLine("");
            writer.Flush();
        }

        private void PrintTableHeaderColumns(List<string> columns)
        {
            foreach (string column in columns)
            {
                writer.WriteLine("public String " + column.ToLower() + ";");
            }
            writer.WriteLine("");
            writer.Flush();
        }

        private void PrintTableHeaderRelations(Dictionary<int, Relation_Type> relations)
        {
            foreach (KeyValuePair<int, Relation_Type> item in relations)
            {
                string table_name = Database[item.Key].Name;
                switch (item.Value)
                {
                    case Relation_Type.One_to_One:
                        writer.WriteLine("public " + table_name + " " + table_name.ToLower() + ";");
                        writer.WriteLine("public String _" + table_name.ToLower() + ";");
                        break;
                    case Relation_Type.One_to_Many:
                        writer.WriteLine("public List<" + table_name + "> " + table_name.ToLower() + ";");
                        break;
                    case Relation_Type.Many_to_One:
                        writer.WriteLine("public " + table_name + " " + table_name.ToLower() + ";");
                        writer.WriteLine("public String _" + table_name.ToLower() + ";");
                        break;
                    default:
                        break;
                }
            }
            writer.WriteLine("");
            writer.Flush();

        }

        private void PrintTableConstructor(string name, Dictionary<int, Relation_Type> relations)
        {
            writer.WriteLine("public " + name + "() {");
            foreach (KeyValuePair<int, Relation_Type> item in relations)
            {
                string table_name = Database[item.Key].Name;
                switch (item.Value)
                {
                    case Relation_Type.One_to_One:
                        writer.WriteLine(table_name.ToLower() + " = new " + table_name + "();");
                        break;
                    case Relation_Type.One_to_Many:
                        writer.WriteLine(table_name.ToLower() + " = new ArrayList<>();");
                        break;
                    case Relation_Type.Many_to_One:
                        writer.WriteLine(table_name.ToLower() + " = new " + table_name + "();");
                        break;
                    default:
                        break;
                }
            }
            writer.WriteLine("}" + writer.NewLine);
            writer.Flush();
        }

        private void PrintTableGetter_Setter(Table table)
        {
            List<string> columns = table.Columns;
            Dictionary<int, Relation_Type> relations = table.Relations;
            foreach (string column in columns)
            {
                writer.WriteLine("public String get" + column + "() { return " + column.ToLower() + "; }" + writer.NewLine);
                writer.WriteLine("public void set" + column + "(String " + column.ToLower() + ") { this." + column.ToLower() + " = " + column.ToLower() + "; }" + writer.NewLine);
            }
            foreach (KeyValuePair<int, Relation_Type> item in relations)
            {
                string table_name = Database[item.Key].Name;
                switch (item.Value)
                {
                    case Relation_Type.One_to_One:
                        writer.WriteLine("public String get_" + table_name + "() { return _" + table_name.ToLower() + "; }" + writer.NewLine);
                        writer.WriteLine("public void set_" + table_name + "(String _" + table_name.ToLower() + ") { this._" + table_name.ToLower() + " = _" + table_name.ToLower() + "; }" + writer.NewLine);
                        break;
                    case Relation_Type.One_to_Many:
                        break;
                    case Relation_Type.Many_to_One:
                        writer.WriteLine("public String get_" + table_name + "() { return _" + table_name.ToLower() + "; }" + writer.NewLine);
                        writer.WriteLine("public void set_" + table_name + "(String _" + table_name.ToLower() + ") { this._" + table_name.ToLower() + " = _" + table_name.ToLower() + "; }" + writer.NewLine);
                        break;
                    default:
                        break;
                }
            }
            writer.WriteLine("");
            writer.Flush();
        }

        private void PrintTableAdd()
        {
            writer.WriteLine("public String Add() {");
            writer.WriteLine("Map<String, String> Values = new HashMap<>();");
            writer.WriteLine("for (Table T : Table.values()) { Values.put(T.text, getbyName(this, T.name())); }");
            writer.WriteLine("DatabaseReference myref = Ref.push();");
            writer.WriteLine("myref.setValue(Values);");
            writer.WriteLine("return Key = myref.getKey();}" + writer.NewLine);
            writer.WriteLine("public String Add(String key) {");
            writer.WriteLine("Map<String, String> Values = new HashMap<>();");
            writer.WriteLine("for (Table T : Table.values()) { Values.put(T.text, getbyName(this, T.name())); }");
            writer.WriteLine("Ref.child(key).setValue(Values);}" + writer.NewLine);
            writer.Flush();
        }

        private void PrintTableUpdate()
        {
            writer.WriteLine("public void Update() {");
            writer.WriteLine("Map<String, String> Values = new HashMap<>();");
            writer.WriteLine("for (Table T : Table.values()) { Values.put(T.text, getbyName(this, T.name())); }");
            writer.WriteLine("Ref.child(Key).setValue(Values);}" + writer.NewLine);
            writer.WriteLine("public void Update(String key) {");
            writer.WriteLine("Map<String, String> Values = new HashMap<>();");
            writer.WriteLine("for (Table T : Table.values()) { Values.put(T.text, getbyName(this, T.name())); }");
            writer.WriteLine("Ref.child(key).setValue(Values);}" + writer.NewLine);
            writer.Flush();
        }

        private void PrintTableRemove()
        {
            writer.WriteLine("public void Remove(String Key) { Ref.child(Key).removeValue(); }" + writer.NewLine);
            writer.Flush();
        }

        private void PrintTableFind(Table table)
        {
            writer.Write(
                "public void Findbykey(String key, final OnGetDataListener<" + table.Name + "> listener) {" + writer.NewLine +
                "Ref.child(key).addListenerForSingleValueEvent(new ValueEventListener() {" + writer.NewLine +
                "@Override" + writer.NewLine +
                "public void onDataChange(DataSnapshot dataSnapshot) {" + writer.NewLine +
                "if (dataSnapshot.exists()) {" + writer.NewLine +
                "final " + table.Name + " obj = new " + table.Name + "();" + writer.NewLine +
                "obj.key = dataSnapshot.getKey();" + writer.NewLine +
                "for (Table T : Table.values()) {setbyName(obj, T.name(), dataSnapshot.child(T.text).getValue().toString());}" + writer.NewLine
                );
            int Counter = 0;
            foreach (KeyValuePair<int, Relation_Type> item in table.Relations)
            {
                string tableName = Database[item.Key].Name;
                if (item.Value != Relation_Type.One_to_Many)
                {
                    writer.Write(tableName.ToLower() + ".Findbykey(obj._" + tableName.ToLower() + ", Data" + Counter + " -> {" + writer.NewLine +
                        "obj." + tableName.ToLower() + " = Data" + Counter + ";" + writer.NewLine);
                }
                else
                {
                    writer.Write(
                    tableName + ".Ref.orderByChild(" + tableName + ".Table._" + table.Name.ToLower() + ".text).equalTo(obj.key).addListenerForSingleValueEvent(new ValueEventListener() {" + writer.NewLine +
                    "@Override" + writer.NewLine +
                    "public void onDataChange(DataSnapshot dataSnapshot" + Counter + ") {" + writer.NewLine +
                    "final " + tableName + " item" + Counter + " = new " + tableName + "();" + writer.NewLine +
                    "for (DataSnapshot Data" + Counter + " : dataSnapshot" + Counter + ".getChildren()) {" + writer.NewLine +
                    "for (" + tableName + ".Table T" + Counter + " : " + tableName + ".Table.values()) {" + writer.NewLine +
                    "item" + Counter + ".setbyName(item, T" + Counter + ".name(), Data" + Counter + ".child(T" + Counter + ".text).getValue().toString());" + writer.NewLine +
                    "obj." + tableName.ToLower() + ".add(item" + Counter + ");}}" + writer.NewLine
                    );
                }
                Counter++;
            }
            writer.WriteLine("listener.onSuccess(obj);");
            foreach (KeyValuePair<int, Relation_Type> item in table.Relations.Reverse())
            {
                if (item.Value != Relation_Type.One_to_Many)
                    writer.WriteLine("});");
                else
                    writer.Write(
                    "}" + writer.NewLine +
                    "@Override" + writer.NewLine +
                    "public void onCancelled(DatabaseError databaseError) {" + writer.NewLine +
                    "Log.w(TAG, \"Firebase Warning :\" + databaseError);}});" + writer.NewLine
                    );
            }
            writer.Write(
                "} else { listener.onSuccess(null);}}" + writer.NewLine +
                "@Override" + writer.NewLine +
                "public void onCancelled(DatabaseError databaseError) {Log.w(TAG, \"Firebase Warning :\" + databaseError);}});}" + writer.NewLine
                );
            writer.WriteLine("");
            writer.Flush();
        }

        private void PrintTableWhere(Table table)
        {
            {
                writer.Write(
                        "public void Where(Table table, String Value, final OnGetDataListListener<" + table.Name + "> listener) {" + writer.NewLine +
                        "final List<" + table.Name + "> Items = new ArrayList<>();" + writer.NewLine +
                        "Query query = Ref.orderByChild(table.text).equalTo(Value);" + writer.NewLine +
                        "query.addListenerForSingleValueEvent(new ValueEventListener() {" + writer.NewLine +
                        "@Override" + writer.NewLine +
                        "public void onDataChange(final DataSnapshot dataSnapshot) {" + writer.NewLine +
                        "final Iterator iterator = dataSnapshot.getChildren().iterator();" + writer.NewLine +
                        "while (iterator.hasNext()) {" + writer.NewLine +
                        "DataSnapshot postSnapshot = (DataSnapshot) iterator.next();" + writer.NewLine +
                        "final " + table.Name + " obj = new " + table.Name + "();" + writer.NewLine +
                        "obj.key = postSnapshot.getKey();" + writer.NewLine +
                        "for (Table T : Table.values()) {" + writer.NewLine +
                        "setbyName(obj, T.name(), postSnapshot.child(T.text).getValue().toString());}" + writer.NewLine
                        );
                int Counter = 0;
                foreach (KeyValuePair<int, Relation_Type> item in table.Relations)
                {
                    string tableName = Database[item.Key].Name;
                    if (item.Value != Relation_Type.One_to_Many)
                    {
                        writer.Write(tableName.ToLower() + ".Findbykey(obj._" + tableName.ToLower() + ", Data" + Counter + " -> {" + writer.NewLine +
                            "obj." + tableName.ToLower() + " = Data" + Counter + ";" + writer.NewLine);
                    }
                    else
                    {
                        writer.Write(
                        tableName + ".Ref.orderByChild(" + tableName + ".Table._" + table.Name.ToLower() + ".text).equalTo(obj.key).addListenerForSingleValueEvent(new ValueEventListener() {" + writer.NewLine +
                        "@Override" + writer.NewLine +
                        "public void onDataChange(DataSnapshot dataSnapshot" + Counter + ") {" + writer.NewLine +
                        "final " + tableName + " item" + Counter + " = new " + tableName + "();" + writer.NewLine +
                        "for (DataSnapshot Data" + Counter + " : dataSnapshot" + Counter + ".getChildren()) {" + writer.NewLine +
                        "for (" + tableName + ".Table T" + Counter + " : " + tableName + ".Table.values()) {" + writer.NewLine +
                        "item" + Counter + ".setbyName(item, T" + Counter + ".name(), Data" + Counter + ".child(T" + Counter + ".text).getValue().toString());" + writer.NewLine +
                        "obj." + tableName.ToLower() + ".add(item" + Counter + ");}}" + writer.NewLine
                        );
                    }
                    Counter++;
                }
                writer.Write(
                        "Items.add(obj);" + writer.NewLine +
                        "if (!iterator.hasNext()) { listener.onSuccess(Items); }" + writer.NewLine
                        );
                foreach (KeyValuePair<int, Relation_Type> item in table.Relations.Reverse())
                {
                    if (item.Value != Relation_Type.One_to_Many)
                        writer.WriteLine("});");
                    else
                        writer.Write(
                        "}" + writer.NewLine +
                        "@Override" + writer.NewLine +
                        "public void onCancelled(DatabaseError databaseError) {" + writer.NewLine +
                        "Log.w(TAG, \"Firebase Warning :\" + databaseError);}});" + writer.NewLine
                        );
                }
                writer.Write(
                        "}if (dataSnapshot.getChildrenCount() == 0) {" + writer.NewLine +
                        "listener.onSuccess(Items);}}" + writer.NewLine +
                        "@Override" + writer.NewLine +
                        "public void onCancelled(DatabaseError databaseError) {Log.w(TAG, \"Firebase Warning :\" + databaseError);}});}" + writer.NewLine
                        );
                writer.WriteLine("");
                writer.Flush();
            }
        }

        private void PrintTableWhereWithQuery(Table table)
        {
            {
                writer.Write(
                        "public void Where(Query query, final OnGetDataListListener<" + table.Name + "> listener) {" + writer.NewLine +
                        "final List<" + table.Name + "> Items = new ArrayList<>();" + writer.NewLine +
                        "query.addListenerForSingleValueEvent(new ValueEventListener() {" + writer.NewLine +
                        "@Override" + writer.NewLine +
                        "public void onDataChange(final DataSnapshot dataSnapshot) {" + writer.NewLine +
                        "final Iterator iterator = dataSnapshot.getChildren().iterator();" + writer.NewLine +
                        "while (iterator.hasNext()) {" + writer.NewLine +
                        "DataSnapshot postSnapshot = (DataSnapshot) iterator.next();" + writer.NewLine +
                        "final " + table.Name + " obj = new " + table.Name + "();" + writer.NewLine +
                        "obj.key = postSnapshot.getKey();" + writer.NewLine +
                        "for (Table T : Table.values()) {" + writer.NewLine +
                        "setbyName(obj, T.name(), postSnapshot.child(T.text).getValue().toString());}" + writer.NewLine
                        );
                int Counter = 0;
                foreach (KeyValuePair<int, Relation_Type> item in table.Relations)
                {
                    string tableName = Database[item.Key].Name;
                    if (item.Value != Relation_Type.One_to_Many)
                    {
                        writer.Write(tableName.ToLower() + ".Findbykey(obj._" + tableName.ToLower() + ", Data" + Counter + " -> {" + writer.NewLine +
                            "obj." + tableName.ToLower() + " = Data" + Counter + ";" + writer.NewLine);
                    }
                    else
                    {
                        writer.Write(
                        tableName + ".Ref.orderByChild(" + tableName + ".Table._" + table.Name.ToLower() + ".text).equalTo(obj.key).addListenerForSingleValueEvent(new ValueEventListener() {" + writer.NewLine +
                        "@Override" + writer.NewLine +
                        "public void onDataChange(DataSnapshot dataSnapshot" + Counter + ") {" + writer.NewLine +
                        "final " + tableName + " item" + Counter + " = new " + tableName + "();" + writer.NewLine +
                        "for (DataSnapshot Data" + Counter + " : dataSnapshot" + Counter + ".getChildren()) {" + writer.NewLine +
                        "for (" + tableName + ".Table T" + Counter + " : " + tableName + ".Table.values()) {" + writer.NewLine +
                        "item" + Counter + ".setbyName(item, T" + Counter + ".name(), Data" + Counter + ".child(T" + Counter + ".text).getValue().toString());" + writer.NewLine +
                        "obj." + tableName.ToLower() + ".add(item" + Counter + ");}}" + writer.NewLine
                        );
                    }
                    Counter++;
                }
                writer.Write(
                        "Items.add(obj);" + writer.NewLine +
                        "if (!iterator.hasNext()) { listener.onSuccess(Items); }" + writer.NewLine
                        );
                foreach (KeyValuePair<int, Relation_Type> item in table.Relations.Reverse())
                {
                    if (item.Value != Relation_Type.One_to_Many)
                        writer.WriteLine("});");
                    else
                        writer.Write(
                        "}" + writer.NewLine +
                        "@Override" + writer.NewLine +
                        "public void onCancelled(DatabaseError databaseError) {" + writer.NewLine +
                        "Log.w(TAG, \"Firebase Warning :\" + databaseError);}});" + writer.NewLine
                        );
                }
                writer.Write(
                        "}if (dataSnapshot.getChildrenCount() == 0) {" + writer.NewLine +
                        "listener.onSuccess(Items);}}" + writer.NewLine +
                        "@Override" + writer.NewLine +
                        "public void onCancelled(DatabaseError databaseError) {Log.w(TAG, \"Firebase Warning :\" + databaseError);}});}" + writer.NewLine
                        );
                writer.WriteLine("");
                writer.Flush();
            }
        }

        private void PrintTableToList(Table table)
        {
            writer.Write(
                    "public void Tolist(final OnGetDataListListener<" + table.Name + "> listener) {" + writer.NewLine +
                    "final List<" + table.Name + "> Items = new ArrayList<>();" + writer.NewLine +
                    "Ref.addListenerForSingleValueEvent(new ValueEventListener() {" + writer.NewLine +
                    "@Override" + writer.NewLine +
                    "public void onDataChange(final DataSnapshot dataSnapshot) {" + writer.NewLine +
                    "final Iterator iterator = dataSnapshot.getChildren().iterator();" + writer.NewLine +
                    "while (iterator.hasNext()) {" + writer.NewLine +
                    "DataSnapshot postSnapshot = (DataSnapshot) iterator.next();" + writer.NewLine +
                    "final " + table.Name + " obj = new " + table.Name + "();" + writer.NewLine +
                    "obj.key = postSnapshot.getKey();" + writer.NewLine +
                    "for (Table T : Table.values()) {" + writer.NewLine +
                    "setbyName(obj, T.name(), postSnapshot.child(T.text).getValue().toString());}" + writer.NewLine
                    );
            int Counter = 0;
            foreach (KeyValuePair<int, Relation_Type> item in table.Relations)
            {
                string tableName = Database[item.Key].Name;
                if (item.Value != Relation_Type.One_to_Many)
                {
                    writer.Write(tableName.ToLower() + ".Findbykey(obj._" + tableName.ToLower() + ", Data" + Counter + " -> {" + writer.NewLine +
                        "obj." + tableName.ToLower() + " = Data" + Counter + ";" + writer.NewLine);
                }
                else
                {
                    writer.Write(
                    tableName + ".Ref.orderByChild(" + tableName + ".Table._" + table.Name.ToLower() + ".text).equalTo(obj.key).addListenerForSingleValueEvent(new ValueEventListener() {" + writer.NewLine +
                    "@Override" + writer.NewLine +
                    "public void onDataChange(DataSnapshot dataSnapshot" + Counter + ") {" + writer.NewLine +
                    "final " + tableName + " item" + Counter + " = new " + tableName + "();" + writer.NewLine +
                    "for (DataSnapshot Data" + Counter + " : dataSnapshot" + Counter + ".getChildren()) {" + writer.NewLine +
                    "for (" + tableName + ".Table T" + Counter + " : " + tableName + ".Table.values()) {" + writer.NewLine +
                    "item" + Counter + ".setbyName(item, T" + Counter + ".name(), Data" + Counter + ".child(T" + Counter + ".text).getValue().toString());" + writer.NewLine +
                    "obj." + tableName.ToLower() + ".add(item" + Counter + ");}}" + writer.NewLine
                    );
                }
                Counter++;
            }
            writer.Write(
                    "Items.add(obj);" + writer.NewLine +
                    "if (!iterator.hasNext()) { listener.onSuccess(Items); }" + writer.NewLine
                    );
            foreach (KeyValuePair<int, Relation_Type> item in table.Relations.Reverse())
            {
                if (item.Value != Relation_Type.One_to_Many)
                    writer.WriteLine("});");
                else
                    writer.Write(
                    "}" + writer.NewLine +
                    "@Override" + writer.NewLine +
                    "public void onCancelled(DatabaseError databaseError) {" + writer.NewLine +
                    "Log.w(TAG, \"Firebase Warning :\" + databaseError);}});" + writer.NewLine
                    );
            }
            writer.Write(
                    "}if (dataSnapshot.getChildrenCount() == 0) {" + writer.NewLine +
                    "listener.onSuccess(Items);}}" + writer.NewLine +
                    "@Override" + writer.NewLine +
                    "public void onCancelled(DatabaseError databaseError) {Log.w(TAG, \"Firebase Warning :\" + databaseError);}});}" + writer.NewLine
                    );
            writer.WriteLine("");
            writer.Flush();
        }

        private void PrintTableFooter(string name)
        {
            writer.WriteLine("private String getbyName(" + name + " obj, String Name) {");
            writer.WriteLine("String Value = \"\";");
            writer.WriteLine("try {");
            writer.WriteLine("Method method = getClass().getDeclaredMethod(\"get\" + Name);");
            writer.WriteLine("Object value = method.invoke(obj);");
            writer.WriteLine("Value = (String) value;");
            writer.WriteLine("} catch (SecurityException | NoSuchMethodException | IllegalArgumentException | IllegalAccessException | InvocationTargetException e) {");
            writer.WriteLine("Log.e(TAG, \"Firebase Invoke Error: \" + e.getMessage(), e);}");
            writer.WriteLine("return Value;}");
            writer.WriteLine("private void setbyName(" + name + " obj, String Name, String Value) {");
            writer.WriteLine("try {");
            writer.WriteLine("Class[] cArg = new Class[1];");
            writer.WriteLine("cArg[0] = String.class;");
            writer.WriteLine("Method method = getClass().getDeclaredMethod(\"set\" + Name, cArg);");
            writer.WriteLine("method.invoke(obj, Value);");
            writer.WriteLine("} catch (SecurityException | NoSuchMethodException | IllegalArgumentException | IllegalAccessException | InvocationTargetException e) {");
            writer.WriteLine("Log.e(TAG, \"Firebase Invoke Error: \" + e.getMessage(), e);}}" + writer.NewLine);
            writer.Flush();
        }

        private void PrintTableFooterEnum(Table table)
        {
            List<string> columns = table.Columns;
            Dictionary<int, Relation_Type> relations = table.Relations;
            writer.WriteLine("public enum Table {");
            foreach (KeyValuePair<int, Relation_Type> item in relations)
            {
                string table_name = Database[item.Key].Name;
                switch (item.Value)
                {
                    case Relation_Type.One_to_One:
                        writer.Write("_" + table_name + "(\"_" + table_name.ToLower() + "\"),");
                        break;
                    case Relation_Type.One_to_Many:
                        break;
                    case Relation_Type.Many_to_One:
                        writer.Write("_" + table_name + "(\"_" + table_name.ToLower() + "\"),");
                        break;
                    default:
                        break;
                }
            }
            for (int i = 0; i < columns.Count; i++)
            {
                writer.Write("" + columns[i] + "(\"" + columns[i].ToLower() + "\")" + ((i + 1 == columns.Count) ? ";" : ",") + "");
            }
            writer.WriteLine("");

            writer.WriteLine("public final String text;" + writer.NewLine);
            writer.WriteLine("Table(final String text) {this.text = text;}");
            writer.WriteLine("@Override");
            writer.WriteLine("public String toString() {return text;}}}" + writer.NewLine + writer.NewLine);
            writer.Flush();
        }
    }
}
