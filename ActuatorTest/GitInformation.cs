using System;
using Steeltoe.Management.Endpoint.Info.Contributor;
using Steeltoe.Management.Info;

namespace ActuatorTest
{
	public class GitInformation : IInfoContributor
	{

        public void Contribute(IInfoBuilder builder)
        {
            var tag = $"{ThisAssembly.Git.BaseVersion.Major}.{ThisAssembly.Git.BaseVersion.Minor}.{ThisAssembly.Git.BaseVersion.Patch}";
            var version = $"{tag}-{ThisAssembly.Git.Commit}";

            builder.WithInfo("git_info", new
            {
                branch = ThisAssembly.Git.Branch,
                commit = new
                {
                    time = ThisAssembly.Git.CommitDate,
                },
                id = new {
                    describe = version,
                    abbrev = "",
                    full = ""
                },
                build = new {
                    version = version,
                    user = new {
                        name = "",
                        email = ""
                    },
                    host = ""
                },
                dirty = ThisAssembly.Git.IsDirty,
                tags = ThisAssembly.Git.Tag,
                total = new {
                    commit = new {
                        count = ThisAssembly.Git.Commits
                    }
                },
                closest = new {
                    tag = new {
                        commit = new {
                            count = 0
                        },
                        name = tag,
                    }
                },
                remote = new
                {
                    origin = new
                    {
                        url = ThisAssembly.Git.RepositoryUrl
                    }
                }
            });
        }
    }
}

