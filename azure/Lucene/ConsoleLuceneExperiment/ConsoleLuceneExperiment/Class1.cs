using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lucene.Net.Analysis;
using System.IO;

using Directory = Lucene.Net.Store.Directory;
using Version = Lucene.Net.Util.Version;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.QueryParsers;
using Lucene.Net.Documents;
using Lucene.Net.Store;
using Lucene.Net.Analysis.Standard;
using Microsoft.ApplicationServer.Caching;
using Lucene.Net.Store.Azure;

namespace ConsoleLuceneExperiment
{
    public class Class1
    {
        static void Main()
        {
            DataCache cache = new DataCache();

            var fordFiesta = new Document();
            fordFiesta.Add(new Field("Id", "1", Field.Store.YES, Field.Index.NOT_ANALYZED));
            fordFiesta.Add(new Field("Make", "Ford", Field.Store.YES, Field.Index.ANALYZED));
            fordFiesta.Add(new Field("Model", "Fiesta", Field.Store.YES, Field.Index.ANALYZED));

            var fordFocus = new Document();
            fordFocus.Add(new Field("Id", "2", Field.Store.YES, Field.Index.NOT_ANALYZED));
            fordFocus.Add(new Field("Make", "Ford", Field.Store.YES, Field.Index.ANALYZED));
            fordFocus.Add(new Field("Model", "Focus", Field.Store.YES, Field.Index.ANALYZED));

            var vauxhallAstra = new Document();
            vauxhallAstra.Add(new Field("Id", "3", Field.Store.YES, Field.Index.NOT_ANALYZED));
            vauxhallAstra.Add(new Field("Make", "Vauxhall", Field.Store.YES, Field.Index.ANALYZED));
            vauxhallAstra.Add(new Field("Model", "Astra", Field.Store.YES, Field.Index.ANALYZED));


            using (AzureDataCacheDirectory directory = new AzureDataCacheDirectory("testing", cache))
            {
                Analyzer analyzer = new StandardAnalyzer(Version.LUCENE_30);

                var writer = new IndexWriter(directory, analyzer, true, IndexWriter.MaxFieldLength.LIMITED);
                writer.AddDocument(fordFiesta);
                writer.AddDocument(fordFocus);
                writer.AddDocument(vauxhallAstra);

                writer.Optimize();
                writer.Close();

                IndexReader indexReader = IndexReader.Open(directory, true);
                using (Searcher indexSearch = new IndexSearcher(indexReader))
                {
                    var queryParser = new QueryParser(Version.LUCENE_30, "Make", analyzer);
                    var query = queryParser.Parse("Ford");

                    Console.WriteLine("Searching for: " + query.ToString());
                    TopDocs resultDocs = indexSearch.Search(query, indexReader.MaxDoc);

                    Console.WriteLine("Results Found: " + resultDocs.TotalHits);

                    var hits = resultDocs.ScoreDocs;
                    foreach (var hit in hits)
                    {
                        var documentFromSearcher = indexSearch.Doc(hit.Doc);
                        Console.WriteLine(documentFromSearcher.Get("Make") + " " + documentFromSearcher.Get("Model"));
                    }

                }
            }

            Console.ReadLine();

        }
        
    }
}
